using Kenku.Extensions;
using Kenku.Models.Interfaces;
using Kenku.Objects.Interfaces;
using Kenku.ServiceFactoryHelpers;
using Kenku.Services.Interfaces;

namespace Kenku.Objects.Implementations
{
    internal partial class Session : ISession
    {
        public Session(IReadOnlyContainer container)
        {
            this.Container = container ?? throw new ArgumentNullException(nameof(container));
            this.InnerInputAudioDeviceService = container
                .InputAudioDeviceServices
                .FirstOrDefaultFallbackFirst(container.ConfigurationService.InputAudioDeviceServiceName, x => x.Name);
            this.InnerOutputAudioDeviceService = container
                .OutputAudioDeviceServices
                .FirstOrDefaultFallbackFirst(container.ConfigurationService.OutputAudioDeviceServiceName, x => x.Name);
            this.InnerPreviewAudioDeviceService = container
                .OutputAudioDeviceServices
                .FirstOrDefaultFallbackFirst(container.ConfigurationService.PreviewAudioDeviceServiceName, x => x.Name);
            this.SimpleTextToSpeechService = container
                .TextToSpeechServices
                .First();
            this.FilteredTextToSpeechServices = container
                .TextToSpeechServices;
        }

        public IReadOnlyContainer Container { get; }
        public ITextToSpeechService SimpleTextToSpeechService { get; set; }
        public IReadOnlyList<IReadOnlyPersonality> Personalities { get; private set; }
        public IReadOnlyList<IReadOnlyVoiceRecording> VoiceRecordings { get; private set; }
        
        private IReadOnlyList<ITextToSpeechService> InnerFilteredTextToSpeechServices;
        public IReadOnlyList<ITextToSpeechService> FilteredTextToSpeechServices
        {
            get => this.InnerFilteredTextToSpeechServices;
            set
            {
                this.InnerFilteredTextToSpeechServices = value;
                this.Container.KenkuEmulationService.FilteredTextToSpeechServices = value;
            }
        }

        IReadOnlyList<IInputAudioDeviceService> ISession.InputAudioDeviceServices => this
            .Container
            .InputAudioDeviceServices;

        IReadOnlyList<IOutputAudioDeviceService> ISession.OutputAudioDeviceServices => this
            .Container
            .OutputAudioDeviceServices;

        IReadOnlyList<ITextToSpeechService> ISession.TextToSpeechServices => this
            .Container
            .TextToSpeechServices;

        private IConfigurationService ConfigurationService => this
            .Container
            .ConfigurationService;

        private IOutputAudioDeviceService[] GetOutputDevicesForPlayback()
        {
            if (this.Container.ConfigurationService.IsMirroredPlaybackMode)
            {
                return
                [
                    this.OutputAudioDeviceService,
                    this.PreviewAudioDeviceService
                ];
            }
            return
            [
                this.OutputAudioDeviceService
            ];
        }

        public async Task PlayTextToSpeechAsync(string text, CancellationToken cancellationToken)
        {
            var outputAudioDevices = this.GetOutputDevicesForPlayback();
            var preamble = this.ConfigurationService.UseForcedPreambleForTextToSpeech ? this.ConfigurationService.ForcedPreambleText : string.Empty;
            await this
                .SimpleTextToSpeechService!
                .SpeakAsync
                (
                    $"{preamble}{text}",
                    cancellationToken,
                    outputAudioDevices
                )
                .ConfigureAwait(false);
        }

        public async Task PlayVoiceRecording(IReadOnlyVoiceRecording voiceRecording, CancellationToken cancellationToken)
        {
            var outputAudioDevices = this.GetOutputDevicesForPlayback();
            if (this.ConfigurationService.UseForcedPreambleForVoiceRecordingPlayback && !string.IsNullOrWhiteSpace(this.ConfigurationService.ForcedPreambleText))
            {
                await this.Container
                    .KenkuEmulationService
                    .SpeakAsync
                    (
                        this.ConfigurationService.ForcedPreambleText,
                        cancellationToken,
                        outputAudioDevices
                    )
                    .ConfigureAwait(false);
            }
            await this
                .Container
                .VoiceRecordingService
                .PlayAsync(voiceRecording, cancellationToken, outputAudioDevices)
                .ConfigureAwait(false);
        }

        public async Task PreviewVoiceRecording(IReadOnlyVoiceRecording voiceRecording, CancellationToken cancellationToken)
        {
            await this
                .Container
                .VoiceRecordingService
                .PlayAsync(voiceRecording, cancellationToken, this.PreviewAudioDeviceService)
                .ConfigureAwait(false);
        }

        public async Task<bool> UpdateVoiceRecordingPersonality(IReadOnlyVoiceRecording voiceRecording, IReadOnlyPersonality personality)
        {
            var isSuccess = await this
                .Container
                .VoiceRecordingService
                .UpdateVoiceRecordingPersonalityAsync(voiceRecording, personality)
                .ConfigureAwait(false);
            if (isSuccess)
            {
                await this
                    .RefreshAsync();
            }
            return isSuccess;
        }

        public async Task RefreshAsync()
        {
            this.Personalities = await this
                .Container
                .PersonalityService
                .FetchAllAsync()
                .ConfigureAwait(false);
            this.VoiceRecordings = await this
                .Container
                .VoiceRecordingService
                .FetchAllAsync()
                .ConfigureAwait(false);
            this.Container
                .KenkuVoiceTextParserService
                .SetKenkuEmulationData(this.VoiceRecordings);
        }

        public async Task<bool> DeleteVoiceRecording(IReadOnlyVoiceRecording voiceRecording)
        {
            var isSuccess = await this
                .Container
                .VoiceRecordingService
                .DeleteAsync(voiceRecording)
                .ConfigureAwait(false);
            if (isSuccess)
            {
                await this
                    .RefreshAsync()
                    .ConfigureAwait(false);
            }
            return isSuccess;
        }

        public Task<string> GetFullFilePath(IReadOnlyVoiceRecording voiceRecording)
        {
            var file = this
                .Container
                .ConfigurationService
                .GetVoiceRecordingStreamFile(voiceRecording.Id);
            return Task.FromResult(file.FullName);
        }
    }
}
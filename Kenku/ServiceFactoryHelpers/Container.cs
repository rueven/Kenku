using Kenku.Objects.Implementations;
using Kenku.Objects.Interfaces;
using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    internal class Container : IReadOnlyContainer
    {
        public required IAudioResourceService AudioResourceService { get; set; }
        public required IConfigurationService ConfigurationService { get; set; }
        public required IKenkuEmulationService KenkuEmulationService { get; set; }
        public required IKenkuVoiceTextParserService KenkuVoiceTextParserService { get; set; }
        public required IPersonalityService PersonalityService { get; set; }
        public required IReadOnlyList<IInputAudioDeviceService> InputAudioDeviceServices { get; set; }
        public required IReadOnlyList<IOutputAudioDeviceService> OutputAudioDeviceServices { get; set; }
        public required ISerializerService SerializerService { get; set; }
        public required IVoiceRecordingService VoiceRecordingService { get; set; }
        public required IVoiceRecordingOperationsService VoiceRecordingOperationsService { get; set; }
        public required List<ITextToSpeechService> TextToSpeechServices { get; internal set; }
        IReadOnlyList<ITextToSpeechService> IReadOnlyContainer.TextToSpeechServices => this.TextToSpeechServices;

        public IReadOnlyContainer AddTextToSpeechService(params ITextToSpeechService[] textToSpeechService)
        {
            foreach (var service in textToSpeechService)
            {
                this.TextToSpeechServices
                    .Add(service);
            }
            return this;
        }

        public IReadOnlyContainer AddKenkuTextToSpeechService()
        {
            this.TextToSpeechServices
                .Add(this.KenkuEmulationService);
            return this;
        }

        public async Task<ISession> CreateSessionAsync()
        {
            var output = new Session(this);
            await output.RefreshAsync();
            return output;
        }
    }
}
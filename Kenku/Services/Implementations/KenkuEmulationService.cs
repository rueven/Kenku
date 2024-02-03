using Kenku.Extensions;
using Kenku.Services.Interfaces;

namespace Kenku.Services.Implementations
{
    internal class KenkuEmulationService : IKenkuEmulationService
    {
        public KenkuEmulationService(IKenkuVoiceTextParserService kenkuVoiceTextParserService, IReadOnlyList<ITextToSpeechService> textToSpeechServices, IVoiceRecordingService voiceRecordingService)
        {
            this.KenkuVoiceTextParserService = kenkuVoiceTextParserService;
            this.TextToSpeechServices = textToSpeechServices;
            this.FilteredTextToSpeechServices = this.TextToSpeechServices;
            this.VoiceRecordingService = voiceRecordingService;
        }

        public string Name { get; } = "Kenku";
        protected IKenkuVoiceTextParserService KenkuVoiceTextParserService { get; }
        protected IReadOnlyList<ITextToSpeechService> TextToSpeechServices { get; }
        protected IVoiceRecordingService VoiceRecordingService { get; }
        public IReadOnlyList<ITextToSpeechService> FilteredTextToSpeechServices { get; set; }

        private IReadOnlyList<ITextToSpeechService> UsableTextToSpeechServices => this
            .FilteredTextToSpeechServices ?? this
            .TextToSpeechServices;

        public async Task SpeakAsync(string value, params IOutputAudioDeviceService[] outputAudioDeviceServices)
        {
            var parts = this
                .KenkuVoiceTextParserService
                .Parse(value);
            foreach (var part in parts)
            {
                if (part.VoiceRecording == null)
                {
                    var service = this
                        .UsableTextToSpeechServices
                        .SelectRandomItem(x => x is not KenkuEmulationService);
                    if (service == null)
                    {
                        throw new Exception("No ITextToSpeechService found");
                    }
                    await service
                        .SpeakAsync(part.Text, outputAudioDeviceServices)
                        .ConfigureAwait(false);
                }
                else
                {
                    await this
                        .VoiceRecordingService
                        .PlayAsync(part.VoiceRecording, outputAudioDeviceServices)
                        .ConfigureAwait(false);
                }
            }
        }
    }
}
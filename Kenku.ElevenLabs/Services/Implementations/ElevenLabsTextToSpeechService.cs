using ElevenLabs.Voices;
using Kenku.Extensions;
using Kenku.Services.Interfaces;
using Kenku.Services.Interfaces.TextToSpeech;

namespace Kenku.Services.Implementations.TextToSpeech
{
    internal class ElevenLabsTextToSpeechService : ITextToSpeechService
    {
        public ElevenLabsTextToSpeechService(IElevenLabsClientService elevenLabsClientService, Voice voice, VoiceSettings voiceSettings)
        {
            this.ElevenLabsClientService = elevenLabsClientService;
            this.Voice = voice;
            this.VoiceSettings = voiceSettings;
            this.Name = $"ElevenLabs:{voice.Name}";
        }

        public string Name { get; }
        protected IElevenLabsClientService ElevenLabsClientService { get; }
        private Voice Voice { get; }
        private VoiceSettings VoiceSettings { get; }

        public async Task SpeakAsync(string value, CancellationToken cancellationToken, params IOutputAudioDeviceService[] outputAudioDeviceServices)
        {
            using var stream = await this
                .ElevenLabsClientService
                .GenerateAsync(this.Voice, this.VoiceSettings, value)
                .ConfigureAwait(false);
            await stream
                .PlayMp3Async(cancellationToken, outputAudioDeviceServices)
                .ConfigureAwait(false);
        }
    }
}
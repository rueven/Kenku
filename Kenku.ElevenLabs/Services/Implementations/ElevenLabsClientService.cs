using ElevenLabs;
using ElevenLabs.Voices;
using Kenku.Services.Interfaces.TextToSpeech;

namespace Kenku.Services.Implementations
{
    internal class ElevenLabsClientService : IElevenLabsClientService
    {
        public ElevenLabsClientService(string apiKey)
        {
            this.ElevenLabsClient = new ElevenLabsClient(new ElevenLabsAuthentication(apiKey));
        }

        private ElevenLabsClient ElevenLabsClient { get; set; }

        public async Task<IReadOnlyList<Voice>> GetVoices()
        {
            var voices = await this
                .ElevenLabsClient
                .VoicesEndpoint
                .GetAllVoicesAsync();
            return voices;
        }

        public async Task<Stream> GenerateAsync(Voice voice, VoiceSettings voiceSettings, string text)
        {
            var result = await this
                .ElevenLabsClient
                .TextToSpeechEndpoint
                .TextToSpeechAsync(text, voice, voiceSettings, outputFormat: OutputFormat.MP3_44100_64);
            return new MemoryStream(result.ClipData.ToArray());
        }
    }
}
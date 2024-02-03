using Kenku.ServiceFactoryHelpers;
using Kenku.Services.Implementations;
using Kenku.Services.Implementations.TextToSpeech;

namespace Kenku.ElevenLabs
{
    public static class Extensions
    {
        public static async Task<IReadOnlyContainer> AddEleventLabsTextToSpeechServicesAsync(this IReadOnlyContainer container, string apiKey)
        {
            var service = new ElevenLabsClientService(apiKey);
            var voices = await service
                .GetVoices();
            foreach (var voice in voices)
            {
                container.AddTextToSpeechService(new ElevenLabsTextToSpeechService(service, voice, voice.Settings));
            }
            return container;
        }
    }
}
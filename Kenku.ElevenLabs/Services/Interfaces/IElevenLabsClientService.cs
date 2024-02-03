using ElevenLabs.Voices;

namespace Kenku.Services.Interfaces.TextToSpeech
{
    public interface IElevenLabsClientService
    {
        Task<IReadOnlyList<Voice>> GetVoices();
        Task<Stream> GenerateAsync(Voice voice, VoiceSettings voiceSettings, string text);
    }
}
using Kenku.ServiceFactoryHelpers;
using Kenku.Services.Interfaces;
using System.Speech.Synthesis;

namespace Kenku.MicrosoftTextToSpeech
{
    public static class MicrosoftTextToSpeechExtensions
    {
        public static IReadOnlyContainer AddMicrosoftTextToSpeechServices(this IReadOnlyContainer container)
        {
#pragma warning disable CA1416 // Validate platform compatibility
            var synthesizer = new SpeechSynthesizer();
            foreach (var voice in synthesizer.GetInstalledVoices())
            {
                container
                    .AddTextToSpeechService(new MicrosoftTextToSpeechService(synthesizer, voice));
            }
#pragma warning restore CA1416 // Validate platform compatibility
            return container;
        }

        public static ISpeechToTextFactoryService CreateMicrosoftSpeechToTextFactoryService(this IReadOnlyContainer container)
        {
            return new MicrosoftSpeechToTextService();
        }

        public static ISpeechToTextFactoryService CreateWindowsMediaSpeechToTextFactoryService(this IReadOnlyContainer container)
        {
            return new WindowsMediaSpeechToTextService();
        }
    }
}
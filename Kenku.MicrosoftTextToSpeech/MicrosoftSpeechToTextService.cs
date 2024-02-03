using Kenku.Objects.Interfaces;
using Kenku.Services.Interfaces;
using System.Globalization;
using System.Speech.Recognition;

namespace Kenku.MicrosoftTextToSpeech
{
    internal class MicrosoftSpeechToTextService : ISpeechToTextFactoryService
    {
        public ISpeechToTextWorker CreateWorker(Action<string> receiver)
        {
            return new SpeechToTextWorker(this.CreateRecognizer(), receiver);
        }

        private SpeechRecognitionEngine CreateRecognizer()
        {
#pragma warning disable CA1416 // Validate platform compatibility
            var output = new SpeechRecognitionEngine(new CultureInfo("en-US"));
            output.LoadGrammar(new DictationGrammar());
            output.SetInputToDefaultAudioDevice();
#pragma warning restore CA1416 // Validate platform compatibility
            return output;
        }
    }
}
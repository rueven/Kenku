using Kenku.Objects.Interfaces;
using Kenku.Services.Interfaces;
using Windows.Media.SpeechRecognition;

namespace Kenku.MicrosoftTextToSpeech
{
    public class WindowsMediaSpeechToTextService : ISpeechToTextFactoryService
    {
        public async Task<ISpeechToTextWorker> CreateWorker(Action<string> receiver)
        {
            var speechRecognizer = new SpeechRecognizer();
            await speechRecognizer
                .CompileConstraintsAsync();
            return new WindowsMediaSpeechToTextWorker(speechRecognizer, receiver);
        }
    }
}
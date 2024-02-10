using Kenku.Objects.Interfaces;
using Windows.Media.SpeechRecognition;

namespace Kenku.MicrosoftTextToSpeech
{
    public class WindowsMediaSpeechToTextWorker : ISpeechToTextWorker
    {
        internal WindowsMediaSpeechToTextWorker(SpeechRecognizer speechRecognizer, Action<string> receiver)
        {
            this.SpeechRecognizer = speechRecognizer;
            this.Receiver = receiver;
            speechRecognizer
                .ContinuousRecognitionSession
                .ResultGenerated += this.ContinuousRecognitionSession_ResultGenerated;
        }

        private SpeechRecognizer SpeechRecognizer { get; }
        private Action<string> Receiver { get; }

        private void ContinuousRecognitionSession_ResultGenerated(SpeechContinuousRecognitionSession sender, SpeechContinuousRecognitionResultGeneratedEventArgs args)
        {
            this.Receiver
                ?.Invoke(args.Result.Text);
        }

        public void Dispose()
        {
            this.SpeechRecognizer
                .ContinuousRecognitionSession
                .ResultGenerated -= this.ContinuousRecognitionSession_ResultGenerated;
            this.SpeechRecognizer
                ?.Dispose();
        }

        public async Task StartAsync() => await this
            .SpeechRecognizer
            .ContinuousRecognitionSession
            .StartAsync();

        public async Task StopAsync() => await this
            .SpeechRecognizer
            .ContinuousRecognitionSession
            .StopAsync();
    }
}
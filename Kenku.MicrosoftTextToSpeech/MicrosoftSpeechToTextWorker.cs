using Kenku.Objects.Interfaces;
using System.Speech.Recognition;

namespace Kenku.MicrosoftTextToSpeech
{
    internal class MicrosoftSpeechToTextWorker : ISpeechToTextWorker
    {
#pragma warning disable CA1416 // Validate platform compatibility
        public MicrosoftSpeechToTextWorker(SpeechRecognitionEngine recognizer, Action<string> receiver)
        {
            this.Recognizer = recognizer;
            this.Recognizer.SpeechRecognized += this.Recognizer_SpeechRecognized;
            this.Receiver = receiver;
        }

        public SpeechRecognitionEngine Recognizer { get; }
        public Action<string> Receiver { get; }

        public void Dispose()
        {
            this.Recognizer
                .RecognizeAsyncStop();
            this.Recognizer
                ?.Dispose();
        }

        public Task StartAsync()
        {
            this.Recognizer
                .RecognizeAsync(RecognizeMode.Multiple);
            return Task.CompletedTask;
        }

        public Task StopAsync()
        {
            this.Recognizer
                .RecognizeAsyncStop();
            return Task.CompletedTask;
        }

        private void Recognizer_SpeechRecognized(object? sender, SpeechRecognizedEventArgs e) => this
            .Receiver(e.Result.Text);
#pragma warning restore CA1416 // Validate platform compatibility
    }
}
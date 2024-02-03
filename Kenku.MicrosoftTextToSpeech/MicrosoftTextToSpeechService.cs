using Kenku.Extensions;
using Kenku.Services.Interfaces;
using System.Speech.Synthesis;

namespace Kenku.MicrosoftTextToSpeech
{
    internal class MicrosoftTextToSpeechService : ITextToSpeechService, IDisposable
    {
#pragma warning disable CA1416 // Validate platform compatibility
        public MicrosoftTextToSpeechService(SpeechSynthesizer synthesizer, InstalledVoice voice)
        {
            this.Synthesizer = synthesizer;
            this.InstalledVoice = voice;
            this.Name = $"Microsoft:{voice.VoiceInfo.Name}";
        }

        public SpeechSynthesizer Synthesizer { get; }
        public InstalledVoice InstalledVoice { get; }
        public string Name { get; }

        public void Dispose() => this
            .Synthesizer
            ?.Dispose();

        public async Task SpeakAsync(string value, params IOutputAudioDeviceService[] outputAudioDeviceService)
        {
            using (var stream = new MemoryStream())
            {
                this.Synthesizer
                    .SelectVoice(this.Name);
                this.Synthesizer
                    .SetOutputToWaveStream(stream);
                this.Synthesizer
                    .Speak(value);
                stream.Position = 0;
                await stream
                    .PlayWaveAsync(outputAudioDeviceService)
                    .ConfigureAwait(false);
            }
        }
#pragma warning restore CA1416 // Validate platform compatibility
    }
}
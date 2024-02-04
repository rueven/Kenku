using Google.Cloud.TextToSpeech.V1;
using Kenku.Extensions;
using Kenku.Services.Interfaces;

namespace Kenku.GoogleCloudVoice
{
    internal class GoogleCloudVoiceTextToSpeechService : ITextToSpeechService
    {
        public GoogleCloudVoiceTextToSpeechService(TextToSpeechClient client, Voice voice)
        {
            this.Client = client;
            this.Voice = voice;
            this.Name = $"Google:{voice.Name}";
        }

        protected Voice Voice { get; }
        protected TextToSpeechClient Client { get; }
        public string Name { get; }

        public async Task SpeakAsync(string value, CancellationToken cancellationToken, params IOutputAudioDeviceService[] outputAudioDeviceServices)
        {
            var response = await this
                .Client
                .SynthesizeSpeechAsync(new SynthesizeSpeechRequest()
                {
                    AudioConfig = GoogleCloudExtensions.DefaultAudioConfig,
                    Input = new SynthesisInput()
                    {
                        Text = value
                    },
                    Voice = new VoiceSelectionParams()
                    {
                        Name = this.Voice.Name,
                        LanguageCode = GoogleCloudExtensions.LanguageCode,
                        SsmlGender = SsmlVoiceGender.Male
                    }
                })
                .ConfigureAwait(false);
            using (var stream = new MemoryStream())
            {
                response
                    .AudioContent
                    .WriteTo(stream);
                stream.Position = 0;
                await stream
                    .PlayWaveAsync(cancellationToken, outputAudioDeviceServices)
                    .ConfigureAwait(false);
            }
        }
    }
}
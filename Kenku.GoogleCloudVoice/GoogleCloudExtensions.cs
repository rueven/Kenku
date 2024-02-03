using Google.Cloud.TextToSpeech.V1;
using Kenku.ServiceFactoryHelpers;

namespace Kenku.GoogleCloudVoice
{
    public static class GoogleCloudExtensions
    {
        public static async Task<IReadOnlyContainer> AddGoogleCloudVoiceTextToSpeechServices(this IReadOnlyContainer container, FileInfo googleApplicationCredentialsFile)
        {
            Environment
                .SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", googleApplicationCredentialsFile.FullName);
            var client = await TextToSpeechClient
                .CreateAsync();
            var result = client
                .ListVoices(new ListVoicesRequest()
                {
                    LanguageCode = GoogleCloudExtensions.LanguageCode
                });
            foreach (var voice in result.Voices)
            {
                container
                    .AddTextToSpeechService(new GoogleCloudVoiceTextToSpeechService(client, voice));
            }
            return container;
        }

        internal static AudioConfig DefaultAudioConfig { get; } = new AudioConfig()
        {
            AudioEncoding = AudioEncoding.Linear16,
            SampleRateHertz = 44100
        };

        internal const string LanguageCode = "en-US";
    }
}
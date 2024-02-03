using Kenku.Extensions;
using Kenku.Id3Tags;
using Kenku.WinformApplication.Services.Implementations;

namespace Kenku.WinformApplication
{
    internal static partial class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration
                .Initialize();

            var configurationFile = new FileInfo(Program.ConfigurationFilePath);
            if (!configurationFile.Exists)
            {
                Program.CreateDefaultConfigurationFile(configurationFile);
            }

            var configurationService = new FilePersistenceExtendedConfigurationService(configurationFile);

            var container = ServiceFactory
                .CreateContainer()
                .WithConfigurationService(configurationService)
                .WithDefaultSerializerService()
                .WithDefaultPersonalityService()
                .WithDefaultAudioResourceService()
                .WithId3TagVoiceRecordingService()
                .WithAllNAudioServices()
                .Build();

            container
                .AddKenkuTextToSpeechService();

            await Program
                .TryAddMicrosoftTextToSpeechServices(container, configurationService);
            await Program
                .TryAddEleventLabsTextToSpeechServicesAsync(container, configurationService);
            await Program
                .TryAddGoogleCloudVoiceTextToSpeechServices(container, configurationService);

            var session = await container
                .CreateSessionAsync();
            var speechToTextFactoryService = Program
                .CreateSpeechToTextFactory(container);

            Application.Run(new Main(session, speechToTextFactoryService));
        }
    }
}
using Kenku.ElevenLabs;
using Kenku.Extensions;
using Kenku.GoogleCloudVoice;
using Kenku.MicrosoftTextToSpeech;
using Kenku.ServiceFactoryHelpers;
using Kenku.Services.Interfaces;
using Kenku.WinformApplication.Services.Implementations;
using Kenku.WinformApplication.Services.Interfaces;
using Newtonsoft.Json;

namespace Kenku.WinformApplication
{
    partial class Program
    {
        static string RootPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Kenku\");
        static string ConfigurationFilePath = Path.Combine(RootPath, "Settings.json");
        static void CreateDefaultConfigurationFile(FileInfo file)
        {
            var defaultedConfigurationService = new ExtendedConfigurationService()
            {
                AssetDirectory = Path
                    .Combine(Program.RootPath, @"Assets"),
                MicrosoftTextToSpeechServicesEnabled = true
            };
            file.Directory
                !.Create();
            defaultedConfigurationService
                .GetAssetDirectory()
                .Create();
            defaultedConfigurationService
                .GetVoiceRecordingsDirectory()
                .Create();
            var content = JsonConvert
                .SerializeObject(defaultedConfigurationService, Formatting.Indented);
            File.WriteAllText(file.FullName, content);
        }

        static ISpeechToTextFactoryService? CreateSpeechToTextFactory(IReadOnlyContainer container)
        {
            try
            {
                return container
                    .CreateMicrosoftSpeechToTextFactoryService();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Could not load Microsoft SpeechToText service: {e.Message}");
                return null;
            }
        }

        static async Task TryAddGoogleCloudVoiceTextToSpeechServices(IReadOnlyContainer container, IExtendedConfigurationService configurationService)
        {
            if (!string.IsNullOrWhiteSpace(configurationService.GoogleCloudConfigurationFilePath))
            {
                var file = new FileInfo(configurationService.GoogleCloudConfigurationFilePath);
                if (file.Exists)
                {
                    try
                    {
                        await container
                            .AddGoogleCloudVoiceTextToSpeechServices(file);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Could not load GoogleCloud voices...\r\n{e.Message}");
                    }
                }
                else
                {
                    MessageBox.Show($"GoogleCloud Configuration File not found...\r\n{configurationService.GoogleCloudConfigurationFilePath}");
                }
            }
        }

        static async Task TryAddEleventLabsTextToSpeechServicesAsync(IReadOnlyContainer container, IExtendedConfigurationService configurationService)
        {
            if (!string.IsNullOrWhiteSpace(configurationService.ElevenLabsKey))
            {
                try
                {
                    await container
                        .AddEleventLabsTextToSpeechServicesAsync(configurationService.ElevenLabsKey);
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Could not load ElevenLabs voices..,\r\n{e.Message}");
                }
            }
        }

        static Task TryAddMicrosoftTextToSpeechServices(IReadOnlyContainer container, IExtendedConfigurationService configurationService)
        {
            if (configurationService.MicrosoftTextToSpeechServicesEnabled)
            {
                try
                {
                    container
                       .AddMicrosoftTextToSpeechServices();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Could not load Microsoft voices..,\r\n{e.Message}");
                }
            }
            return Task.CompletedTask;
        }
    }
}
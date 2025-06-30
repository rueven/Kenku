using Kenku.Extensions;
using Kenku.MauiApplication.Services.Implementations;
using Newtonsoft.Json;

namespace Kenku.MauiApplication.Helpers
{
    internal static class ConfigurationHelpers
    {
        static string RootPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Kenku\");
        static string ConfigurationFilePath = Path.Combine(RootPath, "Settings.json");

        static void CreateDefaultConfigurationFile(FileInfo file)
        {
            var defaultedConfigurationService = new ExtendedConfigurationService()
            {
                AssetDirectory = Path
                    .Combine(ConfigurationHelpers.RootPath, @"Assets"),
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

        public static FileInfo GetOrCreateConfigurationFile()
        {
            var output = new FileInfo(ConfigurationHelpers.ConfigurationFilePath);
            if (!output.Exists)
            {
                CreateDefaultConfigurationFile(output);
            }
            return output;
        }
    }
}
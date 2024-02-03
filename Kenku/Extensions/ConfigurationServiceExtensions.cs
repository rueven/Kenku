using Kenku.Helpers;
using Kenku.Services.Interfaces;

namespace Kenku.Extensions
{
    public static class ConfigurationServiceExtensions
    {
        public static DirectoryInfo? GetWorkingDirectory(this IConfigurationService configurationService)
        {
            var output = DirectoryHelper
                .GetWorkingDirectory();
            return output;
        }

        public static DirectoryInfo GetAssetDirectory(this IConfigurationService configurationService)
        {
            return new DirectoryInfo(configurationService.AssetDirectory);
        }

        public static DirectoryInfo GetVoiceRecordingsDirectory(this IConfigurationService configurationService)
        {
            var path = Path
                .Combine(configurationService.AssetDirectory, @$"VoiceRecordings");
            return new DirectoryInfo(path);
        }

        internal static FileInfo GetVoiceRecordingFile(this IConfigurationService configurationService)
        {
            var path = Path
                .Combine(configurationService.AssetDirectory, "VoiceRecordings.json");
            return new FileInfo(path);
        }

        internal static FileInfo GetPersonalityFile(this IConfigurationService configurationService)
        {
            var path = Path
                .Combine(configurationService.AssetDirectory, "Personalities.json");
            return new FileInfo(path);
        }

        public static FileInfo GetVoiceRecordingStreamFile(this IConfigurationService configurationService, Guid id)
        {
            var path = Path
                .Combine(configurationService.GetVoiceRecordingsDirectory().FullName, @$"{id}.mp3");
            return new FileInfo(path);
        }

        public static FileInfo GetEmptyVoiceRecordingStreamFile(this IConfigurationService configurationService)
        {
            return configurationService
                .GetVoiceRecordingStreamFile(Guid.Empty);
        }
    }
}
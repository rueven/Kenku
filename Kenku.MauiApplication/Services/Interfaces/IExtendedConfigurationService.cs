using Kenku.Services.Interfaces;

namespace Kenku.MauiApplication.Services.Interfaces
{
    internal interface IExtendedConfigurationService : IConfigurationService
    {
        string? ElevenLabsKey { get; set; }
        string? GoogleCloudConfigurationFilePath { get; set; }
        bool MicrosoftTextToSpeechServicesEnabled { get; set; }
        bool MicrosoftSpeechToTextServiceEnabled { get; set; }
        bool IsPushToTalkEmulationEnabled { get; set; }
        string? PushToTalkKey { get; set; }
    }
}
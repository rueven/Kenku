using Kenku.MauiApplication.Services.Interfaces;

namespace Kenku.MauiApplication.Services.Implementations
{
    internal class ExtendedConfigurationService : IExtendedConfigurationService
    {
        public required string AssetDirectory { get; set; }
        public string? OutputAudioDeviceServiceName { get; set; }
        public string? PreviewAudioDeviceServiceName { get; set; }
        public string? InputAudioDeviceServiceName { get; set; }
        public string? ElevenLabsKey { get; set; }
        public string? GoogleCloudConfigurationFilePath { get; set; }
        public bool IsMirroredPlaybackMode { get; set; }
        public bool MicrosoftTextToSpeechServicesEnabled { get; set; }
        public bool MicrosoftSpeechToTextServiceEnabled { get; set; }
        public bool IsPushToTalkEmulationEnabled { get; set; }
        public string? PushToTalkKey { get; set; }
        public bool UseForcedPreambleForTextToSpeech { get; set; }
        public bool UseForcedPreambleForVoiceRecordingPlayback { get; set; }
        public string? ForcedPreambleText { get; set; }
    }
}
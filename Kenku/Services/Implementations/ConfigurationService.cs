using Kenku.Services.Interfaces;

namespace Kenku.Services.Implementations
{
    internal class ConfigurationService : IConfigurationService
    {
        public required string AssetDirectory { get; set; }
        public bool IsMirroredPlaybackMode { get; set; }
        public string? OutputAudioDeviceServiceName { get; set; }
        public string? PreviewAudioDeviceServiceName { get; set; }
        public string? InputAudioDeviceServiceName { get; set; }
        public bool UseForcedPreambleForTextToSpeech { get; set; }
        public bool UseForcedPreambleForVoiceRecordingPlayback { get; set; }
        public string? ForcedPreambleText { get; set; }
    }
}
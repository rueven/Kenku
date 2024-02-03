namespace Kenku.Services.Interfaces
{
    public interface IConfigurationService
    {
        string AssetDirectory { get; set; }
        bool IsMirroredPlaybackMode { get; set; }
        string? OutputAudioDeviceServiceName { get; set; }
        string? PreviewAudioDeviceServiceName { get; set; }
        string? InputAudioDeviceServiceName { get; set; }
    }
}
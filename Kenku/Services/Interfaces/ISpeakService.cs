namespace Kenku.Services.Interfaces
{
    public interface ISpeakService
    {
        Task SpeakAsync(string value, CancellationToken cancellationToken, params IOutputAudioDeviceService[] outputAudioDeviceServices);
    }
}
namespace Kenku.Services.Interfaces
{
    public interface ISpeakService
    {
        Task SpeakAsync(string value, params IOutputAudioDeviceService[] outputAudioDeviceServices);
    }
}
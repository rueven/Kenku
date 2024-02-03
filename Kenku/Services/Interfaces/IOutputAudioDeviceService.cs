namespace Kenku.Services.Interfaces
{
    public interface IOutputAudioDeviceService : INamedService
    {
        Task PlayWaveAsync(Stream stream);

        Task PlayMp3Async(Stream stream);
    }
}
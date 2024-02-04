namespace Kenku.Services.Interfaces
{
    public interface IOutputAudioDeviceService : INamedService
    {
        Task PlayWaveAsync(Stream stream, CancellationToken cancellationToken);

        Task PlayMp3Async(Stream stream, CancellationToken cancellationToken);
    }
}
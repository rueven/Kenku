namespace Kenku.Objects.Interfaces
{
    public interface IAudioCaptureWorker : IDisposable
    {
        Task<Stream> StopAsync();
    }
}
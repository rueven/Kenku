namespace Kenku.Objects.Interfaces
{
    public interface ISpeechToTextWorker : IDisposable
    {
        Task StartAsync();
        Task StopAsync();
    }
}
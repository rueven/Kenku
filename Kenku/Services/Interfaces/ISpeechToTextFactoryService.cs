using Kenku.Objects.Interfaces;

namespace Kenku.Services.Interfaces
{
    public interface ISpeechToTextFactoryService
    {
        Task<ISpeechToTextWorker> CreateWorker(Action<string> receiver);
    }
}
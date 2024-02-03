using Kenku.Objects.Interfaces;

namespace Kenku.Services.Interfaces
{
    public interface ISpeechToTextFactoryService
    {
        ISpeechToTextWorker CreateWorker(Action<string> receiver);
    }
}
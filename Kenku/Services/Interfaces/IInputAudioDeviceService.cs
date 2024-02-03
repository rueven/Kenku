using Kenku.Objects.Interfaces;

namespace Kenku.Services.Interfaces
{
    public interface IInputAudioDeviceService : INamedService
    {
        Task<IAudioCaptureWorker> StartRecording();
    }
}
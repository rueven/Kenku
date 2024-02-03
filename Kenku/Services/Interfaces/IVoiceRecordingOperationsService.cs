using Kenku.Models.Interfaces;

namespace Kenku.Services.Interfaces
{
    public interface IVoiceRecordingOperationsService
    {
        Task TrimVoiceRecordingAsync(IReadOnlyVoiceRecording voiceRecording, TimeSpan start, TimeSpan? end = null);

        Task<Stream> TrimMp3Async(Stream stream, TimeSpan start, TimeSpan? end = null);
    }
}
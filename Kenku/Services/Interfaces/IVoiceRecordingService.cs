using Kenku.Models.Interfaces;

namespace Kenku.Services.Interfaces
{
    public interface IVoiceRecordingService : IIdentifiedItemStorageService<IReadOnlyVoiceRecording>
    {
        Task PlayAsync(IReadOnlyVoiceRecording voiceRecording, params IOutputAudioDeviceService[] outputAudioDeviceServices);
        Task SaveAsync(IReadOnlyVoiceRecording voiceRecording, Stream stream);
        Task<bool> UpdateVoiceRecordingPersonalityAsync(IReadOnlyVoiceRecording voiceRecording, IReadOnlyPersonality personality);
        Task<bool> DeleteAsync(IReadOnlyVoiceRecording voiceRecording);
    }
}
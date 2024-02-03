using Kenku.Models.Interfaces;
using Kenku.ServiceFactoryHelpers;
using Kenku.Services.Interfaces;

namespace Kenku.Objects.Interfaces
{
    public interface ISession
    {
        IReadOnlyContainer Container { get; }
        IReadOnlyList<ITextToSpeechService> TextToSpeechServices { get; }
        IReadOnlyList<ITextToSpeechService> FilteredTextToSpeechServices { get; set; }
        IReadOnlyList<IInputAudioDeviceService> InputAudioDeviceServices { get; }
        IReadOnlyList<IOutputAudioDeviceService> OutputAudioDeviceServices { get; }
        IReadOnlyList<IReadOnlyPersonality> Personalities { get; }
        IReadOnlyList<IReadOnlyVoiceRecording> VoiceRecordings { get; }

        Task RefreshAsync();

        IOutputAudioDeviceService OutputAudioDeviceService { get; set; }
        IOutputAudioDeviceService PreviewAudioDeviceService { get; set; }
        IInputAudioDeviceService InputAudioDeviceService { get; set; }
        ITextToSpeechService SimpleTextToSpeechService { get; set; }

        Task PlayTextToSpeechAsync(string text);
        Task PlayVoiceRecording(IReadOnlyVoiceRecording voiceRecording);
        Task PreviewVoiceRecording(IReadOnlyVoiceRecording voiceRecording);
        Task<bool> DeleteVoiceRecording(IReadOnlyVoiceRecording voiceRecording);
        Task<bool> UpdateVoiceRecordingPersonality(IReadOnlyVoiceRecording voiceRecording, IReadOnlyPersonality personality);

        
        Task<string> GetFullFilePath(IReadOnlyVoiceRecording voiceRecording);

        Task PreviewAsync(Stream stream);
        Task<IAudioCaptureWorker> StartRecordingAsync();
        Task SaveRecordingAsync(IReadOnlyPersonality personality, string text, Stream stream);
    }
}
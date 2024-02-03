using Kenku.Models.Implementations;
using Kenku.Models.Interfaces;
using Kenku.Objects.Interfaces;

namespace Kenku.Objects.Implementations
{
    partial class Session
    {
        async Task<IAudioCaptureWorker> ISession.StartRecordingAsync() => await this
            .InnerInputAudioDeviceService
            .StartRecording();

        async Task ISession.PreviewAsync(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            await this
                .PreviewAudioDeviceService
                .PlayMp3Async(stream);
        }

        async Task ISession.SaveRecordingAsync(IReadOnlyPersonality personality, string text, Stream stream)
        {
            await this
                .Container
                .VoiceRecordingService
                .SaveAsync(new VoiceRecording()
                {
                    Id = Guid.NewGuid(),
                    PersonalityId = personality.Id,
                    StreamType = Enums.StreamType.MP3,
                    Text = text
                }, stream);
        }
    }
}
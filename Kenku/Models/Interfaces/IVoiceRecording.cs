using Kenku.Enums;

namespace Kenku.Models.Interfaces
{
    public interface IReadOnlyVoiceRecording : IReadOnlyAudioResource
    {
        Guid PersonalityId { get; }
        string Text { get; }
    }
}
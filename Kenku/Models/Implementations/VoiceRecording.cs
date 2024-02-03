using Kenku.Enums;
using Kenku.Models.Interfaces;

namespace Kenku.Models.Implementations
{
    public class VoiceRecording : IReadOnlyVoiceRecording
    {
        public Guid PersonalityId { get; set; }
        public required string Text { get; set; }
        public Guid Id { get; set; }
        public StreamType StreamType { get; set; }
    }
}
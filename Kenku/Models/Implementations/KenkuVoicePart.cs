using Kenku.Models.Interfaces;

namespace Kenku.Models.Implementations
{
    internal class KenkuVoicePart : IReadOnlyKenkuVoicePart
    {
        public required string Text { get; set; }
        public IReadOnlyVoiceRecording? VoiceRecording { get; set; }
    }
}

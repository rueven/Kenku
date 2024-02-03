using Kenku.Models.Interfaces;
using System.Text.RegularExpressions;

namespace Kenku.Models.Implementations
{
    internal class KenkuVoiceRecordingData : IReadOnlyKenkuVoiceRecordingData
    {
        public required IReadOnlyDictionary<int, IReadOnlyVoiceRecording> VoiceRecordings { get; set; }
        public required Regex Pattern { get; set; }
    }
}
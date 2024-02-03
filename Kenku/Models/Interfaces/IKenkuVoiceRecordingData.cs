using System.Text.RegularExpressions;

namespace Kenku.Models.Interfaces
{
    internal interface IReadOnlyKenkuVoiceRecordingData
    {
        public IReadOnlyDictionary<int, IReadOnlyVoiceRecording> VoiceRecordings { get; }
        public Regex Pattern { get; }
    }
}
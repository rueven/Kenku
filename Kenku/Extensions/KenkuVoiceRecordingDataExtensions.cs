using Kenku.Models.Interfaces;

namespace Kenku.Extensions
{
    internal static class KenkuVoiceRecordingDataExtensions
    {
        public static IReadOnlyVoiceRecording? FindVoiceRecord(this IReadOnlyKenkuVoiceRecordingData data, int key)
        {
            if (data.VoiceRecordings.ContainsKey(key))
            {
                return data.VoiceRecordings[key];
            }
            return null;
        }
    }
}
using Kenku.Models.Interfaces;

namespace Kenku.Services.Interfaces
{
    public interface IKenkuVoiceTextParserService
    {
        void SetKenkuEmulationData(IReadOnlyList<IReadOnlyVoiceRecording> voiceRecordings);
        IReadOnlyList<IReadOnlyKenkuVoicePart> Parse(string value);
    }
}
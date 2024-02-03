namespace Kenku.Models.Interfaces
{
    public interface IReadOnlyKenkuVoicePart
    {
        string Text { get; }
        IReadOnlyVoiceRecording? VoiceRecording { get; }
    }
}
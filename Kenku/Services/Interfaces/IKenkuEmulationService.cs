namespace Kenku.Services.Interfaces
{
    public interface IKenkuEmulationService : ITextToSpeechService
    {
        IReadOnlyList<ITextToSpeechService> FilteredTextToSpeechServices { get; set; }
    }
}
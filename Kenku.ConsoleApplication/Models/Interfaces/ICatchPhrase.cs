namespace Kenku.ConsoleApplication.Models.Interfaces
{
    public interface IReadOnlyCatchPhrase
    {
        string Voice { get; }
        string Phrase { get; }
        IReadOnlyList<string> Tokens { get; }
    }
}
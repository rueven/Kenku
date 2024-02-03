using Kenku.ConsoleApplication.Models.Interfaces;

namespace Kenku.ConsoleApplication.Models.Implementations
{
    public class CatchPhrase : IReadOnlyCatchPhrase
    {
        public string Voice { get; set; }
        public string Phrase { get; set; }
        public List<string> Tokens { get; set; }
        IReadOnlyList<string> IReadOnlyCatchPhrase.Tokens => this.Tokens;
    }
}
using Kenku.Models.Interfaces;

namespace Kenku.Models.Implementations
{
    public class Personality : IReadOnlyPersonality
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public Guid Id { get; set; }
    }
}
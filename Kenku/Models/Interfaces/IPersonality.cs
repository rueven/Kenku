namespace Kenku.Models.Interfaces
{
    public interface IReadOnlyPersonality : IReadOnlyIdentifiedItem
    {
        string Name { get; }
        string Description { get; }
    }
}
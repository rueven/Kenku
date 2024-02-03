namespace Kenku.Models.Interfaces
{
    public interface ICacheKey
    {
        string Name { get; }
        int Version { get; }
    }
}
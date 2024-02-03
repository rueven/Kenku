using Kenku.Enums;

namespace Kenku.Models.Interfaces
{
    public interface IReadOnlyAudioResource : IReadOnlyIdentifiedItem
    {
        StreamType StreamType { get; }
    }
}
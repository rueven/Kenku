using Kenku.Models.Interfaces;

namespace Kenku.Services.Interfaces
{
    public interface IAudioResourceService
    {
        Task<Stream> FetchAsync(IReadOnlyAudioResource audioResource);

        Task SaveAsync(IReadOnlyAudioResource audioResource, Stream stream);

        Task<bool> DeleteAsync(IReadOnlyAudioResource audioResource);
    }
}
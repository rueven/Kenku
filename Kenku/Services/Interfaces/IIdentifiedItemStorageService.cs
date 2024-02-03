using Kenku.Models.Interfaces;

namespace Kenku.Services.Interfaces
{
    public interface IIdentifiedItemStorageService<T>
        where T : IReadOnlyIdentifiedItem
    {
        Task<T?> FetchByIdAsync(Guid id);
        Task<IReadOnlyList<T>> FetchAllAsync();
    }
}
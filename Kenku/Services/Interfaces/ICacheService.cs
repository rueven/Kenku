using Kenku.Models.Interfaces;

namespace Kenku.Services.Interfaces
{
    public interface ICacheService
    {
        ICacheKey CreateCacheKey(string name, int version);

        Task<T> GetValueAsync<T>(ICacheKey key, Func<Task<T>> generateValue);

        Task<T> GetValueAsync<T>(ICacheKey key, DateTime absoluteExpiration, Func<Task<T>> generateValue);

        Task<T> GetValueAsync<T>(ICacheKey key, TimeSpan slidingExpiration, Func<Task<T>> generateValue);
    }
}
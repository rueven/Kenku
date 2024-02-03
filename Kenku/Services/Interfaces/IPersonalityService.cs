using Kenku.Models.Interfaces;

namespace Kenku.Services.Interfaces
{
    public interface IPersonalityService : IIdentifiedItemStorageService<IReadOnlyPersonality>
    {
        Task<IReadOnlyPersonality> CreateNewPersonality(string name, string description);
    }
}
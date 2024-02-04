using Kenku.Extensions;
using Kenku.Models.Implementations;
using Kenku.Models.Interfaces;
using Kenku.Services.Interfaces;

namespace Kenku.Services.Implementations
{
    internal class PersonalityService : IPersonalityService
    {
        public PersonalityService(IConfigurationService configurationService, ISerializerService serializerService)
        {
            this.ConfigurationService = configurationService;
            this.SerializerService = serializerService;
        }

        protected IConfigurationService ConfigurationService { get; }
        protected ISerializerService SerializerService { get; }

        public async Task<IReadOnlyList<IReadOnlyPersonality>> FetchAllAsync() => await this
            .InnerFetchAllAsync(this.ConfigurationService.GetPersonalityFile(), true);

        private async Task<List<Personality>> InnerFetchAllAsync(FileInfo file, bool createDefaults = false)
        {
            if (!file.Exists)
            {
                if (!createDefaults)
                {
                    return new List<Personality>();
                }
                await this
                    .CreateNewPersonality(Guid.Empty, "Default", "The Default personality used by the system");
            }
            var content = await File
                .ReadAllTextAsync(file.FullName);
            if (string.IsNullOrWhiteSpace(content))
            {
                return new List<Personality>();
            }
            var result = this
                .SerializerService
                .Deserialize<List<Personality>>(content) ?? [];
            return result;
        }

        public async Task<IReadOnlyPersonality?> FetchByIdAsync(Guid id)
        {
            var items = await this
                .InnerFetchAllAsync(this.ConfigurationService.GetPersonalityFile());
            var output = items
                .FirstOrDefault(x => x.Id == id);
            return output;
        }

        public Task<IReadOnlyPersonality> CreateNewPersonality(string name, string description) => this
            .CreateNewPersonality(Guid.NewGuid(), name, description);

        private async Task<IReadOnlyPersonality> CreateNewPersonality(Guid id, string name, string description)
        {
            var file = this
                .ConfigurationService
                .GetPersonalityFile();
            var personalities = await this
                .InnerFetchAllAsync(file, false);
            var output = new Personality()
            {
                Id = id,
                Name = name,
                Description = description
            };
            personalities
                .Add(output);
            personalities
                .Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
            var json = this
                .SerializerService
                .Serialize(personalities);
            File.WriteAllText(file.FullName, json);
            return output;
        }

        public Task ReplaceAll(IReadOnlyList<IReadOnlyPersonality> replacements)
        {
            var file = this
                .ConfigurationService
                .GetPersonalityFile();
            var items = replacements
                .Select(x => x as Personality ?? new Personality()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList();
            items
                .Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
            var json = this
                .SerializerService
                .Serialize(items);
            File.WriteAllText(file.FullName, json);
            return Task.CompletedTask;
        }
    }
}
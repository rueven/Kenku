using Kenku.Services.Implementations;
using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    internal class KenkuBuilderSerializerService : IKenkuBuilderSerializerService
    {
        public required IConfigurationService ConfigurationService { get; set; }

        public IKenkuBuilderPersonalityService WithSerializerService(ISerializerService serializerService)
        {
            return new KenkuBuilderPersonalityService()
            {
                ConfigurationService = this.ConfigurationService,
                SerializerService = serializerService
            };
        }

        public IKenkuBuilderPersonalityService WithDefaultSerializerService()
        {
            return new KenkuBuilderPersonalityService()
            {
                ConfigurationService = this.ConfigurationService,
                SerializerService = new SerializerService()
            };
        }
    }
}
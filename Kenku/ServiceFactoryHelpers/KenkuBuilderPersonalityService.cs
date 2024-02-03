using Kenku.Services.Implementations;
using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    internal class KenkuBuilderPersonalityService : IKenkuBuilderPersonalityService
    {
        public required IConfigurationService ConfigurationService { get; set; }
        public required ISerializerService SerializerService { get; set; }

        public IKenkuBuilderAudioResourceService WithDefaultPersonalityService()
        {
            return new KenkuBuilderAudioResourceService()
            {
                ConfigurationService = this.ConfigurationService,
                PersonalityService = new PersonalityService
                (
                    this.ConfigurationService,
                    this.SerializerService
                ),
                SerializerService = this.SerializerService
            };
        }

        public IKenkuBuilderAudioResourceService WithPersonalityService(IPersonalityService personalityService)
        {
            return new KenkuBuilderAudioResourceService()
            {
                ConfigurationService = this.ConfigurationService,
                PersonalityService = personalityService,
                SerializerService = this.SerializerService
            };
        }
    }
}
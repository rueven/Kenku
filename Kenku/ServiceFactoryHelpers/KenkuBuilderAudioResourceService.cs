using Kenku.Services.Implementations;
using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    internal class KenkuBuilderAudioResourceService : IKenkuBuilderAudioResourceService
    {
        public required IConfigurationService ConfigurationService { get; set; }
        public required IPersonalityService PersonalityService { get; set; }
        public required ISerializerService SerializerService { get; set; }

        public IKenkuBuilderVoiceRecordingService WithDefaultAudioResourceService()
        {
            return new KenkuBuilderVoiceRecordingService()
            {
                AudioResourceService = new AudioResourceService
                (
                    this.ConfigurationService!
                ),
                ConfigurationService = this.ConfigurationService,
                PersonalityService = this.PersonalityService,
                SerializerService = this.SerializerService
            };
        }

        public IKenkuBuilderVoiceRecordingService WithAudioResourceService(IAudioResourceService audioResourceService)
        {
            return new KenkuBuilderVoiceRecordingService()
            {
                AudioResourceService = audioResourceService,
                ConfigurationService = this.ConfigurationService,
                PersonalityService = this.PersonalityService,
                SerializerService = this.SerializerService
            };
        }
    }
}
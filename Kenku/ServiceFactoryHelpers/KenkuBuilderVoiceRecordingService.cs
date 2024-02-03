using Kenku.Services.Implementations;
using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    internal class KenkuBuilderVoiceRecordingService : IKenkuBuilderVoiceRecordingService
    {
        public required IAudioResourceService AudioResourceService { get; set; }
        public required IConfigurationService ConfigurationService { get; set; }
        public required IPersonalityService PersonalityService { get; set; }
        public required ISerializerService SerializerService { get; set; }

        public IKenkuBuilderVoiceRecordingOperationsService WithDefaultVoiceRecordingService()
        {
            return new KenkuBuilderVoiceRecordingOperationsService()
            {
                AudioResourceService = this.AudioResourceService,
                ConfigurationService = this.ConfigurationService,
                PersonalityService = this.PersonalityService,
                SerializerService = this.SerializerService,
                VoiceRecordingService = new VoiceRecordingService
                (
                    this.AudioResourceService,
                    this.ConfigurationService,
                    this.SerializerService
                )
            };
        }

        public IKenkuBuilderVoiceRecordingOperationsService WithVoiceRecordingService(IVoiceRecordingService voiceRecordingService)
        {
            return new KenkuBuilderVoiceRecordingOperationsService()
            {
                AudioResourceService = this.AudioResourceService,
                ConfigurationService = this.ConfigurationService,
                PersonalityService = this.PersonalityService,
                SerializerService = this.SerializerService,
                VoiceRecordingService = voiceRecordingService
            };
        }
    }
}
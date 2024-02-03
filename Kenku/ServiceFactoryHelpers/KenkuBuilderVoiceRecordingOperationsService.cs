using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    internal class KenkuBuilderVoiceRecordingOperationsService : IKenkuBuilderVoiceRecordingOperationsService
    {
        public required IAudioResourceService AudioResourceService { get; set; }
        public required IConfigurationService ConfigurationService { get; set; }
        public required IPersonalityService PersonalityService { get; set; }
        public required ISerializerService SerializerService { get; set; }
        public required IVoiceRecordingService VoiceRecordingService { get; set; }

        public IKenkuBuilderInputAudioDevices WithVoiceRecordingOperationsService(IVoiceRecordingOperationsService voiceRecordingOperationsService)
        {
            return new KenkuBuilderInputAudioDevices()
            {
                AudioResourceService = this.AudioResourceService,
                ConfigurationService = this.ConfigurationService,
                PersonalityService = this.PersonalityService,
                SerializerService = this.SerializerService,
                VoiceRecordingOperationsService = voiceRecordingOperationsService,
                VoiceRecordingService = this.VoiceRecordingService
            };
        }
    }
}
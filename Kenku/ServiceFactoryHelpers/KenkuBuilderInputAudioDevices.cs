using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    internal class KenkuBuilderInputAudioDevices : IKenkuBuilderInputAudioDevices
    {
        public required IAudioResourceService AudioResourceService { get; set; }
        public required IConfigurationService ConfigurationService { get; set; }
        public required IPersonalityService PersonalityService { get; set; }
        public required ISerializerService SerializerService { get; set; }
        public required IVoiceRecordingService VoiceRecordingService { get; set; }
        public IVoiceRecordingOperationsService VoiceRecordingOperationsService { get; set; }

        public IKenkuBuilderOutputAudioDevices AddInputAudioDeviceServices(IReadOnlyList<IInputAudioDeviceService> inputAudioDeviceServices)
        {
            return new KenkuBuilderOutputAudioDevices()
            {
                AudioResourceService = this.AudioResourceService,
                ConfigurationService = this.ConfigurationService,
                InputAudioDeviceServices = inputAudioDeviceServices,
                PersonalityService = this.PersonalityService,
                SerializerService = this.SerializerService,
                VoiceRecordingOperationsService = this.VoiceRecordingOperationsService,
                VoiceRecordingService = this.VoiceRecordingService
            };
        }
    }
}
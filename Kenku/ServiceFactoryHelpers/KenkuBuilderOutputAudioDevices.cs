using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    internal class KenkuBuilderOutputAudioDevices : IKenkuBuilderOutputAudioDevices
    {
        public required IAudioResourceService AudioResourceService { get; set; }
        public required IConfigurationService ConfigurationService { get; set; }
        public required IPersonalityService PersonalityService { get; set; }
        public required ISerializerService SerializerService { get; set; }
        public required IReadOnlyList<IInputAudioDeviceService> InputAudioDeviceServices { get; set; }
        public required IVoiceRecordingService VoiceRecordingService { get; set; }
        public required IVoiceRecordingOperationsService VoiceRecordingOperationsService { get; set; }

        public IKenkuBuilderFinalizer AddOutputAudioDeviceServices(IReadOnlyList<IOutputAudioDeviceService> outputAudioDeviceServices)
        {
            return new KenkuBuilderFinalizer()
            {
                AudioResourceService = this.AudioResourceService,
                ConfigurationService = this.ConfigurationService,
                InputAudioDeviceServices = this.InputAudioDeviceServices,
                OutputAudioDeviceServices = outputAudioDeviceServices,
                PersonalityService = this.PersonalityService,
                SerializerService = this.SerializerService,
                VoiceRecordingOperationsService = this.VoiceRecordingOperationsService,
                VoiceRecordingService = this.VoiceRecordingService
            };
        }
    }
}
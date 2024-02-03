using Kenku.Services.Implementations;
using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    internal class KenkuBuilderFinalizer : IKenkuBuilderFinalizer
    {
        public required IAudioResourceService AudioResourceService { get; set; }
        public required IConfigurationService ConfigurationService { get; set; }
        public required IReadOnlyList<IInputAudioDeviceService> InputAudioDeviceServices { get; set; }
        public required IReadOnlyList<IOutputAudioDeviceService> OutputAudioDeviceServices { get; set; }
        public required IPersonalityService PersonalityService { get; set; }
        public required ISerializerService SerializerService { get; set; }
        public required IVoiceRecordingService VoiceRecordingService { get; set; }
        public required IVoiceRecordingOperationsService VoiceRecordingOperationsService { get; set; }

        public IReadOnlyContainer Build()
        {
            var textToSpeechServices = new List<ITextToSpeechService>();
            var kenkuVoiceTextParserService = new KenkuVoiceTextParserService();
            var kenkuEmulationService = new KenkuEmulationService
            (
                kenkuVoiceTextParserService,
                textToSpeechServices,
                this.VoiceRecordingService!
            );
            return new Container()
            {
                AudioResourceService = this.AudioResourceService,
                ConfigurationService = this.ConfigurationService,
                InputAudioDeviceServices = this.InputAudioDeviceServices,
                KenkuEmulationService = kenkuEmulationService,
                KenkuVoiceTextParserService = kenkuVoiceTextParserService,
                OutputAudioDeviceServices = this.OutputAudioDeviceServices,
                PersonalityService = this.PersonalityService,
                SerializerService = this.SerializerService,
                TextToSpeechServices = textToSpeechServices,
                VoiceRecordingOperationsService = this.VoiceRecordingOperationsService,
                VoiceRecordingService = this.VoiceRecordingService
            };
        }
    }
}
using Kenku.Objects.Interfaces;
using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    public interface IReadOnlyContainer
    {
        IAudioResourceService AudioResourceService { get; }
        IConfigurationService ConfigurationService { get; }
        IKenkuEmulationService KenkuEmulationService { get; }
        IKenkuVoiceTextParserService KenkuVoiceTextParserService { get; }
        IPersonalityService PersonalityService { get; }
        IReadOnlyList<IInputAudioDeviceService> InputAudioDeviceServices { get; }
        IReadOnlyList<IOutputAudioDeviceService> OutputAudioDeviceServices { get; }
        IReadOnlyList<ITextToSpeechService> TextToSpeechServices { get; }
        ISerializerService SerializerService { get; }
        IVoiceRecordingService VoiceRecordingService { get; }
        IVoiceRecordingOperationsService VoiceRecordingOperationsService { get; }

        IReadOnlyContainer AddTextToSpeechService(params ITextToSpeechService[] textToSpeechService);
        IReadOnlyContainer AddKenkuTextToSpeechService();

        Task<ISession> CreateSessionAsync();
    }
}
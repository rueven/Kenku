using Kenku.Services.Interfaces;

namespace Kenku.ServiceFactoryHelpers
{
    public interface IKenkuBuilderConfigurationService
    {
        IKenkuBuilderSerializerService WithConfigurationService(IConfigurationService configurationService);
        IKenkuBuilderSerializerService WithAssetDirectoryPath(DirectoryInfo directory);
    }

    public interface IKenkuBuilderSerializerService
    {
        IConfigurationService ConfigurationService { get; }
        IKenkuBuilderPersonalityService WithDefaultSerializerService();
        IKenkuBuilderPersonalityService WithSerializerService(ISerializerService serializerService);
    }

    public interface IKenkuBuilderPersonalityService
    {
        IConfigurationService ConfigurationService { get; }
        ISerializerService SerializerService { get; }
        IKenkuBuilderAudioResourceService WithDefaultPersonalityService();
        IKenkuBuilderAudioResourceService WithPersonalityService(IPersonalityService personalityService);
    }

    public interface IKenkuBuilderAudioResourceService
    {
        IConfigurationService ConfigurationService { get; }
        IPersonalityService PersonalityService { get; }
        ISerializerService SerializerService { get; }
        IKenkuBuilderVoiceRecordingService WithDefaultAudioResourceService();
        IKenkuBuilderVoiceRecordingService WithAudioResourceService(IAudioResourceService audioResourceService);
    }

    public interface IKenkuBuilderVoiceRecordingService
    {
        IAudioResourceService AudioResourceService { get; }
        IConfigurationService ConfigurationService { get; }
        IPersonalityService PersonalityService { get; }
        ISerializerService SerializerService { get; }
        IKenkuBuilderVoiceRecordingOperationsService WithDefaultVoiceRecordingService();
        IKenkuBuilderVoiceRecordingOperationsService WithVoiceRecordingService(IVoiceRecordingService voiceRecordingService);
    }

    public interface IKenkuBuilderVoiceRecordingOperationsService
    {
        IAudioResourceService AudioResourceService { get; }
        IConfigurationService ConfigurationService { get; }
        IPersonalityService PersonalityService { get; }
        ISerializerService SerializerService { get; }
        IVoiceRecordingService VoiceRecordingService { get; }
        IKenkuBuilderInputAudioDevices WithVoiceRecordingOperationsService(IVoiceRecordingOperationsService voiceRecordingOperationsService);
    }

    public interface IKenkuBuilderInputAudioDevices
    {
        IAudioResourceService AudioResourceService { get; }
        IConfigurationService ConfigurationService { get; }
        IPersonalityService PersonalityService { get; }
        ISerializerService SerializerService { get; }
        IVoiceRecordingService VoiceRecordingService { get; }
        IVoiceRecordingOperationsService VoiceRecordingOperationsService { get; }
        IKenkuBuilderOutputAudioDevices AddInputAudioDeviceServices(IReadOnlyList<IInputAudioDeviceService> inputAudioDeviceServices);
    }

    public interface IKenkuBuilderOutputAudioDevices
    {
        IAudioResourceService AudioResourceService { get; }
        IConfigurationService ConfigurationService { get; }
        IReadOnlyList<IInputAudioDeviceService> InputAudioDeviceServices { get; }
        IPersonalityService PersonalityService { get; }
        ISerializerService SerializerService { get; }
        IVoiceRecordingService VoiceRecordingService { get; }
        IVoiceRecordingOperationsService VoiceRecordingOperationsService { get; }
        IKenkuBuilderFinalizer AddOutputAudioDeviceServices(IReadOnlyList<IOutputAudioDeviceService> outputAudioDeviceServices);
    }

    public interface IKenkuBuilderFinalizer
    {
        IAudioResourceService AudioResourceService { get; }
        IConfigurationService ConfigurationService { get; }
        IReadOnlyList<IInputAudioDeviceService> InputAudioDeviceServices { get; }
        IReadOnlyList<IOutputAudioDeviceService> OutputAudioDeviceServices { get; }
        IPersonalityService PersonalityService { get; }
        ISerializerService SerializerService { get; }
        IVoiceRecordingService VoiceRecordingService { get; }
        IVoiceRecordingOperationsService VoiceRecordingOperationsService { get; }
        IReadOnlyContainer Build();
    }
}
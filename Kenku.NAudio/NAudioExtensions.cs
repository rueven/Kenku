using Kenku.ServiceFactoryHelpers;
using Kenku.Services.Implementations;
using Kenku.Services.Interfaces;
using NAudio.Wave;

namespace Kenku.Extensions
{
    public static class NAudioExtensions
    {
        public static IKenkuBuilderFinalizer WithAllNAudioServices(this IKenkuBuilderVoiceRecordingOperationsService builder)
        {
            return builder
                .WithNAudioVoiceOperationsService()
                .AddInputAudioDeviceServicesFromNAudio()
                .AddOutputAudioDeviceServicesFromNAudio();
        }

        public static IKenkuBuilderInputAudioDevices WithNAudioVoiceOperationsService(this IKenkuBuilderVoiceRecordingOperationsService builder)
        {
            return builder
                .WithVoiceRecordingOperationsService(new NAudioVoiceRecordingOperationService
                (
                    builder.AudioResourceService,
                    builder.VoiceRecordingService
                ));
        }

        public static IKenkuBuilderOutputAudioDevices AddInputAudioDeviceServicesFromNAudio(this IKenkuBuilderInputAudioDevices builder)
        {
            return builder
                .AddInputAudioDeviceServices(new List<IInputAudioDeviceService>()
                {
                    new NAudioInputAudioDeviceService(true, builder.ConfigurationService),
                    new NAudioInputAudioDeviceService(false, builder.ConfigurationService)
                });
        }

        public static IKenkuBuilderFinalizer AddOutputAudioDeviceServicesFromNAudio(this IKenkuBuilderOutputAudioDevices builder)
        {
            var output = new List<IOutputAudioDeviceService>();
            for (var i = 0; i < WaveOut.DeviceCount; i++)
            {
                var waveOutCapabilities = WaveOut
                    .GetCapabilities(i);
                output.Add(new NAudioOutputAudioDeviceService(waveOutCapabilities.ProductName, i));
            }
            return builder
                .AddOutputAudioDeviceServices(output);
        }
    }
}
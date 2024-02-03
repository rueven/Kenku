using Kenku.Extensions;
using Kenku.Objects.Implementations;
using Kenku.Objects.Interfaces;
using Kenku.Services.Interfaces;
using NAudio.Lame;
using NAudio.Wave;

namespace Kenku.Services.Implementations
{
    internal class NAudioInputAudioDeviceService : IInputAudioDeviceService
    {
        public NAudioInputAudioDeviceService(bool isLineIn, IConfigurationService configurationService)
        {
            this.IsLineIn = isLineIn;
            this.Name = isLineIn ? "NAudio Line-In" : "NAudio Line-Out";
            this.ConfigurationService = configurationService;
        }

        public string Name { get; }
        public bool IsLineIn { get; }
        public IConfigurationService ConfigurationService { get; }

        public Task<IAudioCaptureWorker> StartRecording()
        {
            var file = this
                .ConfigurationService
                .GetEmptyVoiceRecordingStreamFile();
            IWaveIn capture = this.IsLineIn ? new WaveInEvent() : new WasapiLoopbackCapture();
            if (this.IsLineIn)
            {
                capture.WaveFormat = new WaveFormat(8000, 16, 1);
            }
            var writer = new LameMP3FileWriter(file.FullName, capture.WaveFormat, 128);
            var output = new NAudioAudioCaptureWorker(capture, writer, file);
            capture.StartRecording();
            return Task.FromResult<IAudioCaptureWorker>(output);
        }
    }
}
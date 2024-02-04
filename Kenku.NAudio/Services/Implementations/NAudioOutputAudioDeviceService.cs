using Kenku.Services.Interfaces;
using NAudio.Wave;

namespace Kenku.Services.Implementations
{
    internal class NAudioOutputAudioDeviceService : IOutputAudioDeviceService
    {
        public NAudioOutputAudioDeviceService(string name, int index)
        {
            Name = name;
            Index = index;
        }

        public string Name { get; }
        private int Index { get; }

        public async Task PlayWaveAsync(Stream stream, CancellationToken cancellationToken)
        {
            var position = stream.Position;
            using var wave = new WaveFileReader(stream);
            using var player = new WaveOutEvent { DeviceNumber = Index };
            player.Init(wave);
            player.Play();
            while (player.PlaybackState == PlaybackState.Playing)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    player.Stop();
                    break;
                }
                await Task.Delay(100);
            }
            stream.Seek(position, SeekOrigin.Current);
        }

        public async Task PlayMp3Async(Stream stream, CancellationToken cancellationToken)
        {
            var position = stream.Position;
            using var reader = new Mp3FileReader(stream);
            using var converter = WaveFormatConversionStream.CreatePcmStream(reader);
            using var waveStream = new MemoryStream();
            using var player = new WaveOutEvent { DeviceNumber = Index };
            WaveFileWriter.WriteWavFileToStream(waveStream, converter);
            waveStream.Position = 0;
            using var wave = new WaveFileReader(waveStream);
            player.Init(wave);
            player.Play();
            while (player.PlaybackState == PlaybackState.Playing)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    player.Stop();
                    break;
                }
                await Task.Delay(100);
            }
            stream.Seek(position, SeekOrigin.Current);
        }
    }
}
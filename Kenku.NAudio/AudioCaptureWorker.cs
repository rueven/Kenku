using Kenku.Objects.Interfaces;
using NAudio.Lame;
using NAudio.Wave;

namespace Kenku.Objects.Implementations
{
    internal class NAudioAudioCaptureWorker : IAudioCaptureWorker
    {
        public NAudioAudioCaptureWorker(IWaveIn waveIn, LameMP3FileWriter writer, FileInfo file)
        {
            this.WaveIn = waveIn;
            this.Writer = writer;
            this.CaptureFile = file;
            this.WaveIn.DataAvailable += this.DataAvailable;
            this.WaveIn.RecordingStopped += this.RecordingStopped;
        }

        private IWaveIn WaveIn { get; set; }
        private LameMP3FileWriter Writer { get; set; }
        private FileInfo CaptureFile { get; set; }
        private Stream? Output { get; set; }

        public void Dispose()
        {
            this.WaveIn.DataAvailable -= this.DataAvailable;
            this.WaveIn.RecordingStopped -= this.RecordingStopped;
            this.WaveIn.Dispose();
            this.Writer.Dispose();
        }

        public async Task<Stream> StopAsync()
        {
            this.WaveIn
                .StopRecording();
            while (this.Output == null)
            {
                await Task
                    .Delay(100)
                    .ConfigureAwait(false);
            }
            return this.Output;
        }

        private void RecordingStopped(object? sender, StoppedEventArgs e)
        {
            this.Writer.Close();
            this.Writer.Dispose();
            this.WaveIn.DataAvailable -= this.DataAvailable;
            this.WaveIn.RecordingStopped -= this.RecordingStopped;
            this.WaveIn.Dispose();
            var bytes = File
                .ReadAllBytes(this.CaptureFile.FullName);
            this.Output = new MemoryStream(bytes);
            this.CaptureFile.Delete();
        }

        private void DataAvailable(object? sender, WaveInEventArgs args) => this
            .Writer
            .Write(args.Buffer, 0, args.BytesRecorded);
    }
}
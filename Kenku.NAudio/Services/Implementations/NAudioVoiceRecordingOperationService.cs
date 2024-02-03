using Kenku.Models.Interfaces;
using Kenku.Services.Interfaces;
using NAudio.Wave;

namespace Kenku.Services.Implementations
{
    internal class NAudioVoiceRecordingOperationService : IVoiceRecordingOperationsService
    {
        public NAudioVoiceRecordingOperationService(IAudioResourceService audioResourceService, IVoiceRecordingService voiceRecordingService)
        {
            this.AudioResourceService = audioResourceService;
            this.VoiceRecordingService = voiceRecordingService;
        }

        protected IVoiceRecordingService VoiceRecordingService { get; }
        protected IAudioResourceService AudioResourceService { get; }

        public async Task TrimVoiceRecordingAsync(IReadOnlyVoiceRecording voiceRecording, TimeSpan start, TimeSpan? end = null)
        {
            using (var stream = await this.AudioResourceService.FetchAsync(voiceRecording))
            using (var newStream = await this.TrimMp3Async(stream, start, end))
            {
                await this
                    .VoiceRecordingService
                    .SaveAsync(voiceRecording, newStream);
            }
        }

        public async Task<Stream> TrimMp3Async(Stream inputStream, TimeSpan start, TimeSpan? end = null)
        {
            if (end.HasValue && start > end)
            {
                throw new ArgumentOutOfRangeException("end", "end should be greater than begin");
            }
            using (var reader = new Mp3FileReader(inputStream))
            {
                var outputStream = new MemoryStream();
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (reader.CurrentTime >= start || !end.HasValue)
                    {
                        if (reader.CurrentTime <= end || !end.HasValue)
                        {
                            await outputStream
                                .WriteAsync(frame.RawData, 0, frame.RawData.Length);
                        }
                        else { break; }
                    }
                }
                await outputStream
                    .FlushAsync();
                outputStream.Position = 0;
                return outputStream;
            }
        }
    }
}
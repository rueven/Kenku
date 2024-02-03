using Kenku.Services.Interfaces;

namespace Kenku.Extensions
{
    public static class StreamExtensions
    {
        public static async Task<Stream> CloneAsync(this Stream stream)
        {
            var output = new MemoryStream();
            await stream.CopyToAsync(output);
            stream.Seek(0, SeekOrigin.Begin);
            return output;
        }

        private static async Task PlayAsync(this Stream stream, Func<IOutputAudioDeviceService, Func<Stream, Task>> methodSelector, IOutputAudioDeviceService[] outputAudioDeviceServices)
        {
            var streamCloneTasks = outputAudioDeviceServices
                .Distinct()
                .Select(async service => new
                {
                    Service = service,
                    Stream = await stream
                        .CloneAsync()
                        .ConfigureAwait(false)
                })
                .ToList();
            await Task
                .WhenAll(streamCloneTasks)
                .ConfigureAwait(false);
            var playTasks = streamCloneTasks
                .Select(async task =>
                {
                    using (task.Result.Stream)
                    {
                        task.Result
                            .Stream
                            .Seek(0, SeekOrigin.Begin);
                        var method = methodSelector
                            .Invoke(task.Result.Service);
                        await method(task.Result.Stream)
                            .ConfigureAwait(false);
                    }
                })
                .ToList();
            await Task
                .WhenAll(playTasks)
                .ConfigureAwait(false);
        }

        public static Task PlayWaveAsync(this Stream stream, IOutputAudioDeviceService[] outputAudioDeviceServices) => stream
            .PlayAsync(x => x.PlayWaveAsync, outputAudioDeviceServices);

        public static Task PlayMp3Async(this Stream stream, IOutputAudioDeviceService[] outputAudioDeviceServices) => stream
            .PlayAsync(x => x.PlayMp3Async, outputAudioDeviceServices);
    }
}
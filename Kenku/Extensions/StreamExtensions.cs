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

        private static async Task PlayAsync(this Stream stream, CancellationToken cancellationToken, Func<IOutputAudioDeviceService, Func<Stream, CancellationToken, Task>> methodSelector, IOutputAudioDeviceService[] outputAudioDeviceServices)
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
                        await method(task.Result.Stream, cancellationToken)
                            .ConfigureAwait(false);
                    }
                })
                .ToList();
            await Task
                .WhenAll(playTasks)
                .ConfigureAwait(false);
        }

        public static Task PlayWaveAsync(this Stream stream, CancellationToken cancellationToken, IOutputAudioDeviceService[] outputAudioDeviceServices) => stream
            .PlayAsync(cancellationToken, x => x.PlayWaveAsync, outputAudioDeviceServices);

        public static Task PlayMp3Async(this Stream stream, CancellationToken cancellationToken, IOutputAudioDeviceService[] outputAudioDeviceServices) => stream
            .PlayAsync(cancellationToken, x => x.PlayMp3Async, outputAudioDeviceServices);
    }
}
using Kenku.Extensions;
using Kenku.Models.Interfaces;
using Kenku.Services.Interfaces;

namespace Kenku.Services.Implementations
{
    internal class AudioResourceService : IAudioResourceService
    {
        public AudioResourceService(IConfigurationService configurationService)
        {
            this.ConfigurationService = configurationService;
        }

        protected IConfigurationService ConfigurationService { get; }

        public Task<bool> DeleteAsync(IReadOnlyAudioResource audioResource)
        {
            var file = this
                .ConfigurationService
                .GetVoiceRecordingStreamFile(audioResource.Id);
            if (file.Exists)
            {
                try
                {
                    file.Delete();
                    return Task.FromResult(true);
                }
                catch { return Task.FromResult(false); }
            }
            return Task.FromResult(false);
        }

        public Task<Stream> FetchAsync(IReadOnlyAudioResource audioResource)
        {
            var file = this
                .ConfigurationService
                .GetVoiceRecordingStreamFile(audioResource.Id);
            if (!file.Exists)
            {
                throw new FileNotFoundException("File not found.", file.FullName);
            }
            var output = new MemoryStream();
            using (var reader = file.OpenRead())
            {
                reader.CopyTo(output);
            }
            output.Seek(0, SeekOrigin.Begin);
            return Task
                .FromResult<Stream>(output);
        }

        public async Task SaveAsync(IReadOnlyAudioResource audioResource, Stream stream)
        {
            var file = this
                .ConfigurationService
                .GetVoiceRecordingStreamFile(audioResource.Id);
            using (var writer = new StreamWriter(file.FullName))
            {
                await stream.CopyToAsync(writer.BaseStream);
                writer.Close();
            }
        }
    }
}
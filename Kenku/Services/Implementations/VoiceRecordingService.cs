using Kenku.Extensions;
using Kenku.Models.Implementations;
using Kenku.Models.Interfaces;
using Kenku.Services.Interfaces;
using System.IO;

namespace Kenku.Services.Implementations
{
    internal class VoiceRecordingService : IVoiceRecordingService
    {
        public VoiceRecordingService(IAudioResourceService audioResourceService, IConfigurationService configurationService, ISerializerService serializerService)
        {
            this.AudioResourceService = audioResourceService;
            this.ConfigurationService = configurationService;
            this.SerializerService = serializerService;
        }

        protected IAudioResourceService AudioResourceService { get; }
        protected IConfigurationService ConfigurationService { get; }
        protected ISerializerService SerializerService { get; }

        public async Task<IReadOnlyList<IReadOnlyVoiceRecording>> FetchAllAsync() => await this
            .InnerFetchAllAsync(this.ConfigurationService.GetVoiceRecordingFile())
            .ConfigureAwait(false);

        private async Task<List<VoiceRecording>> InnerFetchAllAsync(FileInfo file)
        {
            if (!file.Exists)
            {
                return new List<VoiceRecording>();
            }
            var content = await File
                .ReadAllTextAsync(file.FullName)
                .ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(content))
            {
                return new List<VoiceRecording>();
            }
            var result = this
                .SerializerService
                .Deserialize<List<VoiceRecording>>(content) ?? [];
            return result;
        }

        public async Task<IReadOnlyVoiceRecording?> FetchByIdAsync(Guid id)
        {
            var items = await this
                .InnerFetchAllAsync(this.ConfigurationService.GetVoiceRecordingFile());
            var output = items
                .FirstOrDefault(x => x.Id == id);
            return output;
        }

        public async Task PlayAsync(IReadOnlyVoiceRecording voiceRecording, params IOutputAudioDeviceService[] outputAudioDeviceServices)
        {
            var stream = await this
                .AudioResourceService
                .FetchAsync(voiceRecording)
                .ConfigureAwait(false);
            switch (voiceRecording.StreamType)
            {
                case Enums.StreamType.Wave:
                    await stream
                        .PlayWaveAsync(outputAudioDeviceServices)
                        .ConfigureAwait(false);
                    break;
                case Enums.StreamType.MP3:
                    await stream
                        .PlayMp3Async(outputAudioDeviceServices)
                        .ConfigureAwait(false);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public async Task SaveAsync(IReadOnlyVoiceRecording voiceRecording, Stream stream)
        {
            var file = this
                .ConfigurationService
                .GetVoiceRecordingFile();
            var voiceRecordings = await this
                .InnerFetchAllAsync(file)
                .ConfigureAwait(false);
            voiceRecordings.Add(new VoiceRecording()
            {
                Id = voiceRecording.Id,
                PersonalityId = voiceRecording.PersonalityId,
                StreamType = voiceRecording.StreamType,
                Text = voiceRecording.Text
            });
            voiceRecordings
                .Sort((x, y) => string.Compare(x.Text, y.Text, StringComparison.OrdinalIgnoreCase));
            var json = this
                .SerializerService
                .Serialize(voiceRecordings);
            await File
                .WriteAllTextAsync(file.FullName, json)
                .ConfigureAwait(false);
            await this
                .AudioResourceService
                .SaveAsync(voiceRecording, stream)
                .ConfigureAwait(false);
        }

        public async Task<bool> UpdateVoiceRecordingPersonalityAsync(IReadOnlyVoiceRecording voiceRecording, IReadOnlyPersonality personality)
        {
            try
            {
                var file = this
                    .ConfigurationService
                    .GetVoiceRecordingFile();
                var voiceRecordings = await this
                    .InnerFetchAllAsync(file)
                    .ConfigureAwait(false);
                var match = voiceRecordings
                    .FirstOrDefault(x => x.Id == voiceRecording.Id);
                if (match == null)
                {
                    return false;
                }
                match.PersonalityId = personality.Id;
                voiceRecordings
                    .Sort((x, y) => string.Compare(x.Text, y.Text, StringComparison.OrdinalIgnoreCase));
                var json = this
                    .SerializerService
                    .Serialize(voiceRecordings);
                await File
                    .WriteAllTextAsync(file.FullName, json)
                    .ConfigureAwait(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(IReadOnlyVoiceRecording voiceRecording)
        {
            try
            {
                var file = this
                    .ConfigurationService
                    .GetVoiceRecordingFile();
                var voiceRecordings = await this
                    .InnerFetchAllAsync(file)
                    .ConfigureAwait(false);
                var match = voiceRecordings
                    .FirstOrDefault(x => x.Id == voiceRecording.Id);
                if (match == null)
                {
                    voiceRecordings
                        .Remove(match!);
                }
                voiceRecordings
                    .Sort((x, y) => string.Compare(x.Text, y.Text, StringComparison.OrdinalIgnoreCase));
                var json = this
                    .SerializerService
                    .Serialize(voiceRecordings);
                await File
                    .WriteAllTextAsync(file.FullName, json)
                    .ConfigureAwait(false);
                return await this
                    .AudioResourceService
                    .DeleteAsync(voiceRecording)
                    .ConfigureAwait(false);
            }
            catch
            {
                return false;
            }
        }
    }
}
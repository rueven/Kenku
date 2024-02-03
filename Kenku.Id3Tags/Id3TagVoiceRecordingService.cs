using Id3;
using Kenku.Extensions;
using Kenku.Models.Implementations;
using Kenku.Models.Interfaces;
using Kenku.Services.Interfaces;

namespace Kenku.Services.Implementations
{
    public class Id3TagVoiceRecordingService : IVoiceRecordingService
    {
        public Id3TagVoiceRecordingService(IAudioResourceService audioResourceService, IConfigurationService configurationService)
        {
            this.AudioResourceService = audioResourceService;
            this.ConfigurationService = configurationService;
        }

        protected IAudioResourceService AudioResourceService { get; }
        protected IConfigurationService ConfigurationService { get; }

        public Task<IReadOnlyList<IReadOnlyVoiceRecording>> FetchAllAsync()
        {
            var files = this
                .ConfigurationService
                .GetVoiceRecordingsDirectory()
                .GetFiles("*.mp3");
            var output = new List<IReadOnlyVoiceRecording>();
            foreach (var file in files)
            {
                var recording = Id3TagVoiceRecordingService
                    .CreateFrom(file);
                if (recording != null)
                {
                    output.Add(recording);
                }
            }
            return Task
                .FromResult<IReadOnlyList<IReadOnlyVoiceRecording>>(output);
        }

        public Task<IReadOnlyVoiceRecording?> FetchByIdAsync(Guid id)
        {
            var file = this
                .ConfigurationService
                .GetVoiceRecordingStreamFile(id);
            var output = Id3TagVoiceRecordingService
                .CreateFrom(file);
            return Task
                .FromResult<IReadOnlyVoiceRecording?>(output);
        }

        public async Task PlayAsync(IReadOnlyVoiceRecording recording, params IOutputAudioDeviceService[] outputAudioDeviceServices)
        {
            var stream = await this
                .AudioResourceService
                .FetchAsync(recording)
                .ConfigureAwait(false);
            using (stream)
            {
                switch (recording.StreamType)
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
        }

        private static VoiceRecording? CreateFrom(FileInfo file)
        {
            if (!file.Exists)
            {
                return null;
            }
            if (Guid.TryParse(Path.GetFileNameWithoutExtension(file.Name), out var id) && id != Guid.Empty)
            {
                using var mp3 = new Mp3File(file);
                var tag = mp3.GetTag(Id3TagFamily.Version2x);
                var output = new VoiceRecording()
                {
                    Id = id,
                    StreamType = Enums.StreamType.MP3,
                    Text = tag.Title.Value ?? file.Name,
                    PersonalityId = Guid.TryParse(tag.Conductor.Value, out var personalityId) ? personalityId : Guid.Empty
                };
                return output;
            }
            return null;
        }

        public async Task SaveAsync(IReadOnlyVoiceRecording voiceRecording, Stream stream)
        {
            var file = this
                .ConfigurationService
                .GetVoiceRecordingStreamFile(voiceRecording.Id);
            if (file.Exists)
            {
                Id3Tag tag;
                using (var mp3 = new Mp3File(file, Mp3Permissions.ReadWrite))
                {
                    tag = mp3.GetTag(Id3TagFamily.Version2x) ?? new Id3Tag();
                }
                tag.Title.Value = voiceRecording.Text;
                tag.Conductor.Value = voiceRecording.PersonalityId.ToString();
                using (var writer = new FileStream(file.FullName, FileMode.Create))
                {
                    await stream
                        .CopyToAsync(writer)
                        .ConfigureAwait(false);
                    stream.Close();
                }
                using (var mp3 = new Mp3File(file, Mp3Permissions.ReadWrite))
                {
                    mp3.WriteTag(tag, 2, 3, WriteConflictAction.Replace);
                }
            }
            else
            {
                using (var writer = new FileStream(file.FullName, FileMode.Create))
                {
                    await stream
                        .CopyToAsync(writer)
                        .ConfigureAwait(false);
                    stream.Close();
                }
                using var mp3 = new Mp3File(file, Mp3Permissions.ReadWrite);
                var tag = mp3.GetTag(Id3TagFamily.Version2x) ?? new Id3Tag();
                tag.Title.Value = voiceRecording.Text;
                tag.Conductor.Value = voiceRecording.PersonalityId.ToString();
                mp3.WriteTag(tag, 2, 3, WriteConflictAction.Replace);
            }
        }

        public Task<bool> UpdateVoiceRecordingPersonalityAsync(IReadOnlyVoiceRecording voiceRecording, IReadOnlyPersonality personality)
        {
            var file = this
                .ConfigurationService
                .GetVoiceRecordingStreamFile(voiceRecording.Id);
            if (!file.Exists)
            {
                return Task.FromResult(false);
            }
            try
            {
                using var mp3 = new Mp3File(file, Mp3Permissions.ReadWrite);
                var tag = mp3.GetTag(Id3TagFamily.Version2x);
                tag.Conductor.Value = personality.Id.ToString();
                mp3.WriteTag(tag, WriteConflictAction.Replace);
                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> DeleteAsync(IReadOnlyVoiceRecording voiceRecording)
        {
            var file = this
                .ConfigurationService
                .GetVoiceRecordingStreamFile(voiceRecording.Id);
            if (file.Exists)
            {
                try { file.Delete(); }
                catch { return Task.FromResult(false); }
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
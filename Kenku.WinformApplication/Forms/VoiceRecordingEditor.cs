using Kenku.Models.Implementations;
using Kenku.Objects.Interfaces;

namespace Kenku.WinformApplication.Forms
{
    public partial class VoiceRecordingEditor : Form
    {
        public VoiceRecordingEditor() { InitializeComponent(); }
        public VoiceRecordingEditor(ISession session, VoiceRecording voiceRecording, Stream stream) : this()
        {
            this.Session = session;
            this.VoiceRecording = voiceRecording;
            var personality = session
                .Personalities
                .FirstOrDefault(x => x.Id == voiceRecording.PersonalityId);
            this.RecordingControl
                .Initialize
                (
                    session.Container.VoiceRecordingOperationsService,
                    session.Personalities,
                    async stream => await this.Session.PreviewAsync(stream),
                    async (personality, text, stream, asNew) =>
                    {
                        if (asNew)
                        {
                            this.VoiceRecording.Id = Guid.NewGuid();
                        }
                        this.VoiceRecording.Text = text;
                        this.VoiceRecording.PersonalityId = personality.Id;
                        await this
                            .Session
                            .Container
                            .VoiceRecordingService
                            .SaveAsync(voiceRecording, stream);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                )
                .Bind(session.Personalities, personality)
                .Bind(stream)
                .Bind(voiceRecording.Text);
        }

        private ISession Session { get; }
        private VoiceRecording VoiceRecording { get; }
    }
}
using Kenku.Models.Interfaces;
using Kenku.Services.Interfaces;
using Kenku.WinformApplication.Extensions;
using NAudio.Wave;

namespace Kenku.WinformApplication.Controls
{
    public interface IRecordControl
    {
        IRecordControl Initialize(IVoiceRecordingOperationsService voiceRecordingOperationsService, IReadOnlyList<IReadOnlyPersonality> personalities, Func<Stream, Task> onPreview, Func<IReadOnlyPersonality, string, Stream, bool, Task> onSave);
        IRecordControl Bind(IReadOnlyList<IReadOnlyPersonality> personalities, IReadOnlyPersonality? personality = null);
        IRecordControl Bind(Stream stream);
        IRecordControl Bind(string defaultText);
        IRecordControl Reset();
    }

    public partial class RecordingControl : UserControl, IRecordControl
    {
        public RecordingControl() { InitializeComponent(); }

        protected Func<Stream, Task> OnPreview { get; private set; }
        protected Func<IReadOnlyPersonality, string, Stream, bool, Task> OnSave { get; private set; }
        protected IVoiceRecordingOperationsService VoiceRecordingOperationsService { get; private set; }
        protected Stream? OriginalCapturedAudio { get; private set; }

        private async Task<Stream?> CreateCroppedStream()
        {
            if (this.OriginalCapturedAudio != null)
            {
                this.OriginalCapturedAudio.Seek(0, SeekOrigin.Begin);
                var output = await this
                    .VoiceRecordingOperationsService
                    .TrimMp3Async(this.OriginalCapturedAudio, this.SnippetWaveViewer.SelectionStartTimeSpan, this.SnippetWaveViewer.SelectionEndTimeSpan);
                return output;
            }
            return null;
        }

        private async void PreviewCommand_Click(object sender, EventArgs e)
        {
            using var stream = await this.CreateCroppedStream();
            if (stream != null && this.OnPreview != null)
            {
                await this
                    .OnPreview(stream);
            }
        }

        private async void SaveCommand_Click(object sender, EventArgs e)
        {
            this.SaveCommand.Enabled = false;
            this.SaveNewCommand.Enabled = false;
            this.PreviewCommand.Enabled = false;
            using var stream = await this.CreateCroppedStream();
            if (stream != null && this.SnippetPersonality.SelectedItem is IReadOnlyPersonality personality && this.OnSave != null)
            {
                await this
                    .OnSave(personality, this.SnippetText.Text, stream, false);
            }
        }

        private async void SaveNewCommand_Click(object sender, EventArgs e)
        {
            this.SaveCommand.Enabled = false;
            this.SaveNewCommand.Enabled = false;
            this.PreviewCommand.Enabled = false;
            using var stream = await this.CreateCroppedStream();
            if (stream != null && this.SnippetPersonality.SelectedItem is IReadOnlyPersonality personality && this.OnSave != null)
            {
                await this
                    .OnSave(personality, this.SnippetText.Text, stream, true);
            }
        }

        private void SnippetWaveViewer_Resize(object sender, EventArgs e)
        {
            if (this.SnippetWaveViewer.WaveStream != null)
            {
                this.SnippetWaveViewer.SamplesPerPixel = (this.SnippetWaveViewer.WaveStream.TotalTime.Seconds * 8000) / this.SnippetWaveViewer.Width;
            }
        }

        public IRecordControl Initialize(IVoiceRecordingOperationsService voiceRecordingOperationsService, IReadOnlyList<IReadOnlyPersonality> personalities, Func<Stream, Task> onPreview, Func<IReadOnlyPersonality, string, Stream, bool, Task> onSave)
        {
            this.PreviewCommand.Enabled = this.SaveCommand.Enabled = this.SaveNewCommand.Enabled = false;
            this.VoiceRecordingOperationsService = voiceRecordingOperationsService;
            this.OnPreview = onPreview;
            this.OnSave = onSave;
            return this.Bind(personalities);
        }

        public IRecordControl Bind(IReadOnlyList<IReadOnlyPersonality> personalities, IReadOnlyPersonality? personality = null)
        {
            this.SnippetPersonality
                .BindPersonalities(personalities, personality);
            return this;
        }

        public IRecordControl Bind(Stream stream)
        {
            if (this.OriginalCapturedAudio != null)
            {
                this.OriginalCapturedAudio.Dispose();
                this.OriginalCapturedAudio = null;
            }
            if (this.SnippetWaveViewer.WaveStream != null)
            {
                this.SnippetWaveViewer
                    .WaveStream
                    .Dispose();
                this.SnippetWaveViewer.WaveStream = null;
            }
            if (stream == null)
            {
                this.PreviewCommand.Enabled = this.SaveCommand.Enabled = this.SaveNewCommand.Enabled = false;
            }
            else
            {
                this.PreviewCommand.Enabled = this.SaveCommand.Enabled = this.SaveNewCommand.Enabled = true;
                this.OriginalCapturedAudio = stream;
                this.SnippetWaveViewer.WaveStream = new Mp3FileReader(stream);
            }
            return this;
        }

        public IRecordControl Bind(string defaultText)
        {
            this.SnippetText.Text = defaultText ?? string.Empty;
            return this;
        }

        public IRecordControl Reset() => this
            .Bind((Stream)null)
            .Bind(string.Empty);
    }
}
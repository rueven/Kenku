using Kenku.Extensions;
using Kenku.Models.Implementations;
using Kenku.Models.Interfaces;
using Kenku.Objects.Interfaces;
using Kenku.Services.Interfaces;
using Kenku.WinformApplication.Extensions;
using Kenku.WinformApplication.Forms;
using Kenku.WinformApplication.Services.Implementations;
using Kenku.WinformApplication.Services.Interfaces;
using System.Text;

namespace Kenku.WinformApplication
{
    public partial class Main : Form
    {
        public Main() { this.InitializeComponent(); }
        public Main(ISession session, ISpeechToTextFactoryService? speechToTextFactoryService) : this()
        {
            this.Session = session;
            this.SpeechToTextFactoryService = speechToTextFactoryService;
            this.RefreshTextToSpeechOptions(this.Session.SimpleTextToSpeechService);
            this.RefreshPersonalityOptions(this.Session.Personalities.First());
            this.RefreshVoiceRecordingLibraries();
            this.KenkuMenuStrip
                .AddToolStripMenuItem("Audio Devices")
                .AddDataBoundToolStripDropDownButton
                (
                    "Input",
                    this.Session.InputAudioDeviceServices,
                    selectedService =>
                    {
                        this.Session.InputAudioDeviceService = selectedService;
                        if (this.Session.Container.ConfigurationService is FilePersistenceExtendedConfigurationService configurationService)
                        {
                            configurationService
                                .Save();
                        }
                    },
                    this.Session.InputAudioDeviceService
                )
                .AddDataBoundToolStripDropDownButton
                (
                    "Output",
                    this.Session.OutputAudioDeviceServices,
                    selectedService =>
                    {
                        this.Session.OutputAudioDeviceService = selectedService;
                        if (this.Session.Container.ConfigurationService is FilePersistenceExtendedConfigurationService configurationService)
                        {
                            configurationService
                                .Save();
                        }
                    },
                    this.Session.OutputAudioDeviceService
                )
                .AddDataBoundToolStripDropDownButton
                (
                    "Preview",
                    this.Session.OutputAudioDeviceServices,
                    selectedService =>
                    {
                        this.Session.PreviewAudioDeviceService = selectedService;
                        if (this.Session.Container.ConfigurationService is FilePersistenceExtendedConfigurationService configurationService)
                        {
                            configurationService
                                .Save();
                        }
                    },
                    this.Session.PreviewAudioDeviceService
                );
            var configurationNode = this
                .KenkuMenuStrip
                .AddToolStripMenuItem("Configuration");
            if (this.Session.Container.ConfigurationService is FilePersistenceExtendedConfigurationService configurationService)
            {
                configurationNode
                    .AddClickableMenuItem("View ElevenLabs Voice Settings", (sender, e) =>
                    {
                        using var form = new ElevenLabsConfiguration()
                        {
                            ElevenLabsApiKeyValue = configurationService.ElevenLabsKey
                        };
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            configurationService.ElevenLabsKey = form.ElevenLabsApiKeyValue;
                            configurationService.Save();
                        }
                    });
                configurationNode
                    .AddClickableMenuItem("View Google Voice Settings", (sender, e) =>
                    {
                        using var form = new GoogleVoiceConfiguration()
                        {
                            GoogleVoiceFilepath = configurationService.GoogleCloudConfigurationFilePath
                        };
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            configurationService.GoogleCloudConfigurationFilePath = form.GoogleVoiceFilepath;
                            configurationService.Save();
                        }
                    });
                configurationNode
                    .AddClickableMenuItem("View Microsoft Voice Settings", (sender, e) =>
                    {
                        using var form = new MicrosoftVoiceConfiguration()
                        {
                            IsSpeechToTextEnabled = configurationService.MicrosoftSpeechToTextServiceEnabled,
                            IsSystemSpeechTextToSpeechServicesEnabled = configurationService.MicrosoftTextToSpeechServicesEnabled
                        };
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            configurationService.MicrosoftSpeechToTextServiceEnabled = form.IsSpeechToTextEnabled;
                            configurationService.MicrosoftTextToSpeechServicesEnabled = form.IsSystemSpeechTextToSpeechServicesEnabled;
                            configurationService.Save();
                        }
                    });
                configurationNode
                    .AddClickableMenuItem("View Standard Settings", (sender, e) =>
                    {
                        using var form = new StandardConfiguration()
                        {
                            IsMirroredPlaybackMode = configurationService.IsMirroredPlaybackMode,
                            PushToTalkKey = configurationService.PushToTalkKey,
                            IsPushToTalkEmulationEnabled = configurationService.IsPushToTalkEmulationEnabled,
                            UseForcedPreambleForTextToSpeech = configurationService.UseForcedPreambleForTextToSpeech,
                            UseForcedPreambleForVoiceRecordingPlayback = configurationService.UseForcedPreambleForVoiceRecordingPlayback,
                            ForcedPreambleText = configurationService.ForcedPreambleText
                        };
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            configurationService.IsMirroredPlaybackMode = form.IsMirroredPlaybackMode;
                            configurationService.PushToTalkKey = form.PushToTalkKey;
                            configurationService.IsPushToTalkEmulationEnabled = form.IsPushToTalkEmulationEnabled;
                            configurationService.UseForcedPreambleForTextToSpeech = form.UseForcedPreambleForTextToSpeech;
                            configurationService.UseForcedPreambleForVoiceRecordingPlayback = form.UseForcedPreambleForVoiceRecordingPlayback;
                            configurationService.ForcedPreambleText = form.ForcedPreambleText;
                            configurationService.Save();
                        }
                    });
                configurationNode
                    .AddClickableMenuItem("Manage Personalities", async (sender, e) =>
                    {
                        using var form = new PersonalityManagement(this.Session.Personalities);
                        if (form.ShowDialog(this) == DialogResult.OK)
                        {
                            var personalities = form.EditedPersonalities;
                            await this.Session
                                .Container
                                .PersonalityService
                                .ReplaceAll(personalities);
                            await this
                                .Session
                                .RefreshAsync();
                            this.RefreshPersonalityOptions();
                            this.RefreshVoiceRecordingLibraries();
                        }
                    });
            }
            this.KenkuMenuStrip
                .AddToolStripMenuItem("Refresh Voices")
                .Click += async (sender, args) =>
                {
                    await this
                        .Session
                        .RefreshAsync();
                    this.RefreshVoiceRecordingLibraries();
                };
            this.KenkuVoiceSelectionCheckBoxList
                .DataBindNamedServices(this.Session.TextToSpeechServices, true);
            this.KenkuVoiceRecordingControl
                .Initialize
                (
                    session.Container.VoiceRecordingOperationsService,
                    session.Personalities,
                    async stream => await this.Session.PreviewAsync(stream, default),
                    async (personality, text, stream, _) =>
                    {
                        await this
                            .Session
                            .SaveRecordingAsync(personality, text, stream);
                        await this
                            .Session
                            .RefreshAsync();
                        this.RefreshVoiceRecordingLibraries();
                    }
                );
            this.RecordIcon = Helpers
                .ImageHelpers
                .Record
                .Start
                .Draw(this.KenkuRecordCommand.Width - 5, this.KenkuRecordCommand.Height - 5);
            this.StopRecordIcon = Helpers
                .ImageHelpers
                .Record
                .Stop
                .Draw(this.KenkuRecordCommand.Width - 5, this.KenkuRecordCommand.Height - 5);
            this.KenkuRecordCommand.Image = this.RecordIcon;
            this.PlayIcon = Helpers
                .ImageHelpers
                .Playback
                .Start
                .Draw(this.KenkuSimpleTextToSpeechPlayCommand.Width - 5, this.KenkuSimpleTextToSpeechPlayCommand.Height - 5);
            this.StopPlayIcon = Helpers
                .ImageHelpers
                .Playback
                .Stop
                .Draw(this.KenkuSimpleTextToSpeechPlayCommand.Width - 5, this.KenkuSimpleTextToSpeechPlayCommand.Height - 5);
            this.KenkuSimpleTextToSpeechPlayCommand.Image = this.PlayIcon;
        }

        protected ISession Session { get; }
        protected ISpeechToTextFactoryService? SpeechToTextFactoryService { get; }
        private Image RecordIcon { get; set; }
        private Image StopRecordIcon { get; set; }
        private Image PlayIcon { get; set; }
        private Image StopPlayIcon { get; set; }

        private void RefreshTextToSpeechOptions(ITextToSpeechService? defaultValue = null)
        {
            this.KenkuSimpleTextToSpeechVoiceSelector
                .BindTextToSpeechServices(this.Session.FilteredTextToSpeechServices);
            if (defaultValue != null)
            {
                this.KenkuSimpleTextToSpeechVoiceSelector.SelectedItem = defaultValue;
            }
        }

        private void RefreshPersonalityOptions(IReadOnlyPersonality? defaultValue = null)
        {
            this.KenkuVoiceRecordingControl
                .Bind(this.Session.Personalities);
        }

        private void RefreshVoiceRecordingLibraries()
        {
            this.KenkuTreeView
                .BindVoiceRecordings(this.Session.Personalities, this.Session.VoiceRecordings);
        }

        private async Task ExecuteWhilePushToTalk(Func<Task> method)
        {
            if (this.Session.Container.ConfigurationService is IExtendedConfigurationService configurationService)
            {
                if (configurationService.IsPushToTalkEmulationEnabled)
                {
                    var robot = new Desktop.Robot.Robot();
                    var key = configurationService
                        .PushToTalkKey
                        !.First();
                    robot.KeyDown(key);
                    await Task
                        .Delay(100)
                        .ConfigureAwait(false);
                    await method()
                        .ConfigureAwait(false);
                    robot.KeyUp(key);
                }
            }
            else
            {
                await method()
                    .ConfigureAwait(false);
            }
        }

        private async Task PlaySimpleTextToSpeech(string text)
        {
            if (this.KenkuSimpleTextToSpeechPlayCommand.Tag is CancellationTokenSource source)
            {
                await source
                    .CancelAsync();
                source
                    .Dispose();
                this.KenkuSimpleTextToSpeechPlayCommand.Tag = null;
                this.KenkuSimpleTextToSpeechPlayCommand.Image = this.PlayIcon;
            }
            else
            {
                this.KenkuSimpleTextToSpeechPlayCommand.Image = this.StopPlayIcon;
                using var tokenSource = new CancellationTokenSource();
                this.KenkuSimpleTextToSpeechPlayCommand.Tag = tokenSource;
                await this
                    .ExecuteWhilePushToTalk(async () =>
                    {
                        try
                        {
                            await this
                                .Session
                                .PlayTextToSpeechAsync(text, tokenSource.Token);
                        }
                        catch (OperationCanceledException) { }
                        finally
                        {
                            tokenSource
                                .Dispose();
                        }
                        this.KenkuSimpleTextToSpeechPlayCommand.Tag = null;
                    });
                this.KenkuSimpleTextToSpeechPlayCommand.Image = this.PlayIcon;
            }
        }

        private async void KenkuSimpleTextToSpeechPlayCommand_Click(object sender, EventArgs e) => await this
            .PlaySimpleTextToSpeech(this.KenkuSimpleTextToSpeechInputText.Text);

        private void KenkuSimpleTextToSpeechVoiceSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var textToSpeechService = this
                .KenkuSimpleTextToSpeechVoiceSelector
                .SelectedItem as ITextToSpeechService;
            this.Session.SimpleTextToSpeechService = textToSpeechService!;
        }

        private async void KenkuRecordCommand_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox button)
            {
                button.SuspendLayout();
                switch (button.Text)
                {
                    case "":
                        {
                            this.KenkuVoiceRecordingControl.Reset();
                            button.Image = this.StopRecordIcon;
                            button.Text = " ";
                            var stringBuilder = new StringBuilder();
                            var audioWorker = await this
                                .Session
                                .StartRecordingAsync()
                                .ConfigureAwait(false);
                            var textWorker = this
                                .SpeechToTextFactoryService
                                ?.CreateWorker(x =>
                                {
                                    stringBuilder.Append(x);
                                });
                            if (textWorker != null)
                            {
                                await textWorker
                                    .StartAsync()
                                    .ConfigureAwait(false);
                            }
                            button.Tag = (stringBuilder, audioWorker!, textWorker);
                        }
                        break;
                    case " ":
                        {
                            button.Image = this.RecordIcon;
                            button.Text = "";
                            if (button.Tag is (StringBuilder stringBuilder, IAudioCaptureWorker audioWorker, ISpeechToTextWorker textWorker))
                            {
                                var stream = await audioWorker
                                    .StopAsync();
                                audioWorker.Dispose();
                                if (textWorker != null)
                                {
                                    await Task
                                        .Delay(1000);
                                    await textWorker
                                        .StopAsync();
                                    textWorker
                                        .Dispose();
                                }
                                button.Tag = null;
                                this.KenkuVoiceRecordingControl
                                    .Bind(stream)
                                    .Bind(stringBuilder.ToString());
                            }
                        }
                        break;
                    default:
                        break;
                }
                button.ResumeLayout();
            }

        }

        private void KenkuTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node?.Tag is Personality personality)
            {
            }
            if (e.Node?.Tag is IReadOnlyVoiceRecording voiceRecording)
            {
                var leadingSeperator = string.IsNullOrWhiteSpace(this.KenkuSimpleTextToSpeechInputText.Text) ? string.Empty : "|";
                this.KenkuSimpleTextToSpeechInputText.Text += leadingSeperator + voiceRecording.Text;
            }
        }

        private void KenkuTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Node.Tag is IReadOnlyVoiceRecording voiceRecording)
            {
                var contextMenu = new ContextMenuStrip()
                    .With(menu =>
                    {
                        menu.Items
                            .Add("Play")
                            .With(playNowCommand =>
                            {
                                playNowCommand.Tag = voiceRecording;
                                playNowCommand.Click += this.PlayNowCommand_Click;
                            });
                        menu.Items
                            .Add("Preview")
                            .With(previewNowCommand =>
                            {
                                previewNowCommand.Tag = voiceRecording;
                                previewNowCommand.Click += this.PreviewNowCommand_Click;
                            });
                        menu.Items
                            .Add("Edit")
                            .With(editVoiceRecordingCommand =>
                            {
                                editVoiceRecordingCommand.Tag = voiceRecording;
                                editVoiceRecordingCommand.Click += this.EditVoiceRecordingCommand_Click;
                            });
                        menu.Items
                            .Add("Delete")
                            .With(deleteVoiceRecordingCommand =>
                            {
                                deleteVoiceRecordingCommand.Tag = voiceRecording;
                                deleteVoiceRecordingCommand.Click += this.DeleteVoiceRecordingCommand_Click;
                            });
                        menu.Items
                            .Add("Copy Full File Path")
                            .With(copyFilePathCommand =>
                            {
                                copyFilePathCommand.Tag = voiceRecording;
                                copyFilePathCommand.Click += this.CopyFilePathCommand_Click; ;
                            });
                        var updatePersonalityDropdownButton = new ToolStripDropDownButton("Set Personality");
                        foreach (var personality in this.Session.Personalities)
                        {
                            var personalityNode = updatePersonalityDropdownButton
                                .DropDownItems
                                .Add(personality.Name);
                            personalityNode.Tag = new Tuple<IReadOnlyVoiceRecording, IReadOnlyPersonality>(voiceRecording, personality);
                            personalityNode.Click += this.UpdateVoiceRecordingPersonalityCommand_Click;
                        }
                        menu.Items.Add(updatePersonalityDropdownButton);
                    });
                contextMenu!.Show(this.KenkuTreeView, e.Location);
            }
        }

        private async void EditVoiceRecordingCommand_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripItem item && item.Tag is IReadOnlyVoiceRecording voiceRecording)
            {
                using var stream = await this.Session.Container.AudioResourceService.FetchAsync(voiceRecording);
                using var popup = new VoiceRecordingEditor(this.Session, (VoiceRecording)voiceRecording, stream);
                var result = popup.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    await this
                        .Session
                        .RefreshAsync();
                    this.RefreshVoiceRecordingLibraries();
                }
            }
        }

        private async void CopyFilePathCommand_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripItem item && item.Tag is IReadOnlyVoiceRecording voiceRecording)
            {
                var filePath = await this
                    .Session
                    .GetFullFilePath(voiceRecording);
                new Thread(() => Clipboard.SetText(filePath))
                    .With(x =>
                    {
                        x.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                        x.Start();
                        x.Join();
                    });
            }
        }

        private async void DeleteVoiceRecordingCommand_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripItem item && item.Tag is IReadOnlyVoiceRecording voiceRecording)
            {
                var isSuccess = await this
                    .Session
                    .DeleteVoiceRecording(voiceRecording);
                if (isSuccess)
                {
                    this.RefreshVoiceRecordingLibraries();
                }
            }
        }

        private async void UpdateVoiceRecordingPersonalityCommand_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem toolStripMenuItem && toolStripMenuItem.Tag is Tuple<IReadOnlyVoiceRecording, Personality> tuple)
            {
                var isSuccess = await this.Session
                    .UpdateVoiceRecordingPersonality(tuple.Item1, tuple.Item2);
                if (isSuccess)
                {
                    this.RefreshVoiceRecordingLibraries();
                }
            }
        }

        private async void PlayNowCommand_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripItem item && item.Tag is IReadOnlyVoiceRecording voiceRecording)
            {
                await this
                    .ExecuteWhilePushToTalk(async () =>
                    {
                        await this
                            .Session
                            .PlayVoiceRecording(voiceRecording, default)
                            .ConfigureAwait(false);
                    })
                    .ConfigureAwait(false);
            }
        }

        private async void PreviewNowCommand_Click(object? sender, EventArgs e)
        {
            if (sender is ToolStripItem item && item.Tag is IReadOnlyVoiceRecording voiceRecording)
            {
                await this
                    .Session
                    .PreviewVoiceRecording(voiceRecording, default);
            }
        }

        private async void KenkuSimpleTextToSpeechInputText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return && !string.IsNullOrEmpty(this.KenkuSimpleTextToSpeechInputText.Text))
            {
                // After hitting enter, the push-to-talk can interfere with the textbox being cleared.
                this.KenkuSimpleTextToSpeechClearCommand
                    .Focus();
                var task = this
                    .PlaySimpleTextToSpeech(this.KenkuSimpleTextToSpeechInputText.Text);
                await Task
                    .Delay(100);
                this.KenkuSimpleTextToSpeechInputText.Text = string.Empty;
                this.KenkuSimpleTextToSpeechInputText
                    .Focus();
                await task;
                return;
            }
        }

        private void KenkuVoiceSelectionApplyCommand_Click(object sender, EventArgs e)
        {
            var whiteList = this.KenkuVoiceSelectionCheckBoxList
                .GetCheckedNamedServices<ITextToSpeechService>();
            this.Session.FilteredTextToSpeechServices = whiteList;
            this.RefreshTextToSpeechOptions();
        }

        private void KenkuVoiceSelectionCheckAll_Click(object sender, EventArgs e) => this
            .KenkuVoiceSelectionCheckBoxList
            .SetAllCheckValue(true);

        private void KenkuVoiceSelectionUnCheckAll_Click(object sender, EventArgs e) => this
            .KenkuVoiceSelectionCheckBoxList
            .SetAllCheckValue(false);

        private void KenkuSimpleTextToSpeechClearCommand_Click(object sender, EventArgs e) => this
            .KenkuSimpleTextToSpeechInputText
            .Clear();
    }
}
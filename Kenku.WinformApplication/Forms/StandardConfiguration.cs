namespace Kenku.WinformApplication.Forms
{
    public partial class StandardConfiguration : Form
    {
        public StandardConfiguration() { this.InitializeComponent(); }
        private void SaveCommand_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;
        public bool IsMirroredPlaybackMode
        {
            get => this.IsMirroredPlayback.Checked;
            set => this.IsMirroredPlayback.Checked = value;
        }

        public bool IsPushToTalkEmulationEnabled
        {
            get => this.IsPushToTalkEmulationEnabledCheckBox.Checked;
            set => this.IsPushToTalkEmulationEnabledCheckBox.Checked = value;
        }

        public string? PushToTalkKey
        {
            get => string.IsNullOrWhiteSpace(this.PushToTalkTextBox.Text) ? null : this.PushToTalkTextBox.Text;
            set => this.PushToTalkTextBox.Text = value;
        }
    }
}
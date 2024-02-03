namespace Kenku.WinformApplication.Forms
{
    public partial class MicrosoftVoiceConfiguration : Form
    {
        public MicrosoftVoiceConfiguration() { InitializeComponent(); }
        private void SaveCommand_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;
        public bool IsSpeechToTextEnabled
        {
            get => this.EnableSpeechToText.Checked;
            set => this.EnableSpeechToText.Checked = value;
        }
        public bool IsSystemSpeechTextToSpeechServicesEnabled
        {
            get => this.LoadSystemSpeechVoices.Checked;
            set => this.LoadSystemSpeechVoices.Checked = value;
        }
    }
}
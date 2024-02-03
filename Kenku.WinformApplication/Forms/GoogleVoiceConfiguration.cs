using Kenku.WinformApplication.Helpers;

namespace Kenku.WinformApplication.Forms
{
    public partial class GoogleVoiceConfiguration : Form
    {
        public GoogleVoiceConfiguration() { this.InitializeComponent(); }
        private void BrowseCommand_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Multiselect = false,
                SelectReadOnly = true,
                ShowPinnedPlaces = true,
                SupportMultiDottedExtensions = true,
                DefaultExt = "json",
                Filter = "json files (*.json)|*.json",
                Title = "Select your Google Cloud Authentication File..."
            };
            if (new Invoker(dialog).Invoke() == DialogResult.OK)
            {
                this.GoogleVoiceFilepath = string.IsNullOrWhiteSpace(dialog.FileName) ? null : dialog.FileName;
            }
        }
        private void SaveCommand_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;
        private void ClearCommand_Click(object sender, EventArgs e) => this.GoogleVoiceFilepath = string.Empty;
        public string? GoogleVoiceFilepath
        {
            get => string.IsNullOrWhiteSpace(this.textBox1.Text) ? null : this.textBox1.Text;
            set => this.textBox1.Text = value;
        }
    }
}
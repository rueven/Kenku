namespace Kenku.WinformApplication.Forms
{
    public partial class ElevenLabsConfiguration : Form
    {
        public ElevenLabsConfiguration() { this.InitializeComponent(); }
        private void OkCommand_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;
        public string? ElevenLabsApiKeyValue
        {
            get => string.IsNullOrWhiteSpace(this.textBox1.Text) ? null : this.textBox1.Text;
            set => this.textBox1.Text = value;
        }
    }
}
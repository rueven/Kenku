namespace Kenku.WinformApplication.Forms
{
    partial class VoiceRecordingEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RecordingControl = new Controls.RecordingControl();
            this.SuspendLayout();
            // 
            // RecordingControl
            // 
            this.RecordingControl.Dock = DockStyle.Fill;
            this.RecordingControl.Location = new Point(0, 0);
            this.RecordingControl.Name = "RecordingControl";
            this.RecordingControl.Size = new Size(800, 450);
            this.RecordingControl.TabIndex = 0;
            // 
            // VoiceRecordingEditor
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.RecordingControl);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Name = "VoiceRecordingEditor";
            this.Text = "VoiceRecordingEditor";
            this.ResumeLayout(false);
        }

        #endregion

        private Controls.RecordingControl RecordingControl;
    }
}
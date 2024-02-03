namespace Kenku.WinformApplication.Forms
{
    partial class MicrosoftVoiceConfiguration
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
            this.LoadSystemSpeechVoices = new CheckBox();
            this.EnableSpeechToText = new CheckBox();
            this.label2 = new Label();
            this.SaveCommand = new Button();
            this.SuspendLayout();
            // 
            // LoadSystemSpeechVoices
            // 
            this.LoadSystemSpeechVoices.AutoSize = true;
            this.LoadSystemSpeechVoices.Location = new Point(12, 37);
            this.LoadSystemSpeechVoices.Name = "LoadSystemSpeechVoices";
            this.LoadSystemSpeechVoices.Size = new Size(179, 19);
            this.LoadSystemSpeechVoices.TabIndex = 0;
            this.LoadSystemSpeechVoices.Text = "Enable System.Speech Voices";
            this.LoadSystemSpeechVoices.UseVisualStyleBackColor = true;
            // 
            // EnableSpeechToText
            // 
            this.EnableSpeechToText.AutoSize = true;
            this.EnableSpeechToText.Location = new Point(12, 12);
            this.EnableSpeechToText.Name = "EnableSpeechToText";
            this.EnableSpeechToText.Size = new Size(140, 19);
            this.EnableSpeechToText.TabIndex = 1;
            this.EnableSpeechToText.Text = "Enable Speech to Text";
            this.EnableSpeechToText.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new Size(400, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Changes to this setting will not take effect until the application is restarted!";
            // 
            // SaveCommand
            // 
            this.SaveCommand.Location = new Point(713, 12);
            this.SaveCommand.Name = "SaveCommand";
            this.SaveCommand.Size = new Size(75, 23);
            this.SaveCommand.TabIndex = 5;
            this.SaveCommand.Text = "Save";
            this.SaveCommand.UseVisualStyleBackColor = true;
            this.SaveCommand.Click += this.SaveCommand_Click;
            // 
            // MicrosoftVoiceConfiguration
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 101);
            this.Controls.Add(this.SaveCommand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EnableSpeechToText);
            this.Controls.Add(this.LoadSystemSpeechVoices);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MicrosoftVoiceConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "MicrosoftVoiceConfiguration";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private CheckBox LoadSystemSpeechVoices;
        private CheckBox EnableSpeechToText;
        private Label label2;
        private Button SaveCommand;
    }
}
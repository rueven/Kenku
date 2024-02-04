namespace Kenku.WinformApplication.Forms
{
    partial class StandardConfiguration
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
            this.SaveCommand = new Button();
            this.groupBox1 = new GroupBox();
            this.label1 = new Label();
            this.HasForcedPreambleForVoiceRecordingPlayback = new CheckBox();
            this.ForcedPreambleTextBox = new TextBox();
            this.HasForcedPreambleForTextToSpeech = new CheckBox();
            this.groupBox2 = new GroupBox();
            this.PushToTalkTextBox = new TextBox();
            this.IsPushToTalkEmulationEnabledCheckBox = new CheckBox();
            this.groupBox3 = new GroupBox();
            this.IsMirroredPlayback = new CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaveCommand
            // 
            this.SaveCommand.Location = new Point(713, 9);
            this.SaveCommand.Name = "SaveCommand";
            this.SaveCommand.Size = new Size(75, 23);
            this.SaveCommand.TabIndex = 1;
            this.SaveCommand.Text = "Save";
            this.SaveCommand.UseVisualStyleBackColor = true;
            this.SaveCommand.Click += this.SaveCommand_Click;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.HasForcedPreambleForVoiceRecordingPlayback);
            this.groupBox1.Controls.Add(this.ForcedPreambleTextBox);
            this.groupBox1.Controls.Add(this.HasForcedPreambleForTextToSpeech);
            this.groupBox1.Location = new Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(695, 81);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preamble";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new Size(60, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Preamble:";
            // 
            // HasForcedPreambleForVoiceRecordingPLayback
            // 
            this.HasForcedPreambleForVoiceRecordingPlayback.AutoSize = true;
            this.HasForcedPreambleForVoiceRecordingPlayback.Location = new Point(268, 51);
            this.HasForcedPreambleForVoiceRecordingPlayback.Name = "HasForcedPreambleForVoiceRecordingPLayback";
            this.HasForcedPreambleForVoiceRecordingPlayback.Size = new Size(284, 19);
            this.HasForcedPreambleForVoiceRecordingPlayback.TabIndex = 9;
            this.HasForcedPreambleForVoiceRecordingPlayback.Text = "Use forced preamble fo voice recording playback";
            this.HasForcedPreambleForVoiceRecordingPlayback.UseVisualStyleBackColor = true;
            // 
            // ForcedPreambleTextBox
            // 
            this.ForcedPreambleTextBox.Location = new Point(83, 22);
            this.ForcedPreambleTextBox.Name = "ForcedPreambleTextBox";
            this.ForcedPreambleTextBox.Size = new Size(606, 23);
            this.ForcedPreambleTextBox.TabIndex = 8;
            // 
            // HasForcedPreambleForTextToSpeech
            // 
            this.HasForcedPreambleForTextToSpeech.AutoSize = true;
            this.HasForcedPreambleForTextToSpeech.Location = new Point(17, 51);
            this.HasForcedPreambleForTextToSpeech.Name = "HasForcedPreambleForTextToSpeech";
            this.HasForcedPreambleForTextToSpeech.Size = new Size(245, 19);
            this.HasForcedPreambleForTextToSpeech.TabIndex = 7;
            this.HasForcedPreambleForTextToSpeech.Text = "Use a forced preamble for Text-to-Speech";
            this.HasForcedPreambleForTextToSpeech.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBox2.Controls.Add(this.PushToTalkTextBox);
            this.groupBox2.Controls.Add(this.IsPushToTalkEmulationEnabledCheckBox);
            this.groupBox2.Location = new Point(12, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(695, 50);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Push-to-Talk Emulation";
            // 
            // PushToTalkTextBox
            // 
            this.PushToTalkTextBox.Location = new Point(255, 18);
            this.PushToTalkTextBox.Name = "PushToTalkTextBox";
            this.PushToTalkTextBox.Size = new Size(64, 23);
            this.PushToTalkTextBox.TabIndex = 5;
            // 
            // IsPushToTalkEmulationEnabledCheckBox
            // 
            this.IsPushToTalkEmulationEnabledCheckBox.AutoSize = true;
            this.IsPushToTalkEmulationEnabledCheckBox.Location = new Point(17, 22);
            this.IsPushToTalkEmulationEnabledCheckBox.Name = "IsPushToTalkEmulationEnabledCheckBox";
            this.IsPushToTalkEmulationEnabledCheckBox.Size = new Size(232, 19);
            this.IsPushToTalkEmulationEnabledCheckBox.TabIndex = 4;
            this.IsPushToTalkEmulationEnabledCheckBox.Text = "Emulate push-to-talk key while playing";
            this.IsPushToTalkEmulationEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBox3.Controls.Add(this.IsMirroredPlayback);
            this.groupBox3.Location = new Point(12, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(695, 59);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Audio Mirror Mode";
            // 
            // IsMirroredPlayback
            // 
            this.IsMirroredPlayback.AutoSize = true;
            this.IsMirroredPlayback.Location = new Point(17, 29);
            this.IsMirroredPlayback.Name = "IsMirroredPlayback";
            this.IsMirroredPlayback.Size = new Size(401, 19);
            this.IsMirroredPlayback.TabIndex = 1;
            this.IsMirroredPlayback.Text = "Use both Preview and Main Output audio devices when playing sounds";
            this.IsMirroredPlayback.UseVisualStyleBackColor = true;
            // 
            // StandardConfiguration
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 219);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SaveCommand);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StandardConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "StandardConfiguration";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
        private Button SaveCommand;
        private GroupBox groupBox1;
        private Label label1;
        private CheckBox HasForcedPreambleForVoiceRecordingPlayback;
        private TextBox ForcedPreambleTextBox;
        private CheckBox HasForcedPreambleForTextToSpeech;
        private GroupBox groupBox2;
        private TextBox PushToTalkTextBox;
        private CheckBox IsPushToTalkEmulationEnabledCheckBox;
        private GroupBox groupBox3;
        private CheckBox IsMirroredPlayback;
    }
}
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
            this.IsMirroredPlayback = new CheckBox();
            this.SaveCommand = new Button();
            this.IsPushToTalkEmulationEnabledCheckBox = new CheckBox();
            this.PushToTalkTextBox = new TextBox();
            this.SuspendLayout();
            // 
            // IsMirroredPlayback
            // 
            this.IsMirroredPlayback.AutoSize = true;
            this.IsMirroredPlayback.Location = new Point(12, 12);
            this.IsMirroredPlayback.Name = "IsMirroredPlayback";
            this.IsMirroredPlayback.Size = new Size(401, 19);
            this.IsMirroredPlayback.TabIndex = 0;
            this.IsMirroredPlayback.Text = "Use both Preview and Main Output audio devices when playing sounds";
            this.IsMirroredPlayback.UseVisualStyleBackColor = true;
            // 
            // SaveCommand
            // 
            this.SaveCommand.Location = new Point(713, 8);
            this.SaveCommand.Name = "SaveCommand";
            this.SaveCommand.Size = new Size(75, 23);
            this.SaveCommand.TabIndex = 1;
            this.SaveCommand.Text = "Save";
            this.SaveCommand.UseVisualStyleBackColor = true;
            this.SaveCommand.Click += this.SaveCommand_Click;
            // 
            // IsPushToTalkEmulationEnabled
            // 
            this.IsPushToTalkEmulationEnabledCheckBox.AutoSize = true;
            this.IsPushToTalkEmulationEnabledCheckBox.Location = new Point(12, 37);
            this.IsPushToTalkEmulationEnabledCheckBox.Name = "IsPushToTalkEmulationEnabled";
            this.IsPushToTalkEmulationEnabledCheckBox.Size = new Size(232, 19);
            this.IsPushToTalkEmulationEnabledCheckBox.TabIndex = 2;
            this.IsPushToTalkEmulationEnabledCheckBox.Text = "Emulate push-to-talk key while playing";
            this.IsPushToTalkEmulationEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // PushToTalkTextBox
            // 
            this.PushToTalkTextBox.Location = new Point(250, 33);
            this.PushToTalkTextBox.Name = "PushToTalkTextBox";
            this.PushToTalkTextBox.Size = new Size(64, 23);
            this.PushToTalkTextBox.TabIndex = 3;
            // 
            // StandardConfiguration
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 68);
            this.Controls.Add(this.PushToTalkTextBox);
            this.Controls.Add(this.IsPushToTalkEmulationEnabledCheckBox);
            this.Controls.Add(this.SaveCommand);
            this.Controls.Add(this.IsMirroredPlayback);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StandardConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "StandardConfiguration";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private CheckBox IsMirroredPlayback;
        private Button SaveCommand;
        private CheckBox IsPushToTalkEmulationEnabledCheckBox;
        private TextBox PushToTalkTextBox;
    }
}
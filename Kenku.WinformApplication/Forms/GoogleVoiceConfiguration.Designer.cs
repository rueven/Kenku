namespace Kenku.WinformApplication.Forms
{
    partial class GoogleVoiceConfiguration
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
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.BrowseCommand = new Button();
            this.label2 = new Label();
            this.SaveCommand = new Button();
            this.ClearCommand = new Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(110, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Authentication File:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.textBox1.Location = new Point(128, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new Size(579, 23);
            this.textBox1.TabIndex = 1;
            // 
            // BrowseCommand
            // 
            this.BrowseCommand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.BrowseCommand.Location = new Point(713, 11);
            this.BrowseCommand.Name = "BrowseCommand";
            this.BrowseCommand.Size = new Size(75, 23);
            this.BrowseCommand.TabIndex = 2;
            this.BrowseCommand.Text = "Browse";
            this.BrowseCommand.UseVisualStyleBackColor = true;
            this.BrowseCommand.Click += this.BrowseCommand_Click;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(128, 38);
            this.label2.Name = "label2";
            this.label2.Size = new Size(400, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Changes to this setting will not take effect until the application is restarted!";
            // 
            // SaveCommand
            // 
            this.SaveCommand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.SaveCommand.Location = new Point(713, 40);
            this.SaveCommand.Name = "SaveCommand";
            this.SaveCommand.Size = new Size(75, 23);
            this.SaveCommand.TabIndex = 5;
            this.SaveCommand.Text = "Save";
            this.SaveCommand.UseVisualStyleBackColor = true;
            this.SaveCommand.Click += this.SaveCommand_Click;
            // 
            // ClearCommand
            // 
            this.ClearCommand.Location = new Point(713, 69);
            this.ClearCommand.Name = "ClearCommand";
            this.ClearCommand.Size = new Size(75, 23);
            this.ClearCommand.TabIndex = 6;
            this.ClearCommand.Text = "Clear";
            this.ClearCommand.UseVisualStyleBackColor = true;
            this.ClearCommand.Click += this.ClearCommand_Click;
            // 
            // GoogleVoiceConfiguration
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 101);
            this.Controls.Add(this.ClearCommand);
            this.Controls.Add(this.SaveCommand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrowseCommand);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoogleVoiceConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "GoogleVoice Configuration";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button BrowseCommand;
        private Label label2;
        private Button SaveCommand;
        private Button ClearCommand;
    }
}
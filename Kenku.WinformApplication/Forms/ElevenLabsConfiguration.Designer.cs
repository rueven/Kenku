namespace Kenku.WinformApplication.Forms
{
    partial class ElevenLabsConfiguration
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
            this.textBox1 = new TextBox();
            this.label1 = new Label();
            this.OkCommand = new Button();
            this.label2 = new Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.textBox1.Location = new Point(68, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(639, 23);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(50, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "API Key:";
            // 
            // OkCommand
            // 
            this.OkCommand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.OkCommand.Location = new Point(713, 11);
            this.OkCommand.Name = "OkCommand";
            this.OkCommand.Size = new Size(75, 23);
            this.OkCommand.TabIndex = 2;
            this.OkCommand.Text = "Save";
            this.OkCommand.UseVisualStyleBackColor = true;
            this.OkCommand.Click += this.OkCommand_Click;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(178, 38);
            this.label2.Name = "label2";
            this.label2.Size = new Size(400, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Changes to this setting will not take effect until the application is restarted!";
            // 
            // ElevenLabsConfiguration
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 59);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OkCommand);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ElevenLabsConfiguration";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "ElevenLabs Configuration";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button OkCommand;
        private Label label2;
    }
}
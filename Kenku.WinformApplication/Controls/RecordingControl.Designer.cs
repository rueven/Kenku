namespace Kenku.WinformApplication.Controls
{
    partial class RecordingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new GroupBox();
            this.SaveNewCommand = new Button();
            this.SnippetWaveViewer = new CustomWaveViewer();
            this.SaveCommand = new Button();
            this.PersonalityLabel = new Label();
            this.TextLabel = new Label();
            this.SnippetText = new TextBox();
            this.SnippetPersonality = new ComboBox();
            this.PreviewCommand = new Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveNewCommand);
            this.groupBox1.Controls.Add(this.SnippetWaveViewer);
            this.groupBox1.Controls.Add(this.SaveCommand);
            this.groupBox1.Controls.Add(this.PersonalityLabel);
            this.groupBox1.Controls.Add(this.TextLabel);
            this.groupBox1.Controls.Add(this.SnippetText);
            this.groupBox1.Controls.Add(this.SnippetPersonality);
            this.groupBox1.Controls.Add(this.PreviewCommand);
            this.groupBox1.Dock = DockStyle.Fill;
            this.groupBox1.Location = new Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(2127, 363);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Voice Recording Editor";
            // 
            // SaveNewCommand
            // 
            this.SaveNewCommand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.SaveNewCommand.Location = new Point(2046, 93);
            this.SaveNewCommand.Name = "SaveNewCommand";
            this.SaveNewCommand.Size = new Size(75, 23);
            this.SaveNewCommand.TabIndex = 41;
            this.SaveNewCommand.Text = "Save New";
            this.SaveNewCommand.UseVisualStyleBackColor = true;
            this.SaveNewCommand.Click += this.SaveNewCommand_Click;
            // 
            // SnippetWaveViewer
            // 
            this.SnippetWaveViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.SnippetWaveViewer.BackColor = Color.Black;
            this.SnippetWaveViewer.BorderStyle = BorderStyle.Fixed3D;
            this.SnippetWaveViewer.HighlightBackColor = Color.Gray;
            this.SnippetWaveViewer.HighlightWaveFormColor = Color.White;
            this.SnippetWaveViewer.Location = new Point(101, 94);
            this.SnippetWaveViewer.Name = "SnippetWaveViewer";
            this.SnippetWaveViewer.PenWidth = 1F;
            this.SnippetWaveViewer.SamplesPerPixel = 128;
            this.SnippetWaveViewer.SelectionAnchor = null;
            this.SnippetWaveViewer.SelectionEnd = 0;
            this.SnippetWaveViewer.SelectionEndTimeSpan = TimeSpan.Parse("00:00:00");
            this.SnippetWaveViewer.SelectionStart = 0;
            this.SnippetWaveViewer.SelectionStartTimeSpan = TimeSpan.Parse("00:00:00");
            this.SnippetWaveViewer.ShouldZoom = false;
            this.SnippetWaveViewer.Size = new Size(1939, 263);
            this.SnippetWaveViewer.StartPosition = 0L;
            this.SnippetWaveViewer.TabIndex = 30;
            this.SnippetWaveViewer.WaveFormColor = Color.DodgerBlue;
            this.SnippetWaveViewer.WaveStream = null;
            this.SnippetWaveViewer.Resize += this.SnippetWaveViewer_Resize;
            // 
            // SaveCommand
            // 
            this.SaveCommand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.SaveCommand.Location = new Point(2046, 64);
            this.SaveCommand.Name = "SaveCommand";
            this.SaveCommand.Size = new Size(75, 23);
            this.SaveCommand.TabIndex = 40;
            this.SaveCommand.Text = "Save";
            this.SaveCommand.UseVisualStyleBackColor = true;
            this.SaveCommand.Click += this.SaveCommand_Click;
            // 
            // PersonalityLabel
            // 
            this.PersonalityLabel.AutoSize = true;
            this.PersonalityLabel.Location = new Point(27, 39);
            this.PersonalityLabel.Name = "PersonalityLabel";
            this.PersonalityLabel.Size = new Size(68, 15);
            this.PersonalityLabel.TabIndex = 39;
            this.PersonalityLabel.Text = "Personality:";
            // 
            // TextLabel
            // 
            this.TextLabel.AutoSize = true;
            this.TextLabel.Location = new Point(64, 68);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new Size(31, 15);
            this.TextLabel.TabIndex = 38;
            this.TextLabel.Text = "Text:";
            // 
            // SnippetText
            // 
            this.SnippetText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.SnippetText.Location = new Point(101, 65);
            this.SnippetText.Name = "SnippetText";
            this.SnippetText.Size = new Size(1939, 23);
            this.SnippetText.TabIndex = 37;
            // 
            // SnippetPersonality
            // 
            this.SnippetPersonality.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.SnippetPersonality.DisplayMember = "Name";
            this.SnippetPersonality.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SnippetPersonality.FormattingEnabled = true;
            this.SnippetPersonality.Location = new Point(101, 36);
            this.SnippetPersonality.Name = "SnippetPersonality";
            this.SnippetPersonality.Size = new Size(1939, 23);
            this.SnippetPersonality.TabIndex = 36;
            // 
            // PreviewCommand
            // 
            this.PreviewCommand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.PreviewCommand.Location = new Point(2046, 35);
            this.PreviewCommand.Name = "PreviewCommand";
            this.PreviewCommand.Size = new Size(75, 23);
            this.PreviewCommand.TabIndex = 35;
            this.PreviewCommand.Text = "Preview";
            this.PreviewCommand.UseVisualStyleBackColor = true;
            this.PreviewCommand.Click += this.PreviewCommand_Click;
            // 
            // RecordingControl
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "RecordingControl";
            this.Size = new Size(2127, 363);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button PreviewCommand;
        private CustomWaveViewer SnippetWaveViewer;
        private Label TextLabel;
        private TextBox SnippetText;
        private ComboBox SnippetPersonality;
        private Label PersonalityLabel;
        private Button SaveCommand;
        private Button SaveNewCommand;
    }
}

namespace Kenku.WinformApplication
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.KenkuStatusStrip = new StatusStrip();
            this.KenkuMenuStrip = new MenuStrip();
            this.KenkuTabControl = new TabControl();
            this.KenkuTextToSpeechTab = new TabPage();
            this.KenkuTextToSpeechGroupBox = new GroupBox();
            this.KenkuSimpleTextToSpeechInputText = new TextBox();
            this.label1 = new Label();
            this.KenkuSimpleTextToSpeechVoiceSelector = new ComboBox();
            this.KenkuSimpleTextToSpeechPlayCommand = new Button();
            this.KenkuSplitContainer = new SplitContainer();
            this.KenkuTreeView = new TreeView();
            this.KenkuVoiceSelectionTabPage = new TabPage();
            this.KenkuVoiceSelectionUnCheckAll = new Button();
            this.KenkuVoiceSelectionCheckAll = new Button();
            this.KenkuVoiceSelectionApplyCommand = new Button();
            this.KenkuVoiceSelectionCheckBoxList = new CheckedListBox();
            this.KenkuVoiceRecordingControl = new Controls.RecordingControl();
            this.KenkuRecordCommand = new PictureBox();
            this.KenkuTabControl.SuspendLayout();
            this.KenkuTextToSpeechTab.SuspendLayout();
            this.KenkuTextToSpeechGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.KenkuSplitContainer).BeginInit();
            this.KenkuSplitContainer.Panel1.SuspendLayout();
            this.KenkuSplitContainer.Panel2.SuspendLayout();
            this.KenkuSplitContainer.SuspendLayout();
            this.KenkuVoiceSelectionTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.KenkuRecordCommand).BeginInit();
            this.SuspendLayout();
            // 
            // KenkuStatusStrip
            // 
            this.KenkuStatusStrip.Location = new Point(0, 905);
            this.KenkuStatusStrip.Name = "KenkuStatusStrip";
            this.KenkuStatusStrip.Size = new Size(2176, 22);
            this.KenkuStatusStrip.TabIndex = 0;
            this.KenkuStatusStrip.Text = "KenkuStatusStrip";
            // 
            // KenkuMenuStrip
            // 
            this.KenkuMenuStrip.Location = new Point(0, 0);
            this.KenkuMenuStrip.Name = "KenkuMenuStrip";
            this.KenkuMenuStrip.Size = new Size(2176, 24);
            this.KenkuMenuStrip.TabIndex = 1;
            this.KenkuMenuStrip.Text = "menuStrip1";
            // 
            // KenkuTabControl
            // 
            this.KenkuTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.KenkuTabControl.Controls.Add(this.KenkuTextToSpeechTab);
            this.KenkuTabControl.Controls.Add(this.KenkuVoiceSelectionTabPage);
            this.KenkuTabControl.Location = new Point(3, 40);
            this.KenkuTabControl.Name = "KenkuTabControl";
            this.KenkuTabControl.SelectedIndex = 0;
            this.KenkuTabControl.Size = new Size(2173, 862);
            this.KenkuTabControl.TabIndex = 5;
            // 
            // KenkuTextToSpeechTab
            // 
            this.KenkuTextToSpeechTab.Controls.Add(this.KenkuTextToSpeechGroupBox);
            this.KenkuTextToSpeechTab.Controls.Add(this.KenkuSplitContainer);
            this.KenkuTextToSpeechTab.Location = new Point(4, 24);
            this.KenkuTextToSpeechTab.Name = "KenkuTextToSpeechTab";
            this.KenkuTextToSpeechTab.Padding = new Padding(3);
            this.KenkuTextToSpeechTab.Size = new Size(2165, 834);
            this.KenkuTextToSpeechTab.TabIndex = 0;
            this.KenkuTextToSpeechTab.Text = "Text to Speech";
            this.KenkuTextToSpeechTab.UseVisualStyleBackColor = true;
            // 
            // KenkuTextToSpeechGroupBox
            // 
            this.KenkuTextToSpeechGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.KenkuTextToSpeechGroupBox.Controls.Add(this.KenkuSimpleTextToSpeechInputText);
            this.KenkuTextToSpeechGroupBox.Controls.Add(this.label1);
            this.KenkuTextToSpeechGroupBox.Controls.Add(this.KenkuSimpleTextToSpeechVoiceSelector);
            this.KenkuTextToSpeechGroupBox.Controls.Add(this.KenkuSimpleTextToSpeechPlayCommand);
            this.KenkuTextToSpeechGroupBox.Location = new Point(11, 772);
            this.KenkuTextToSpeechGroupBox.Name = "KenkuTextToSpeechGroupBox";
            this.KenkuTextToSpeechGroupBox.Size = new Size(2146, 56);
            this.KenkuTextToSpeechGroupBox.TabIndex = 4;
            this.KenkuTextToSpeechGroupBox.TabStop = false;
            this.KenkuTextToSpeechGroupBox.Text = "Text to Speech";
            // 
            // KenkuSimpleTextToSpeechInputText
            // 
            this.KenkuSimpleTextToSpeechInputText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.KenkuSimpleTextToSpeechInputText.Location = new Point(265, 21);
            this.KenkuSimpleTextToSpeechInputText.Name = "KenkuSimpleTextToSpeechInputText";
            this.KenkuSimpleTextToSpeechInputText.Size = new Size(1833, 23);
            this.KenkuSimpleTextToSpeechInputText.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new Size(38, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Voice:";
            // 
            // KenkuSimpleTextToSpeechVoiceSelector
            // 
            this.KenkuSimpleTextToSpeechVoiceSelector.DisplayMember = "Name";
            this.KenkuSimpleTextToSpeechVoiceSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            this.KenkuSimpleTextToSpeechVoiceSelector.FormattingEnabled = true;
            this.KenkuSimpleTextToSpeechVoiceSelector.Location = new Point(65, 21);
            this.KenkuSimpleTextToSpeechVoiceSelector.Name = "KenkuSimpleTextToSpeechVoiceSelector";
            this.KenkuSimpleTextToSpeechVoiceSelector.Size = new Size(194, 23);
            this.KenkuSimpleTextToSpeechVoiceSelector.TabIndex = 2;
            this.KenkuSimpleTextToSpeechVoiceSelector.ValueMember = "Value";
            this.KenkuSimpleTextToSpeechVoiceSelector.SelectedIndexChanged += this.KenkuSimpleTextToSpeechVoiceSelector_SelectedIndexChanged;
            // 
            // KenkuSimpleTextToSpeechPlayCommand
            // 
            this.KenkuSimpleTextToSpeechPlayCommand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.KenkuSimpleTextToSpeechPlayCommand.FlatAppearance.BorderSize = 0;
            this.KenkuSimpleTextToSpeechPlayCommand.FlatStyle = FlatStyle.Flat;
            this.KenkuSimpleTextToSpeechPlayCommand.Location = new Point(2104, 13);
            this.KenkuSimpleTextToSpeechPlayCommand.Name = "KenkuSimpleTextToSpeechPlayCommand";
            this.KenkuSimpleTextToSpeechPlayCommand.Size = new Size(36, 37);
            this.KenkuSimpleTextToSpeechPlayCommand.TabIndex = 0;
            this.KenkuSimpleTextToSpeechPlayCommand.UseVisualStyleBackColor = true;
            this.KenkuSimpleTextToSpeechPlayCommand.Click += this.KenkuSimpleTextToSpeechPlayCommand_Click;
            // 
            // KenkuSplitContainer
            // 
            this.KenkuSplitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.KenkuSplitContainer.Location = new Point(3, 3);
            this.KenkuSplitContainer.Name = "KenkuSplitContainer";
            // 
            // KenkuSplitContainer.Panel1
            // 
            this.KenkuSplitContainer.Panel1.Controls.Add(this.KenkuTreeView);
            // 
            // KenkuSplitContainer.Panel2
            // 
            this.KenkuSplitContainer.Panel2.Controls.Add(this.KenkuRecordCommand);
            this.KenkuSplitContainer.Panel2.Controls.Add(this.KenkuVoiceRecordingControl);
            this.KenkuSplitContainer.Size = new Size(2156, 763);
            this.KenkuSplitContainer.SplitterDistance = 718;
            this.KenkuSplitContainer.TabIndex = 3;
            // 
            // KenkuTreeView
            // 
            this.KenkuTreeView.Dock = DockStyle.Fill;
            this.KenkuTreeView.Location = new Point(0, 0);
            this.KenkuTreeView.Name = "KenkuTreeView";
            this.KenkuTreeView.Size = new Size(718, 763);
            this.KenkuTreeView.TabIndex = 0;
            this.KenkuTreeView.NodeMouseClick += this.KenkuTreeView_NodeMouseClick;
            this.KenkuTreeView.NodeMouseDoubleClick += this.KenkuTreeView_NodeMouseDoubleClick;
            // 
            // KenkuVoiceSelectionTabPage
            // 
            this.KenkuVoiceSelectionTabPage.Controls.Add(this.KenkuVoiceSelectionUnCheckAll);
            this.KenkuVoiceSelectionTabPage.Controls.Add(this.KenkuVoiceSelectionCheckAll);
            this.KenkuVoiceSelectionTabPage.Controls.Add(this.KenkuVoiceSelectionApplyCommand);
            this.KenkuVoiceSelectionTabPage.Controls.Add(this.KenkuVoiceSelectionCheckBoxList);
            this.KenkuVoiceSelectionTabPage.Location = new Point(4, 24);
            this.KenkuVoiceSelectionTabPage.Name = "KenkuVoiceSelectionTabPage";
            this.KenkuVoiceSelectionTabPage.Size = new Size(2165, 834);
            this.KenkuVoiceSelectionTabPage.TabIndex = 2;
            this.KenkuVoiceSelectionTabPage.Text = "Voice Selection";
            this.KenkuVoiceSelectionTabPage.UseVisualStyleBackColor = true;
            // 
            // KenkuVoiceSelectionUnCheckAll
            // 
            this.KenkuVoiceSelectionUnCheckAll.Location = new Point(345, 112);
            this.KenkuVoiceSelectionUnCheckAll.Name = "KenkuVoiceSelectionUnCheckAll";
            this.KenkuVoiceSelectionUnCheckAll.Size = new Size(95, 23);
            this.KenkuVoiceSelectionUnCheckAll.TabIndex = 3;
            this.KenkuVoiceSelectionUnCheckAll.Text = "Uncheck All";
            this.KenkuVoiceSelectionUnCheckAll.UseVisualStyleBackColor = true;
            this.KenkuVoiceSelectionUnCheckAll.Click += this.KenkuVoiceSelectionUnCheckAll_Click;
            // 
            // KenkuVoiceSelectionCheckAll
            // 
            this.KenkuVoiceSelectionCheckAll.Location = new Point(345, 83);
            this.KenkuVoiceSelectionCheckAll.Name = "KenkuVoiceSelectionCheckAll";
            this.KenkuVoiceSelectionCheckAll.Size = new Size(95, 23);
            this.KenkuVoiceSelectionCheckAll.TabIndex = 2;
            this.KenkuVoiceSelectionCheckAll.Text = "Check All";
            this.KenkuVoiceSelectionCheckAll.UseVisualStyleBackColor = true;
            this.KenkuVoiceSelectionCheckAll.Click += this.KenkuVoiceSelectionCheckAll_Click;
            // 
            // KenkuVoiceSelectionApplyCommand
            // 
            this.KenkuVoiceSelectionApplyCommand.Location = new Point(345, 22);
            this.KenkuVoiceSelectionApplyCommand.Name = "KenkuVoiceSelectionApplyCommand";
            this.KenkuVoiceSelectionApplyCommand.Size = new Size(95, 23);
            this.KenkuVoiceSelectionApplyCommand.TabIndex = 1;
            this.KenkuVoiceSelectionApplyCommand.Text = "Apply";
            this.KenkuVoiceSelectionApplyCommand.UseVisualStyleBackColor = true;
            this.KenkuVoiceSelectionApplyCommand.Click += this.KenkuVoiceSelectionApplyCommand_Click;
            // 
            // KenkuVoiceSelectionCheckBoxList
            // 
            this.KenkuVoiceSelectionCheckBoxList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            this.KenkuVoiceSelectionCheckBoxList.FormattingEnabled = true;
            this.KenkuVoiceSelectionCheckBoxList.Location = new Point(19, 22);
            this.KenkuVoiceSelectionCheckBoxList.Name = "KenkuVoiceSelectionCheckBoxList";
            this.KenkuVoiceSelectionCheckBoxList.Size = new Size(320, 796);
            this.KenkuVoiceSelectionCheckBoxList.TabIndex = 0;
            // 
            // KenkuVoiceRecordingControl
            // 
            this.KenkuVoiceRecordingControl.Dock = DockStyle.Fill;
            this.KenkuVoiceRecordingControl.Location = new Point(0, 0);
            this.KenkuVoiceRecordingControl.Name = "KenkuVoiceRecordingControl";
            this.KenkuVoiceRecordingControl.Size = new Size(1434, 763);
            this.KenkuVoiceRecordingControl.TabIndex = 1;
            // 
            // KenkuRecordCommand
            // 
            this.KenkuRecordCommand.Location = new Point(3, 95);
            this.KenkuRecordCommand.Name = "KenkuRecordCommand";
            this.KenkuRecordCommand.Size = new Size(93, 93);
            this.KenkuRecordCommand.TabIndex = 2;
            this.KenkuRecordCommand.TabStop = false;
            this.KenkuRecordCommand.Click += this.KenkuRecordCommand_Click;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(2176, 927);
            this.Controls.Add(this.KenkuTabControl);
            this.Controls.Add(this.KenkuStatusStrip);
            this.Controls.Add(this.KenkuMenuStrip);
            this.Name = "Main";
            this.Text = "Kenku";
            this.KenkuTabControl.ResumeLayout(false);
            this.KenkuTextToSpeechTab.ResumeLayout(false);
            this.KenkuTextToSpeechGroupBox.ResumeLayout(false);
            this.KenkuTextToSpeechGroupBox.PerformLayout();
            this.KenkuSplitContainer.Panel1.ResumeLayout(false);
            this.KenkuSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.KenkuSplitContainer).EndInit();
            this.KenkuSplitContainer.ResumeLayout(false);
            this.KenkuVoiceSelectionTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.KenkuRecordCommand).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private StatusStrip KenkuStatusStrip;
        private MenuStrip KenkuMenuStrip;
        private TabControl KenkuTabControl;
        private TabPage KenkuTextToSpeechTab;
        private SplitContainer KenkuSplitContainer;
        private TreeView KenkuTreeView;
        private GroupBox KenkuTextToSpeechGroupBox;
        private TextBox KenkuSimpleTextToSpeechInputText;
        private Label label1;
        private ComboBox KenkuSimpleTextToSpeechVoiceSelector;
        private Button KenkuSimpleTextToSpeechPlayCommand;
        private TabPage KenkuVoiceSelectionTabPage;
        private CheckedListBox KenkuVoiceSelectionCheckBoxList;
        private Button KenkuVoiceSelectionApplyCommand;
        private Button KenkuVoiceSelectionCheckAll;
        private Button KenkuVoiceSelectionUnCheckAll;
        private PictureBox KenkuRecordCommand;
        private Controls.RecordingControl KenkuVoiceRecordingControl;
    }
}
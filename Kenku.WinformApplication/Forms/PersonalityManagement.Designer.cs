namespace Kenku.WinformApplication.Forms
{
    partial class PersonalityManagement
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
            this.OkCommand = new Button();
            this.PersonalityListBox = new ListBox();
            this.groupBox1 = new GroupBox();
            this.PersonalityDescriptionTextBox = new TextBox();
            this.PersonalityNameTextBox = new TextBox();
            this.label2 = new Label();
            this.label1 = new Label();
            this.AddCommand = new Button();
            this.groupBox2 = new GroupBox();
            this.DeleteCommand = new Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkCommand
            // 
            this.OkCommand.Location = new Point(587, 12);
            this.OkCommand.Name = "OkCommand";
            this.OkCommand.Size = new Size(75, 23);
            this.OkCommand.TabIndex = 2;
            this.OkCommand.Text = "Ok";
            this.OkCommand.UseVisualStyleBackColor = true;
            this.OkCommand.Click += this.OkCommand_Click;
            // 
            // PersonalityListBox
            // 
            this.PersonalityListBox.FormattingEnabled = true;
            this.PersonalityListBox.ItemHeight = 15;
            this.PersonalityListBox.Location = new Point(6, 25);
            this.PersonalityListBox.Name = "PersonalityListBox";
            this.PersonalityListBox.Size = new Size(156, 244);
            this.PersonalityListBox.Sorted = true;
            this.PersonalityListBox.TabIndex = 5;
            this.PersonalityListBox.SelectedIndexChanged += this.PersonalityListBox_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PersonalityDescriptionTextBox);
            this.groupBox1.Controls.Add(this.PersonalityNameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(186, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(395, 307);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personality";
            // 
            // PersonalityDescriptionTextBox
            // 
            this.PersonalityDescriptionTextBox.Location = new Point(82, 51);
            this.PersonalityDescriptionTextBox.Name = "PersonalityDescriptionTextBox";
            this.PersonalityDescriptionTextBox.Size = new Size(307, 23);
            this.PersonalityDescriptionTextBox.TabIndex = 8;
            this.PersonalityDescriptionTextBox.TextChanged += this.PersonalityDescriptionTextBox_TextChanged;
            // 
            // PersonalityNameTextBox
            // 
            this.PersonalityNameTextBox.Location = new Point(82, 22);
            this.PersonalityNameTextBox.Name = "PersonalityNameTextBox";
            this.PersonalityNameTextBox.Size = new Size(307, 23);
            this.PersonalityNameTextBox.TabIndex = 7;
            this.PersonalityNameTextBox.TextChanged += this.PersonalityNameTextBox_TextChanged;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 54);
            this.label2.Name = "label2";
            this.label2.Size = new Size(70, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(34, 25);
            this.label1.Name = "label1";
            this.label1.Size = new Size(42, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // AddCommand
            // 
            this.AddCommand.Location = new Point(6, 275);
            this.AddCommand.Name = "AddCommand";
            this.AddCommand.Size = new Size(75, 23);
            this.AddCommand.TabIndex = 8;
            this.AddCommand.Text = "New";
            this.AddCommand.UseVisualStyleBackColor = true;
            this.AddCommand.Click += this.AddCommand_Click;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteCommand);
            this.groupBox2.Controls.Add(this.PersonalityListBox);
            this.groupBox2.Controls.Add(this.AddCommand);
            this.groupBox2.Location = new Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(168, 307);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Personalities";
            // 
            // DeleteCommand
            // 
            this.DeleteCommand.Location = new Point(87, 275);
            this.DeleteCommand.Name = "DeleteCommand";
            this.DeleteCommand.Size = new Size(75, 23);
            this.DeleteCommand.TabIndex = 10;
            this.DeleteCommand.Text = "Delete";
            this.DeleteCommand.UseVisualStyleBackColor = true;
            this.DeleteCommand.Click += this.DeleteCommand_Click;
            // 
            // PersonalityManagement
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(668, 327);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OkCommand);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PersonalityManagement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.Text = "Personality Creation";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
        private Button OkCommand;
        private ListBox PersonalityListBox;
        private GroupBox groupBox1;
        private TextBox PersonalityDescriptionTextBox;
        private TextBox PersonalityNameTextBox;
        private Label label2;
        private Label label1;
        private Button AddCommand;
        private GroupBox groupBox2;
        private Button DeleteCommand;
    }
}
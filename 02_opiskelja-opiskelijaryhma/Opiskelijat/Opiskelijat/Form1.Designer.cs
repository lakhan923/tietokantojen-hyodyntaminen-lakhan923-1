namespace Opiskelijat
{
    partial class Form1
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
            studentGridView = new DataGridView();
            groupComboBox = new ComboBox();
            lastNameTextBox = new TextBox();
            AddStudentButton = new Button();
            DeleteStudentButton = new Button();
            StudentGridViewLabel = new Label();
            firstNameTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)studentGridView).BeginInit();
            SuspendLayout();
            // 
            // studentGridView
            // 
            studentGridView.BackgroundColor = SystemColors.InactiveCaption;
            studentGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            studentGridView.Location = new Point(12, 99);
            studentGridView.Name = "studentGridView";
            studentGridView.RowHeadersWidth = 51;
            studentGridView.Size = new Size(744, 339);
            studentGridView.TabIndex = 0;
            // 
            // groupComboBox
            // 
            groupComboBox.FormattingEnabled = true;
            groupComboBox.Location = new Point(344, 44);
            groupComboBox.Name = "groupComboBox";
            groupComboBox.Size = new Size(183, 28);
            groupComboBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Location = new Point(577, 190);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.PlaceholderText = "Last name";
            lastNameTextBox.Size = new Size(165, 27);
            lastNameTextBox.TabIndex = 3;
            // 
            // AddStudentButton
            // 
            AddStudentButton.BackColor = Color.FromArgb(128, 255, 255);
            AddStudentButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddStudentButton.Location = new Point(577, 252);
            AddStudentButton.Name = "AddStudentButton";
            AddStudentButton.Size = new Size(155, 43);
            AddStudentButton.TabIndex = 4;
            AddStudentButton.Text = "Add Student";
            AddStudentButton.UseVisualStyleBackColor = false;
            AddStudentButton.Click += AddStudentButton_Click;
            // 
            // DeleteStudentButton
            // 
            DeleteStudentButton.BackColor = Color.FromArgb(255, 128, 128);
            DeleteStudentButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteStudentButton.Location = new Point(577, 318);
            DeleteStudentButton.Name = "DeleteStudentButton";
            DeleteStudentButton.Size = new Size(160, 43);
            DeleteStudentButton.TabIndex = 5;
            DeleteStudentButton.Text = "Delete Student";
            DeleteStudentButton.UseVisualStyleBackColor = false;
            DeleteStudentButton.Click += DeleteStudentButton_Click;
            // 
            // StudentGridViewLabel
            // 
            StudentGridViewLabel.AutoSize = true;
            StudentGridViewLabel.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StudentGridViewLabel.Location = new Point(43, 44);
            StudentGridViewLabel.Name = "StudentGridViewLabel";
            StudentGridViewLabel.Size = new Size(264, 35);
            StudentGridViewLabel.TabIndex = 6;
            StudentGridViewLabel.Text = "Student GridView";
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Location = new Point(577, 139);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.PlaceholderText = "First name";
            firstNameTextBox.Size = new Size(165, 27);
            firstNameTextBox.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(firstNameTextBox);
            Controls.Add(StudentGridViewLabel);
            Controls.Add(DeleteStudentButton);
            Controls.Add(AddStudentButton);
            Controls.Add(lastNameTextBox);
            Controls.Add(groupComboBox);
            Controls.Add(studentGridView);
            Name = "Form1";
            Text = "DataGridView (studentGridView)";
            ((System.ComponentModel.ISupportInitialize)studentGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView studentGridView;
        private ComboBox groupComboBox;
        private TextBox lastNameTextBox;
        private Button AddStudentButton;
        private Button DeleteStudentButton;
        private Label StudentGridViewLabel;
        private TextBox firstNameTextBox;
    }
}

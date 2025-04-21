namespace vcs_project_3
{
    partial class AddTaskForm
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
            addTitle = new Label();
            addCategory = new Label();
            addDueDate = new Label();
            addPriority = new Label();
            saveButton = new Button();
            cancelButton = new Button();
            txtTitle = new TextBox();
            dtpDueDate = new DateTimePicker();
            comboPriority = new ComboBox();
            comboCategory = new ComboBox();
            SuspendLayout();
            // 
            // addTitle
            // 
            addTitle.AutoSize = true;
            addTitle.Location = new Point(68, 79);
            addTitle.Name = "addTitle";
            addTitle.Size = new Size(30, 15);
            addTitle.TabIndex = 0;
            addTitle.Text = "Title";
            // 
            // addCategory
            // 
            addCategory.AutoSize = true;
            addCategory.Location = new Point(43, 119);
            addCategory.Name = "addCategory";
            addCategory.Size = new Size(55, 15);
            addCategory.TabIndex = 1;
            addCategory.Text = "Category";
            // 
            // addDueDate
            // 
            addDueDate.AutoSize = true;
            addDueDate.Location = new Point(43, 162);
            addDueDate.Name = "addDueDate";
            addDueDate.Size = new Size(55, 15);
            addDueDate.TabIndex = 2;
            addDueDate.Text = "Due Date";
            // 
            // addPriority
            // 
            addPriority.AutoSize = true;
            addPriority.Location = new Point(53, 206);
            addPriority.Name = "addPriority";
            addPriority.Size = new Size(45, 15);
            addPriority.TabIndex = 3;
            addPriority.Text = "Priority";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(229, 262);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(103, 23);
            saveButton.TabIndex = 4;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(104, 262);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(103, 23);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(107, 76);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(225, 23);
            txtTitle.TabIndex = 10;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(104, 156);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(228, 23);
            dtpDueDate.TabIndex = 8;
            // 
            // comboPriority
            // 
            comboPriority.DisplayMember = "1";
            comboPriority.FormattingEnabled = true;
            comboPriority.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboPriority.Location = new Point(105, 203);
            comboPriority.Name = "comboPriority";
            comboPriority.Size = new Size(47, 23);
            comboPriority.TabIndex = 9;
            // 
            // comboCategory
            // 
            comboCategory.FormattingEnabled = true;
            comboCategory.Items.AddRange(new object[] { "Work", "Home", "School", "Errands", "Health", "Hobbies", "Recreation", "Financial" });
            comboCategory.Location = new Point(107, 116);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(121, 23);
            comboCategory.TabIndex = 11;
            // 
            // AddTaskForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 360);
            Controls.Add(comboCategory);
            Controls.Add(comboPriority);
            Controls.Add(dtpDueDate);
            Controls.Add(txtTitle);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(addPriority);
            Controls.Add(addDueDate);
            Controls.Add(addCategory);
            Controls.Add(addTitle);
            Name = "AddTaskForm";
            Text = "AddTaskForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label addTitle;
        private Label addCategory;
        private Label addDueDate;
        private Label addPriority;
        private Button saveButton;
        private Button cancelButton;
        private TextBox txtTitle;
        private DateTimePicker dtpDueDate;
        private ComboBox comboPriority;
        private ComboBox comboCategory;
    }
}
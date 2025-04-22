namespace vcs_project_3
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
            ComboBox comboSort;
            taskLabel = new Label();
            createButton = new Button();
            editButton = new Button();
            taskListView = new ListView();
            taskTitle = new ColumnHeader();
            taskDueDate = new ColumnHeader();
            taskPriority = new ColumnHeader();
            taskCategory = new ColumnHeader();
            markCompleteButton = new Button();
            deleteButton = new Button();
            sortByLabel = new Label();
            showCompleteButton = new Button();
            comboSort = new ComboBox();
            SuspendLayout();
            // 
            // comboSort
            // 
            comboSort.Items.AddRange(new object[] { "Errands", "Financial", "Health", "Hobbies", "Home", "Recreation", "School", "Work" });
            comboSort.Location = new Point(118, 431);
            comboSort.Name = "comboSort";
            comboSort.Size = new Size(121, 33);
            comboSort.Sorted = true;
            comboSort.TabIndex = 12;
            comboSort.SelectedIndexChanged += comboSort_SelectedIndexChanged;
            // 
            // taskLabel
            // 
            taskLabel.AutoSize = true;
            taskLabel.Font = new Font("Segoe UI", 20F);
            taskLabel.Location = new Point(38, 68);
            taskLabel.Margin = new Padding(5, 0, 5, 0);
            taskLabel.Name = "taskLabel";
            taskLabel.Size = new Size(266, 37);
            taskLabel.TabIndex = 1;
            taskLabel.Text = "Create and Edit Tasks";
            // 
            // createButton
            // 
            createButton.Location = new Point(38, 369);
            createButton.Name = "createButton";
            createButton.Size = new Size(124, 32);
            createButton.TabIndex = 3;
            createButton.Text = "Create Task";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(225, 369);
            editButton.Name = "editButton";
            editButton.Size = new Size(124, 32);
            editButton.TabIndex = 4;
            editButton.Text = "Edit Task";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // taskListView
            // 
            taskListView.Columns.AddRange(new ColumnHeader[] { taskTitle, taskDueDate, taskPriority, taskCategory });
            taskListView.FullRowSelect = true;
            taskListView.Location = new Point(38, 117);
            taskListView.Name = "taskListView";
            taskListView.Scrollable = false;
            taskListView.Size = new Size(720, 222);
            taskListView.TabIndex = 5;
            taskListView.UseCompatibleStateImageBehavior = false;
            taskListView.View = View.Details;
            // 
            // taskTitle
            // 
            taskTitle.Text = "Title";
            taskTitle.TextAlign = HorizontalAlignment.Center;
            taskTitle.Width = 278;
            // 
            // taskDueDate
            // 
            taskDueDate.Text = "Due Date";
            taskDueDate.TextAlign = HorizontalAlignment.Center;
            taskDueDate.Width = 150;
            // 
            // taskPriority
            // 
            taskPriority.Text = "Priority";
            taskPriority.TextAlign = HorizontalAlignment.Center;
            taskPriority.Width = 100;
            // 
            // taskCategory
            // 
            taskCategory.Text = "Category";
            taskCategory.TextAlign = HorizontalAlignment.Center;
            taskCategory.Width = 190;
            // 
            // markCompleteButton
            // 
            markCompleteButton.Location = new Point(412, 369);
            markCompleteButton.Name = "markCompleteButton";
            markCompleteButton.Size = new Size(159, 32);
            markCompleteButton.TabIndex = 6;
            markCompleteButton.Text = "Mark Complete";
            markCompleteButton.UseVisualStyleBackColor = true;
            markCompleteButton.Click += markCompleteButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(634, 369);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(124, 32);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // sortByLabel
            // 
            sortByLabel.AutoSize = true;
            sortByLabel.Location = new Point(37, 434);
            sortByLabel.Name = "sortByLabel";
            sortByLabel.Size = new Size(75, 25);
            sortByLabel.TabIndex = 9;
            sortByLabel.Text = "Sort by:";
            // 
            // showCompleteButton
            // 
            showCompleteButton.Location = new Point(603, 423);
            showCompleteButton.Name = "showCompleteButton";
            showCompleteButton.Size = new Size(155, 36);
            showCompleteButton.TabIndex = 13;
            showCompleteButton.Text = "Show Complete";
            showCompleteButton.UseVisualStyleBackColor = true;
            showCompleteButton.Click += showCompleteButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(796, 533);
            Controls.Add(showCompleteButton);
            Controls.Add(sortByLabel);
            Controls.Add(comboSort);
            Controls.Add(deleteButton);
            Controls.Add(markCompleteButton);
            Controls.Add(taskListView);
            Controls.Add(editButton);
            Controls.Add(createButton);
            Controls.Add(taskLabel);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Task Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label taskLabel;
        private Button createButton;
        private Button editButton;
        private ListView taskListView;
        private ColumnHeader taskTitle;
        private ColumnHeader taskDueDate;
        private ColumnHeader taskPriority;
        private ColumnHeader taskCategory;
        private Button markCompleteButton;
        private Button deleteButton;
        private ComboBox comboSort;
        private Label sortByLabel;
        private Button showCompleteButton;
    }
}

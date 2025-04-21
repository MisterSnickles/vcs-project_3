using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vcs_project_3
{
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();
        }
        public Form1.TodoTask createdTask { get; private set; }


        private Form1.TodoTask existingTask;

        public AddTaskForm(Form1.TodoTask taskToEdit = null)
        {
            InitializeComponent();

            if (taskToEdit != null)
            {
                existingTask = taskToEdit;
                txtTitle.Text = taskToEdit.Title;
                comboCategory.Text = taskToEdit.Category;
                dtpDueDate.Value = taskToEdit.DueDate;
                comboPriority.Text = taskToEdit.Priority.ToString();
            }
        }


        // button member functions
        private void saveButton_Click(object sender, EventArgs e)
        {
            createdTask = new Form1.TodoTask()
            {
                Title = txtTitle.Text,
                Category = comboCategory.Text,
                DueDate = dtpDueDate.Value,
                Priority = int.TryParse(comboPriority.Text, out int p) ? p : 1,
                IsComplete = false
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using Microsoft.Data.SqlClient;
using System.Configuration;


namespace vcs_project_3
{

    public partial class Form1 : Form
    {
        public interface Tracker
        {
            public bool IsComplete { get; set; }
            void markComplete();
        }


        public class TodoTask : Tracker
        {
            public int ID { get; set; } // for database
            public string Title { get; set; }
            public string Category { get; set; }
            public DateTime DueDate { get; set; }
            public int Priority { get; set; }
            public bool IsComplete { get; set; }


            // definition of interface "Tracker" abstract methods
            public void markComplete()
            {
                IsComplete = true;
            }
        }

        // non-design action functions --------------------------------------------------------------
        public void LoadTasks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyLocalDb"].ConnectionString;
            taskListView.Items.Clear();

            string query = "SELECT * FROM [Task]";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string title = reader["task_title"].ToString();
                    string category = reader["task_category"].ToString();
                    DateTime dueDate = Convert.ToDateTime(reader["task_due_date"]);
                    int priority = (int)reader["task_priority"];
                    bool isComplete = reader["task_is_complete"] != DBNull.Value && (bool)reader["task_is_complete"];

                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(title);
                    item.SubItems.Add(dueDate.ToShortDateString());
                    item.SubItems.Add(priority.ToString());
                    item.SubItems.Add(category);

                    taskListView.Items.Add(item);
                }
            }
        }

        private void CreateTask(TodoTask newTask)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyLocalDb"].ConnectionString;

            string query = @"INSERT INTO [TASK]
                            (task_title, task_category, task_due_date, task_priority, task_is_complete)
                            VALUES (@Title, @Category, @DueDate, @Priority, @IsComplete)";

            using (SqlConnection connection = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Title", newTask.Title);
                cmd.Parameters.AddWithValue("@Category", newTask.Category);
                cmd.Parameters.AddWithValue("@DueDate", newTask.DueDate);
                cmd.Parameters.AddWithValue("@Priority", newTask.Priority);
                cmd.Parameters.AddWithValue("@IsComplete", newTask.IsComplete);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // when program runs
        public Form1()
        {
            InitializeComponent();
            LoadTasks();
        }


        // button member functions ----------------------------------------

        private void createButton_Click(object sender, EventArgs e)
        {
            using (AddTaskForm form = new AddTaskForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Get the task from the pop-up form
                    Form1.TodoTask newTask = form.createdTask;

                    // Insert it into the database
                    CreateTask(newTask);

                    // Optional: reload the list
                    LoadTasks();
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (taskListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem selectedItem = taskListView.SelectedItems[0];
            int taskId = (int)selectedItem.Tag;

            // get task from database
            //TodoTask taskToEdit = GetTaskById(taskId);

            //if (taskToEdit == null)
            //{
            //    MessageBox.Show("Task not found.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //// show edit form with the task already there
            //AddTaskForm editForm = new AddTaskForm(taskToEdit);
        }
    }
}

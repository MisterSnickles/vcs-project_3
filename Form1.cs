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
            public int TID { get; set; } // for database
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

        // for category sorting
        private void LoadTasksByCategory(string category)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyLocalDb"].ConnectionString;
            taskListView.Items.Clear();

            string query = "SELECT * FROM [Task]";
            if (category != "All")
            {
                query += " WHERE task_category = @Category";
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (category != "All")
                {
                    cmd.Parameters.AddWithValue("@Category", category);
                }

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string title = reader["task_title"].ToString();
                    string taskCategory = reader["task_category"].ToString();
                    DateTime dueDate = Convert.ToDateTime(reader["task_due_date"]);
                    int priority = (int)reader["task_priority"];

                    ListViewItem item = new ListViewItem(title);
                    item.Tag = reader["task_id"];
                    item.SubItems.Add(dueDate.ToShortDateString());
                    item.SubItems.Add(priority.ToString());
                    item.SubItems.Add(taskCategory);

                    taskListView.Items.Add(item);
                }
            }
        }

        // to update the task that is being edited
        private void UpdateTask(TodoTask task)
        {
            // define connection to database and pass query to update Task
            string connStr = ConfigurationManager.ConnectionStrings["MyLocalDb"].ConnectionString;
            string query = @"UPDATE [Task]
                     SET task_title = @Title,
                         task_category = @Category,
                         task_due_date = @DueDate,
                         task_priority = @Priority,
                         task_is_complete = @IsComplete
                     WHERE task_id = @Id";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Title", task.Title);
                cmd.Parameters.AddWithValue("@Category", task.Category);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate);
                cmd.Parameters.AddWithValue("@Priority", task.Priority);
                cmd.Parameters.AddWithValue("@IsComplete", task.IsComplete);
                cmd.Parameters.AddWithValue("@Id", task.TID);

                // open the connection and execute the query using the defined values above
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void LoadTasks()
        {

            // define connection to database
            string connectionString = ConfigurationManager.ConnectionStrings["MyLocalDb"].ConnectionString;
            taskListView.Items.Clear();

            // select all task objects from task table
            string query = "SELECT * FROM [Task]";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {

                // open connection and read from database
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    // define the members of a task and add it to the ListView
                    string title = reader["task_title"].ToString();
                    string category = reader["task_category"].ToString();
                    DateTime dueDate = Convert.ToDateTime(reader["task_due_date"]);
                    int priority = (int)reader["task_priority"];
                    bool isComplete = reader["task_is_complete"] != DBNull.Value && (bool)reader["task_is_complete"];

                    ListViewItem item = new ListViewItem(title);
                    item.Tag = reader["task_id"];

                    item.SubItems.Add(dueDate.ToShortDateString());
                    item.SubItems.Add(priority.ToString());
                    item.SubItems.Add(category);

                    taskListView.Items.Add(item);
                }
            }
        }

        private void CreateTask(TodoTask newTask)
        {
            // define connection to database
            string connStr = ConfigurationManager.ConnectionStrings["MyLocalDb"].ConnectionString;

            // define query that inserts a task into task with the incoming parameters
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


                // open connection and execute the query that utilizes the incoming variables to create a task
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private TodoTask GetTaskById(int id)
        {
            // Set up connection string and set a SQL database query to select every element from Task table that has a matching ID
            string connStr = ConfigurationManager.ConnectionStrings["MyLocalDb"].ConnectionString;
            string query = "SELECT * FROM [Task] WHERE task_id = @id";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TodoTask()
                        {
                            TID = (int)reader["task_id"],
                            Title = reader["task_title"].ToString(),
                            Category = reader["task_category"].ToString(),
                            DueDate = Convert.ToDateTime(reader["task_due_date"]),
                            Priority = (int)reader["task_priority"],
                            IsComplete = (bool)reader["task_is_complete"]
                        };
                    }
                }
            }

            return null;
        }

        private void DeleteTask(int id)
        {
            // define connection to database
            string connStr = ConfigurationManager.ConnectionStrings["MyLocalDb"].ConnectionString;

            // define query that deletes a task from task table where the id matches
            string query = "DELETE FROM [Task] WHERE task_id = @id";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {

                // open database connection and execute query using the provided id
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
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

            // if no tasks are selected
            if (taskListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a task to edit.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem selectedItem = taskListView.SelectedItems[0];
            int taskId = (int)selectedItem.Tag;

            if (selectedItem.Tag == null)
            {
                MessageBox.Show("No task ID associated with selected item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // get task from database using id
            TodoTask taskToEdit = GetTaskById(taskId);

            if (taskToEdit == null)
            {
                MessageBox.Show("Task not found.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // show edit form with the task already there
            using (AddTaskForm editForm = new AddTaskForm(taskToEdit))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    TodoTask updatedTask = editForm.createdTask;
                    updatedTask.TID = taskId;

                    UpdateTask(updatedTask);
                    LoadTasks();
                }
            }
        }

        private void markCompleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem selectedItem = taskListView.SelectedItems[0];

                if (selectedItem.Tag == null)
                {
                    MessageBox.Show("No task ID found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int taskID = (int)selectedItem.Tag;
                TodoTask task = GetTaskById(taskID);

                if (task == null)
                {
                    MessageBox.Show("Task not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                task.markComplete();
                UpdateTask(task);
                LoadTasks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error when marking complete:\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void showCompleteButton_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyLocalDb"].ConnectionString;
            taskListView.Items.Clear();

            string query = "SELECT * FROM [Task] WHERE task_is_complete = 1";

            using (SqlConnection conn = new SqlConnection(connStr))
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
                    int taskId = (int)reader["task_id"];

                    ListViewItem item = new ListViewItem(title);
                    item.Tag = taskId;
                    item.SubItems.Add(dueDate.ToShortDateString());
                    item.SubItems.Add(priority.ToString());
                    item.SubItems.Add(category);
                    item.BackColor = Color.DarkGray; // to seperate completed tasks visually

                    taskListView.Items.Add(item);
                }
            }
        }

        private void comboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboSort != null && comboSort.SelectedItem != null)
            {
                string selectedCategory = comboSort.SelectedItem.ToString();
                LoadTasksByCategory(selectedCategory);
            }
            else
            {
                MessageBox.Show("ComboBox is not initialized or no item is selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {

                // if no task is selected in taskListView
                if (taskListView.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select a task to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ListViewItem selectedItem = taskListView.SelectedItems[0];

                if (selectedItem.Tag == null)
                {
                    MessageBox.Show("No task ID associated with selected item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int taskId = (int)selectedItem.Tag;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteTask(taskId);
                    LoadTasks(); // Refresh the ListView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error while deleting the task:\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

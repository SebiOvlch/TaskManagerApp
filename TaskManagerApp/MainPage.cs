using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static TaskManagerApp.LoginPage;

namespace TaskManagerApp
{
    public partial class MainPage : Form
    {
        string userId = Properties.Settings.Default.UserId;
        string currName = Properties.Settings.Default.Name;

        public class UserChecklistData
        {
            public string UserId { get; set; } 
            public List<ChecklistItem> Items { get; set; } = new List<ChecklistItem>();
        }

        public class ChecklistItem
        {
            public string Text { get; set; }
            public bool IsChecked { get; set; } 
        }

        private void SaveCheckedListBoxData(string userId, CheckedListBox checkedListBox, string filePath)
        {
            try
            {
                List<UserChecklistData> allData = new List<UserChecklistData>();
                if (File.Exists(filePath))
                {
                    string existingJson = File.ReadAllText(filePath);
                    allData = System.Text.Json.JsonSerializer.Deserialize<List<UserChecklistData>>(existingJson) ?? new List<UserChecklistData>();
                }

                var userData = new UserChecklistData
                {
                    UserId = userId,
                    Items = checkedListBox.Items.Cast<object>()
                        .Select((item, index) => new ChecklistItem
                        {
                            Text = item.ToString(),
                            IsChecked = checkedListBox.GetItemChecked(index)
                        }).ToList()
                };

                allData.RemoveAll(data => data.UserId == userId);
                allData.Add(userData);

                string json = System.Text.Json.JsonSerializer.Serialize(allData, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCheckedListBoxData(string userId, CheckedListBox checkedListBox, string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    todoList = new List<TodoItem>();
                    return;
                }

                string json = File.ReadAllText(filePath);
                var allData = System.Text.Json.JsonSerializer.Deserialize<List<UserChecklistData>>(json) ?? new List<UserChecklistData>();

                var userData = allData.FirstOrDefault(data => data.UserId == userId);
                if (userData != null)
                {
                    checkedListBox.Items.Clear();
                    foreach (var item in userData.Items)
                    {
                        checkedListBox.Items.Add(item.Text, item.IsChecked);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveTasksToFile(string filePath)
        {
            List<TaskItem> allTasks = new List<TaskItem>();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                allTasks = System.Text.Json.JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }

            allTasks.RemoveAll(task => task.UserId == userId);
            allTasks.AddRange(taskList);

            string updatedJson = System.Text.Json.JsonSerializer.Serialize(allTasks, new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, updatedJson);
        }

        private void LoadTasksFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var allTasks = System.Text.Json.JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();

                taskList = allTasks.Where(task => task.UserId == userId).ToList();
            }
            else
            {
                taskList = new List<TaskItem>();
            }
            RefreshTaskList();
        }

        public class TaskItem
        {
            public string UserId { get; set; }
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime DueDate { get; set; }
            public TaskPriority Priority { get; set; }
            public TaskStatus Status { get; set; }
        }

        public enum TaskPriority
        {
            Low,
            Medium,
            High
        }

        public enum TaskStatus
        {
            Pending,
            InProgress,
            Completed
        }

        public class TodoItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public bool IsDone { get; set; }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        List<TaskItem> taskList = new List<TaskItem>();
        List<TodoItem> todoList = new List<TodoItem>();
        private void MainPage_Load(object sender, EventArgs e)
        {

            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadCheckedListBoxData(userId, chkLstBoxToDo, "todos.json");
            LoadTasksFromFile("tasks.json");

            lblWelcome.Text = $"Welcome {currName}!";
            lblTasks.BackColor = SystemColors.ButtonShadow;
            lblToDo.BackColor = SystemColors.GrayText;
            ToDoPanel.Visible = false;
            TaskPanel.Visible = true;


            dgvTasks.DataSource = taskList.Select(t => new
            {
                t.Id,
                t.Title,
                t.Description,
                t.DueDate,
                t.Priority,
                t.Status
            }).ToList();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            var newTask = new TaskItem
            {
                UserId = userId,
                Id = taskList.Count + 1,
                Title = "New Task",
                Description = "Give the description",
                DueDate = DateTime.Now.AddDays(7),
                Priority = TaskPriority.Low,
                Status = TaskStatus.Pending
            };

            taskList.Add(newTask);
            RefreshTaskList();
        }

        private void RefreshTaskList()
        {
            dgvTasks.DataSource = null; 
            dgvTasks.DataSource = taskList.Select(t => new
            {
                t.Id,
                t.Title,
                t.Description,
                t.DueDate,
                t.Priority,
                t.Status
            }).ToList();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Choose a task to edit!");
                return;
            }

            int selectedTaskId = (int)dgvTasks.SelectedRows[0].Cells["Id"].Value;

            TaskItem selectedTask = taskList.FirstOrDefault(t => t.Id == selectedTaskId);

            if (selectedTask == null)
            {
                MessageBox.Show("Couldn't find the task!");
                return;
            }

            EditTaskForm editForm = new EditTaskForm(selectedTask);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshTaskList();
            }
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {

            string filePath = "tasks.json";
            string filePath_Todo = "todos.json";
            if (Properties.Settings.Default.RememberMe == false)
                CloseApp();
            try
            {
                SaveCheckedListBoxData(userId, chkLstBoxToDo, filePath_Todo);
                SaveTasksToFile(filePath); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            System.Environment.Exit(0);
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (dgvTasks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose a task to delete!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = dgvTasks.SelectedRows[0].Index;

            if (selectedIndex < 0 || selectedIndex >= taskList.Count)
            {
                MessageBox.Show("Something went wrong!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected task?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            taskList.RemoveAt(selectedIndex);

            RefreshTaskList();
        }

        private void lblTasks_Click(object sender, EventArgs e)
        {
            lblTasks.BackColor = SystemColors.ButtonShadow;
            lblToDo.BackColor = SystemColors.GrayText;
            ToDoPanel.Visible = false;
            TaskPanel.Visible = true;


        }

        private void lblToDo_Click(object sender, EventArgs e)
        {
            lblToDo.BackColor = SystemColors.ButtonShadow;
            lblTasks.BackColor = SystemColors.GrayText;
            TaskPanel.Visible = false;
            ToDoPanel.Visible = true;

        }

        private void btnAddTodo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTodo.Text))
            {
                chkLstBoxToDo.Items.Add(txtTodo.Text);

                txtTodo.Text = "Add Task";

                txtTodo.Focus();
            }
            else
            {
                MessageBox.Show("Please write in a task!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteTodo_Click(object sender, EventArgs e)
        {
            if (chkLstBoxToDo.SelectedItem != null)
            {
                chkLstBoxToDo.Items.Remove(chkLstBoxToDo.SelectedItem);
            }
            else
            {
                MessageBox.Show("Please choose a task, you want to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want Log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            CloseApp();

            this.Hide();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }

        private void CloseApp()
        {
            Properties.Settings.Default.Reset();
            Properties.Settings.Default.RememberMe = false;
            Properties.Settings.Default.Password = "";
        }

        private void btnEdit_click(object sender, EventArgs e)
        {
            if (chkLstBoxToDo.SelectedItem == null)
            {
                MessageBox.Show("Choose a task to edit!", "Error");
                return;
            }

            string selectedItem = chkLstBoxToDo.SelectedItem.ToString();

           
            using (EditToDo editForm = new EditToDo())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    int selectedIndex = chkLstBoxToDo.SelectedIndex;
                    chkLstBoxToDo.Items[selectedIndex] = editForm.EditedValue;
                }
            }
        }

    }
}

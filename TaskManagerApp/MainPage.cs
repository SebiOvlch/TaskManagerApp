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
            public string UserId { get; set; } // A felhasználó azonosítója
            public List<ChecklistItem> Items { get; set; } = new List<ChecklistItem>();
        }

        public class ChecklistItem
        {
            public string Text { get; set; } // Az elem szövege
            public bool IsChecked { get; set; } // Az elem kiválasztott állapota
        }

        private void SaveCheckedListBoxData(string userId, CheckedListBox checkedListBox, string filePath)
        {
            try
            {
                // Ellenőrizzük, hogy létezik-e már az adatfájl
                List<UserChecklistData> allData = new List<UserChecklistData>();
                if (File.Exists(filePath))
                {
                    string existingJson = File.ReadAllText(filePath);
                    allData = System.Text.Json.JsonSerializer.Deserialize<List<UserChecklistData>>(existingJson) ?? new List<UserChecklistData>();
                }

                // Gyűjtsük össze az aktuális felhasználó adatait
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

                // Töröljük a régi adatokat az adott UserId-hoz
                allData.RemoveAll(data => data.UserId == userId);
                allData.Add(userData);

                // Mentés JSON fájlba
                string json = System.Text.Json.JsonSerializer.Serialize(allData, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, json);
                //MessageBox.Show("Adatok sikeresen mentve!", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Ellenőrizzük, hogy létezik-e a fájl
                if (!File.Exists(filePath))
                {
                    todoList = new List<TodoItem>();
                    return;
                }

                // JSON betöltése
                string json = File.ReadAllText(filePath);
                var allData = System.Text.Json.JsonSerializer.Deserialize<List<UserChecklistData>>(json) ?? new List<UserChecklistData>();

                // Keresd meg az aktuális felhasználó adatait
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

            // Csak az aktuális felhasználóhoz tartozó adatok cseréje
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

                // Szűrés az aktuális felhasználó adataira

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


            // DataGridView beállítása
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
            dgvTasks.DataSource = null; // Frissítés
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

            // Kiválasztott feladat ID-jának lekérése
            int selectedTaskId = (int)dgvTasks.SelectedRows[0].Cells["Id"].Value;

            // A taskList-ből megkeressük a megfelelő TaskItem objektumot
            TaskItem selectedTask = taskList.FirstOrDefault(t => t.Id == selectedTaskId);

            if (selectedTask == null)
            {
                MessageBox.Show("Couldn't find the task!");
                return;
            }

            // Az EditTaskForm megnyitása, és a kiválasztott TaskItem átadása
            EditTaskForm editForm = new EditTaskForm(selectedTask);

            // Ha a szerkesztő űrlapon a mentést választotta a felhasználó
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                RefreshTaskList(); // Frissítjük a feladatok listáját
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
                SaveTasksToFile(filePath); // Hívjuk meg a mentési metódust
            }
            catch (Exception ex)
            {
                // Ha hiba történik a mentés során, jelezd az üzenetablakban
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

            // A kiválasztott sor indexe
            int selectedIndex = dgvTasks.SelectedRows[0].Index;

            // Ellenőrizzük, hogy az index érvényes-e
            if (selectedIndex < 0 || selectedIndex >= taskList.Count)
            {
                MessageBox.Show("Something went wrong!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Megerősítés kérés
            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected task?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            // Törlés a listából
            taskList.RemoveAt(selectedIndex);

            // DataGridView frissítése
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
            // Ellenőrizzük, hogy a TextBox nem üres
            if (!string.IsNullOrWhiteSpace(txtTodo.Text))
            {
                // A feladat hozzáadása a ListBox-hoz
                chkLstBoxToDo.Items.Add(txtTodo.Text);

                // A TextBox kiürítése
                txtTodo.Text = "Add Task";

                // A fókusz visszaállítása a TextBox-ra
                txtTodo.Focus();
            }
            else
            {
                MessageBox.Show("Please write in a task!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteTodo_Click(object sender, EventArgs e)
        {
            // Ellenőrizzük, hogy van-e kiválasztott elem
            if (chkLstBoxToDo.SelectedItem != null)
            {
                // Törlés a ListBox-ból
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

            // Megnyitjuk a Form2-t szerkesztéshez
            using (EditToDo editForm = new EditToDo())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Frissítjük az elemet a szerkesztett értékre
                    int selectedIndex = chkLstBoxToDo.SelectedIndex;
                    chkLstBoxToDo.Items[selectedIndex] = editForm.EditedValue;
                }
            }
        }

    }
}

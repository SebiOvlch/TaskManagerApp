using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TaskManagerApp.MainPage;

namespace TaskManagerApp{
    public partial class EditTaskForm : Form
    {
        public TaskItem EditedTask { get; private set; }

        public EditTaskForm(TaskItem task)
        {
            InitializeComponent();

            EditedTask = task;
            txtTitle.Text = task.Title;
            txtDescription.Text = task.Description;
            dtpDueDate.Value = task.DueDate;
            cmbPriority.DataSource = Enum.GetValues(typeof(TaskPriority));
            cmbStatus.DataSource = Enum.GetValues(typeof(MainPage.TaskStatus));
            cmbPriority.SelectedItem = task.Priority;
            cmbStatus.SelectedItem = task.Status;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            EditedTask.Title = txtTitle.Text;
            EditedTask.Description = txtDescription.Text;
            EditedTask.DueDate = dtpDueDate.Value;
            EditedTask.Priority = (TaskPriority)cmbPriority.SelectedItem;
            EditedTask.Status = (MainPage.TaskStatus)cmbStatus.SelectedItem;

            // Állítsuk be az űrlap visszatérési értékét OK-ra, és zárjuk be az űrlapot
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

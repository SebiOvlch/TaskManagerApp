namespace TaskManagerApp
{
    partial class MainPage
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
            dgvTasks = new DataGridView();
            btnAddTask = new Button();
            btnEditTask = new Button();
            btnDeleteTask = new Button();
            TaskPanel = new Panel();
            ToDoPanel = new Panel();
            chkLstBoxToDo = new CheckedListBox();
            btnDeleteTodo = new Button();
            btnEdit = new Button();
            btnAddTodo = new Button();
            txtTodo = new TextBox();
            lblTasks = new Label();
            lblToDo = new Label();
            lblWelcome = new Label();
            lblLogOut = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            TaskPanel.SuspendLayout();
            ToDoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTasks
            // 
            dgvTasks.Anchor = AnchorStyles.None;
            dgvTasks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTasks.BackgroundColor = Color.DarkSlateGray;
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Location = new Point(161, 8);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowHeadersWidth = 50;
            dgvTasks.ScrollBars = ScrollBars.Horizontal;
            dgvTasks.Size = new Size(962, 789);
            dgvTasks.TabIndex = 0;
            // 
            // btnAddTask
            // 
            btnAddTask.Anchor = AnchorStyles.None;
            btnAddTask.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            btnAddTask.Location = new Point(1151, 8);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(120, 45);
            btnAddTask.TabIndex = 1;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnEditTask
            // 
            btnEditTask.Anchor = AnchorStyles.None;
            btnEditTask.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            btnEditTask.Location = new Point(1151, 59);
            btnEditTask.Name = "btnEditTask";
            btnEditTask.Size = new Size(120, 45);
            btnEditTask.TabIndex = 1;
            btnEditTask.Text = "Edit Task";
            btnEditTask.UseVisualStyleBackColor = true;
            btnEditTask.Click += btnEditTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Anchor = AnchorStyles.None;
            btnDeleteTask.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            btnDeleteTask.Location = new Point(1151, 110);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(120, 45);
            btnDeleteTask.TabIndex = 1;
            btnDeleteTask.Text = "Delete";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // TaskPanel
            // 
            TaskPanel.Anchor = AnchorStyles.None;
            TaskPanel.AutoSize = true;
            TaskPanel.BackColor = Color.DarkSlateGray;
            TaskPanel.Controls.Add(dgvTasks);
            TaskPanel.Controls.Add(btnDeleteTask);
            TaskPanel.Controls.Add(btnAddTask);
            TaskPanel.Controls.Add(btnEditTask);
            TaskPanel.Location = new Point(0, 87);
            TaskPanel.Name = "TaskPanel";
            TaskPanel.Size = new Size(1285, 869);
            TaskPanel.TabIndex = 2;
            // 
            // ToDoPanel
            // 
            ToDoPanel.BackColor = Color.DarkSlateGray;
            ToDoPanel.Controls.Add(chkLstBoxToDo);
            ToDoPanel.Controls.Add(btnDeleteTodo);
            ToDoPanel.Controls.Add(btnEdit);
            ToDoPanel.Controls.Add(btnAddTodo);
            ToDoPanel.Controls.Add(txtTodo);
            ToDoPanel.Location = new Point(89, 74);
            ToDoPanel.Name = "ToDoPanel";
            ToDoPanel.Size = new Size(1104, 800);
            ToDoPanel.TabIndex = 2;
            ToDoPanel.Visible = false;
            // 
            // chkLstBoxToDo
            // 
            chkLstBoxToDo.BackColor = Color.DarkSlateGray;
            chkLstBoxToDo.BorderStyle = BorderStyle.None;
            chkLstBoxToDo.Font = new Font("Times New Roman", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            chkLstBoxToDo.FormattingEnabled = true;
            chkLstBoxToDo.Location = new Point(162, 164);
            chkLstBoxToDo.Name = "chkLstBoxToDo";
            chkLstBoxToDo.Size = new Size(631, 476);
            chkLstBoxToDo.TabIndex = 3;
            // 
            // btnDeleteTodo
            // 
            btnDeleteTodo.Location = new Point(944, 147);
            btnDeleteTodo.Name = "btnDeleteTodo";
            btnDeleteTodo.Size = new Size(90, 50);
            btnDeleteTodo.TabIndex = 2;
            btnDeleteTodo.Text = "Delete";
            btnDeleteTodo.UseVisualStyleBackColor = true;
            btnDeleteTodo.Click += btnDeleteTodo_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(834, 147);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(90, 50);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_click;
            // 
            // btnAddTodo
            // 
            btnAddTodo.Location = new Point(834, 89);
            btnAddTodo.Name = "btnAddTodo";
            btnAddTodo.Size = new Size(200, 50);
            btnAddTodo.TabIndex = 2;
            btnAddTodo.Text = "Add";
            btnAddTodo.UseVisualStyleBackColor = true;
            btnAddTodo.Click += btnAddTodo_Click;
            // 
            // txtTodo
            // 
            txtTodo.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 238);
            txtTodo.Location = new Point(163, 96);
            txtTodo.Name = "txtTodo";
            txtTodo.Size = new Size(630, 30);
            txtTodo.TabIndex = 1;
            txtTodo.Text = "Add Task";
            // 
            // lblTasks
            // 
            lblTasks.AutoSize = true;
            lblTasks.BackColor = SystemColors.ButtonShadow;
            lblTasks.Cursor = Cursors.Hand;
            lblTasks.Font = new Font("Times New Roman", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblTasks.ForeColor = SystemColors.ActiveCaptionText;
            lblTasks.Location = new Point(25, 9);
            lblTasks.Name = "lblTasks";
            lblTasks.Size = new Size(106, 42);
            lblTasks.TabIndex = 3;
            lblTasks.Text = "Tasks";
            lblTasks.Click += lblTasks_Click;
            // 
            // lblToDo
            // 
            lblToDo.AutoSize = true;
            lblToDo.BackColor = SystemColors.ButtonShadow;
            lblToDo.Cursor = Cursors.Hand;
            lblToDo.Font = new Font("Times New Roman", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblToDo.ForeColor = SystemColors.ActiveCaptionText;
            lblToDo.Location = new Point(160, 9);
            lblToDo.Name = "lblToDo";
            lblToDo.Size = new Size(182, 42);
            lblToDo.TabIndex = 3;
            lblToDo.Text = "To Do List";
            lblToDo.Click += lblToDo_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Rockwell", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(616, 17);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(0, 42);
            lblWelcome.TabIndex = 4;
            // 
            // lblLogOut
            // 
            lblLogOut.AutoSize = true;
            lblLogOut.BackColor = Color.FromArgb(255, 100, 100);
            lblLogOut.BorderStyle = BorderStyle.FixedSingle;
            lblLogOut.Cursor = Cursors.Hand;
            lblLogOut.Font = new Font("Tahoma", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblLogOut.Location = new Point(1150, 15);
            lblLogOut.Name = "lblLogOut";
            lblLogOut.Size = new Size(110, 36);
            lblLogOut.TabIndex = 5;
            lblLogOut.Text = "Log out";
            lblLogOut.Click += lblLogOut_Click;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1282, 953);
            Controls.Add(lblLogOut);
            Controls.Add(lblWelcome);
            Controls.Add(lblToDo);
            Controls.Add(lblTasks);
            Controls.Add(ToDoPanel);
            Controls.Add(TaskPanel);
            MinimumSize = new Size(1300, 850);
            Name = "MainPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task Manager";
            FormClosing += MainPage_FormClosing;
            Load += MainPage_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            TaskPanel.ResumeLayout(false);
            ToDoPanel.ResumeLayout(false);
            ToDoPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTasks;
        private Button btnAddTask;
        private Button btnEditTask;
        private Button btnDeleteTask;
        private Panel TaskPanel;
        private Label lblTasks;
        private Label lblToDo;
        private Panel ToDoPanel;
        private Button btnDeleteTodo;
        private Button btnAddTodo;
        private TextBox txtTodo;
        private Label lblWelcome;
        private Label lblLogOut;
        private CheckedListBox chkLstBoxToDo;
        private Button btnEdit;
    }
}
namespace TaskManagerApp
{
    partial class EditTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTaskForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtTitle = new TextBox();
            txtDescription = new TextBox();
            dtpDueDate = new DateTimePicker();
            cmbPriority = new ComboBox();
            cmbStatus = new ComboBox();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // txtTitle
            // 
            resources.ApplyResources(txtTitle, "txtTitle");
            txtTitle.BackColor = SystemColors.InactiveCaption;
            txtTitle.Cursor = Cursors.IBeam;
            txtTitle.ForeColor = SystemColors.ControlText;
            txtTitle.Name = "txtTitle";
            // 
            // txtDescription
            // 
            resources.ApplyResources(txtDescription, "txtDescription");
            txtDescription.BackColor = SystemColors.InactiveCaption;
            txtDescription.Cursor = Cursors.IBeam;
            txtDescription.ForeColor = SystemColors.Desktop;
            txtDescription.Name = "txtDescription";
            // 
            // dtpDueDate
            // 
            resources.ApplyResources(dtpDueDate, "dtpDueDate");
            dtpDueDate.CalendarMonthBackground = SystemColors.InactiveCaption;
            dtpDueDate.CalendarTitleBackColor = SystemColors.InactiveCaption;
            dtpDueDate.Cursor = Cursors.Hand;
            dtpDueDate.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            dtpDueDate.MinDate = new DateTime(2024, 12, 17, 0, 0, 0, 0);
            dtpDueDate.Name = "dtpDueDate";
            // 
            // cmbPriority
            // 
            resources.ApplyResources(cmbPriority, "cmbPriority");
            cmbPriority.BackColor = SystemColors.InactiveCaption;
            cmbPriority.Cursor = Cursors.IBeam;
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Items.AddRange(new object[] { resources.GetString("cmbPriority.Items"), resources.GetString("cmbPriority.Items1"), resources.GetString("cmbPriority.Items2") });
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Tag = "";
            // 
            // cmbStatus
            // 
            resources.ApplyResources(cmbStatus, "cmbStatus");
            cmbStatus.BackColor = SystemColors.InactiveCaption;
            cmbStatus.Cursor = Cursors.IBeam;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { resources.GetString("cmbStatus.Items"), resources.GetString("cmbStatus.Items1"), resources.GetString("cmbStatus.Items2") });
            cmbStatus.Name = "cmbStatus";
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.BackColor = Color.SeaGreen;
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // EditTaskForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.DarkSlateGray;
            resources.ApplyResources(this, "$this");
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(cmbStatus);
            Controls.Add(cmbPriority);
            Controls.Add(dtpDueDate);
            Controls.Add(txtDescription);
            Controls.Add(txtTitle);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditTaskForm";
            ShowInTaskbar = false;
            TransparencyKey = Color.Transparent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private DateTimePicker dtpDueDate;
        private ComboBox cmbPriority;
        private ComboBox cmbStatus;
        private Button btnCancel;
        private Button btnSave;
    }
}
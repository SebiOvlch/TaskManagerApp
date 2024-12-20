namespace TaskManagerApp
{
    partial class EditToDo
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
            txtEdit = new TextBox();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtEdit
            // 
            txtEdit.Anchor = AnchorStyles.None;
            txtEdit.Font = new Font("Times New Roman", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 238);
            txtEdit.Location = new Point(116, 100);
            txtEdit.Name = "txtEdit";
            txtEdit.Size = new Size(500, 34);
            txtEdit.TabIndex = 0;
            txtEdit.Text = "Edit Task";
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.None;
            btnCancel.BackColor = Color.SeaGreen;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Font = new Font("Times New Roman", 13.8F);
            btnCancel.Location = new Point(116, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(190, 50);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.None;
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Cursor = Cursors.Hand;
            btnSave.Font = new Font("Times New Roman", 13.8F);
            btnSave.Location = new Point(426, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(190, 50);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // EditToDo
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(732, 353);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(txtEdit);
            Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 238);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EditToDo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Task";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEdit;
        private Button btnCancel;
        private Button btnSave;
    }
}
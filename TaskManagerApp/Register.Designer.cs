namespace TaskManagerApp
{
    partial class Register
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            txtName = new TextBox();
            btnReg = new Button();
            btnToLogin = new Button();
            buttonTogglePassword = new Button();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label3.Location = new Point(440, 509);
            label3.Name = "label3";
            label3.Size = new Size(184, 46);
            label3.TabIndex = 3;
            label3.Text = "Password:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(440, 409);
            label2.Name = "label2";
            label2.Size = new Size(139, 46);
            label2.TabIndex = 3;
            label2.Text = "E-mail:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(440, 309);
            label1.Name = "label1";
            label1.Size = new Size(126, 46);
            label1.TabIndex = 3;
            label1.Text = "Name:";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BackColor = SystemColors.ControlDark;
            txtPassword.Location = new Point(440, 559);
            txtPassword.Margin = new Padding(6);
            txtPassword.MaxLength = 10;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(420, 42);
            txtPassword.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.None;
            txtEmail.BackColor = SystemColors.ControlDark;
            txtEmail.Location = new Point(440, 459);
            txtEmail.Margin = new Padding(6);
            txtEmail.MaxLength = 35;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(420, 42);
            txtEmail.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Anchor = AnchorStyles.None;
            txtName.BackColor = SystemColors.ControlDark;
            txtName.Location = new Point(440, 359);
            txtName.Margin = new Padding(6);
            txtName.MaxLength = 35;
            txtName.Name = "txtName";
            txtName.Size = new Size(420, 42);
            txtName.TabIndex = 0;
            // 
            // btnReg
            // 
            btnReg.Anchor = AnchorStyles.None;
            btnReg.AutoSize = true;
            btnReg.BackColor = SystemColors.ControlDark;
            btnReg.Font = new Font("Times New Roman", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnReg.Location = new Point(525, 619);
            btnReg.Name = "btnReg";
            btnReg.Size = new Size(250, 52);
            btnReg.TabIndex = 5;
            btnReg.Text = "Register";
            btnReg.UseVisualStyleBackColor = false;
            btnReg.Click += btnReg_Click;
            // 
            // btnToLogin
            // 
            btnToLogin.Anchor = AnchorStyles.None;
            btnToLogin.BackColor = SystemColors.ControlDark;
            btnToLogin.Location = new Point(550, 677);
            btnToLogin.Name = "btnToLogin";
            btnToLogin.Size = new Size(200, 40);
            btnToLogin.TabIndex = 6;
            btnToLogin.Text = "Back to Login";
            btnToLogin.UseVisualStyleBackColor = false;
            btnToLogin.Click += btnToLogin_Click;
            // 
            // buttonTogglePassword
            // 
            buttonTogglePassword.Anchor = AnchorStyles.None;
            buttonTogglePassword.BackColor = SystemColors.ControlDark;
            buttonTogglePassword.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            buttonTogglePassword.FlatAppearance.MouseOverBackColor = Color.Black;
            buttonTogglePassword.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonTogglePassword.Location = new Point(866, 563);
            buttonTogglePassword.Margin = new Padding(0);
            buttonTogglePassword.Name = "buttonTogglePassword";
            buttonTogglePassword.Size = new Size(35, 35);
            buttonTogglePassword.TabIndex = 7;
            buttonTogglePassword.Text = "👁";
            buttonTogglePassword.UseVisualStyleBackColor = false;
            buttonTogglePassword.Click += buttonTogglePassword_Click;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(17F, 34F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1282, 971);
            Controls.Add(buttonTogglePassword);
            Controls.Add(btnToLogin);
            Controls.Add(btnReg);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Margin = new Padding(6);
            MinimumSize = new Size(1000, 800);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private TextBox txtName;
        private Button btnReg;
        private Button btnToLogin;
        private Button buttonTogglePassword;
    }
}
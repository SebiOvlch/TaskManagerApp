namespace TaskManagerApp
{
    partial class LoginPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLogName = new TextBox();
            txtLogPass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            btnToReg = new Button();
            buttonTogglePassword = new Button();
            rememberMeCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // txtLogName
            // 
            txtLogName.Anchor = AnchorStyles.None;
            txtLogName.BackColor = SystemColors.ControlDark;
            txtLogName.Location = new Point(440, 250);
            txtLogName.MaxLength = 35;
            txtLogName.Name = "txtLogName";
            txtLogName.Size = new Size(420, 42);
            txtLogName.TabIndex = 0;
            // 
            // txtLogPass
            // 
            txtLogPass.Anchor = AnchorStyles.None;
            txtLogPass.BackColor = SystemColors.ControlDark;
            txtLogPass.Location = new Point(440, 350);
            txtLogPass.MaxLength = 10;
            txtLogPass.Name = "txtLogPass";
            txtLogPass.Size = new Size(420, 42);
            txtLogPass.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(440, 200);
            label1.Name = "label1";
            label1.Size = new Size(149, 46);
            label1.TabIndex = 1;
            label1.Text = "E-mail: ";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 24F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label2.Location = new Point(440, 300);
            label2.Name = "label2";
            label2.Size = new Size(194, 46);
            label2.TabIndex = 1;
            label2.Text = "Password: ";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.AutoSize = true;
            btnLogin.BackColor = SystemColors.ControlDark;
            btnLogin.Font = new Font("Times New Roman", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnLogin.Location = new Point(440, 430);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(202, 52);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnToReg
            // 
            btnToReg.Anchor = AnchorStyles.None;
            btnToReg.AutoSize = true;
            btnToReg.BackColor = SystemColors.ControlDark;
            btnToReg.Font = new Font("Times New Roman", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnToReg.Location = new Point(658, 430);
            btnToReg.Name = "btnToReg";
            btnToReg.Size = new Size(202, 52);
            btnToReg.TabIndex = 6;
            btnToReg.Text = "Register";
            btnToReg.UseVisualStyleBackColor = false;
            btnToReg.Click += btnToReg_Click;
            // 
            // buttonTogglePassword
            // 
            buttonTogglePassword.Anchor = AnchorStyles.None;
            buttonTogglePassword.BackColor = SystemColors.ControlDark;
            buttonTogglePassword.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 238);
            buttonTogglePassword.Location = new Point(870, 354);
            buttonTogglePassword.Margin = new Padding(0);
            buttonTogglePassword.Name = "buttonTogglePassword";
            buttonTogglePassword.Size = new Size(35, 35);
            buttonTogglePassword.TabIndex = 7;
            buttonTogglePassword.Text = "👁";
            buttonTogglePassword.UseVisualStyleBackColor = false;
            buttonTogglePassword.Click += buttonTogglePassword_Click;
            // 
            // rememberMeCheckBox
            // 
            rememberMeCheckBox.AutoSize = true;
            rememberMeCheckBox.Location = new Point(440, 508);
            rememberMeCheckBox.Name = "rememberMeCheckBox";
            rememberMeCheckBox.Size = new Size(211, 38);
            rememberMeCheckBox.TabIndex = 8;
            rememberMeCheckBox.Text = "Remember me";
            rememberMeCheckBox.UseVisualStyleBackColor = true;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(17F, 34F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateGray;
            ClientSize = new Size(1282, 753);
            Controls.Add(rememberMeCheckBox);
            Controls.Add(buttonTogglePassword);
            Controls.Add(btnToReg);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLogPass);
            Controls.Add(txtLogName);
            Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Margin = new Padding(6);
            MinimumSize = new Size(1000, 600);
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLogName;
        private TextBox txtLogPass;
        private Label label1;
        private Label label2;
        private Button btnLogin;
        private Button btnToReg;
        private Button buttonTogglePassword;
        private CheckBox rememberMeCheckBox;
    }
}

using System.Text;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static TaskManagerApp.MainPage;

namespace TaskManagerApp
{
    public partial class LoginPage : Form
    {
        

        public LoginPage()
        {
            InitializeComponent();

            // for Password toggle button
            txtLogPass.UseSystemPasswordChar = true;
            buttonTogglePassword.Text = "👁";
        }
        private void LoginPage_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe == true)
            {
                txtLogName.Text = Properties.Settings.Default.Email;
                txtLogPass.Text = Properties.Settings.Default.Password;
                rememberMeCheckBox.Checked = true;
            }
        }

        private MainPage mainPageInstance;
        // On Login button click:
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            // TODO:
            string email = txtLogName.Text;
            string password = txtLogPass.Text;

            //var user = _userService.GetUserById(userId);

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All field needs to be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Incorrect e-mail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPass = HashPassword(password);

            // Loading XML and validate user
            XDocument doc = XDocument.Load("users.xml");


            bool isValidUser = doc.Root.Elements("User")
                .Any(user => user.Element("Email")?.Value == email &&
                             user.Element("Password")?.Value == hashedPass);

            
            if (isValidUser)
            {
                var user = doc.Descendants("User")
                    .FirstOrDefault(u =>
                        (string)u.Element("Email") == email &&
                        (string)u.Element("Password") == hashedPass);

                Properties.Settings.Default.UserId = (string)user.Element("id");
                Properties.Settings.Default.Name = (string)user.Element("Name");
                Properties.Settings.Default.Email = email;

                if (rememberMeCheckBox.Checked) {
                    Properties.Settings.Default.RememberMe = true;
                    Properties.Settings.Default.Password = password;
                }
                else
                {
                    Properties.Settings.Default.RememberMe = false;
                    Properties.Settings.Default.Password = "";
                }
                MessageBox.Show("Login succeed! Welcome!", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Properties.Settings.Default.Save();
                if (mainPageInstance == null || mainPageInstance.IsDisposed)
                {
                    mainPageInstance = new MainPage();
                }

                this.Hide();
                MainPage mainPage = new MainPage();
                mainPage.Show();

            }
            else
            {
                MessageBox.Show("Wrong e-mail or password! Please try again!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private Register registerInstance; // Register form

        // On Register button click: 
        private void btnToReg_Click(object sender, EventArgs e)
        {
            if (registerInstance == null || registerInstance.IsDisposed)
            {
                registerInstance = new Register();
            }

            this.Hide();
            registerInstance.Show();

        }

        // Email form validation
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Hashing the password for safety
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void buttonTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtLogPass.UseSystemPasswordChar)
            {
                txtLogPass.UseSystemPasswordChar = false; // Látható jelszó
                buttonTogglePassword.Text = "🔒"; // Ikon megváltoztatása
            }
            else
            {
                txtLogPass.UseSystemPasswordChar = true; // Rejtett jelszó
                buttonTogglePassword.Text = "👁"; // Ikon megváltoztatása
            }
        }
    }
}

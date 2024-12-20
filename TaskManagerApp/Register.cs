using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace TaskManagerApp
{
    

    public partial class Register : Form
    {
        public class User
        {
            public string Name { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string userId { get; set; }
        }

        private LoginPage loginInstance;

        public Register()
        {
            InitializeComponent();


            // for Password toggle button
            txtPassword.UseSystemPasswordChar = true;
            buttonTogglePassword.Text = "👁";
        }
        private void Register_Load(object sender, EventArgs e)
        {
            txtName.Focus();
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



        // Register when button is pressed
        private void btnReg_Click(object sender, EventArgs e)
        {
            string userId = Guid.NewGuid().ToString();
            string name = txtName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;


            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All field needs to be filled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Incorrect e-mail!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            string filePath = "users.xml";

            XDocument doc;


            if (File.Exists(filePath))
            {
                doc = XDocument.Load(filePath);
            }
            else
            {
                doc = new XDocument(new XElement("Users"));
            }

            if (doc.Root.Elements("User").Any(u => u.Element("Email")?.Value == email))
            {
                MessageBox.Show("This e-mail is already registered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = HashPassword(password);

            XElement newUser = new XElement("User",
                new XElement("id", userId),
                new XElement("Name", name),
                new XElement("Email", email),
                new XElement("Password", hashedPassword)
            );

            doc.Root.Add(newUser);
            doc.Save(filePath);

            MessageBox.Show($"You are now registered! Welcome {name}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";

            if (loginInstance == null || loginInstance.IsDisposed)
            {
                loginInstance = new LoginPage();
            }

            this.Hide();
            loginInstance.ShowDialog();

        }

        private void btnToLogin_Click(object sender, EventArgs e)
        {
            if (loginInstance == null || loginInstance.IsDisposed)
            {
                loginInstance = new LoginPage();
            }

            this.Hide();
            loginInstance.ShowDialog();
        }

        private void buttonTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false; // Látható jelszó
                buttonTogglePassword.Text = "🔒"; // Ikon megváltoztatása
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true; // Rejtett jelszó
                buttonTogglePassword.Text = "👁"; // Ikon megváltoztatása
            }
        }
    }
}

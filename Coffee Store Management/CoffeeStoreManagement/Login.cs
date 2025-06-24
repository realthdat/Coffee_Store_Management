using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using GUI;


namespace MIDTERM_521H0348_NguyenThanhDat
{
    public partial class Login : Form
    {

        private BUS_Account busAccount = new BUS_Account();

        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            try
            {
                string passwordHash = HashPassword(password); // Hash the password

                // Now call the BUS layer to validate login
                DTO_Account account = busAccount.Login(username, passwordHash);

                MessageBox.Show($"Login successful! Welcome {account.Username}, Role: {account.Role}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Proceed with login actions
                MainForm mainForm = new MainForm(username);
                this.Hide();  // Hide the login form
                mainForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                // Show the password by setting PasswordChar to '\0', which means no masking character
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                // Hide the password by setting PasswordChar to '*' or any other character
                txtPassword.PasswordChar = '*';
            }
        }

        private string HashPassword(string password)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // ComputeHash returns byte array
                byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void ptbExit_Click(object sender, EventArgs e)
        {
            // Confirm before closing the application
            DialogResult result = MessageBox.Show("Are you sure you want to close the application?",
                                                  "Close Application",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Đóng toàn bộ ứng dụng
            }
        }
    }
}

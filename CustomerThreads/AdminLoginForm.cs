using System;
using System.Windows.Forms;

namespace CustomerThreads
{
    public partial class AdminLoginForm : Form
    {
        public bool IsAuthenticated { get; private set; }

        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (SecurityHelper.Hash(txtPassword.Text) == AdminSettings.PasswordHash)
            {
                IsAuthenticated = true;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Wrong password.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Password change is available from the Admin menu.");
        }

        private void AdminLoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
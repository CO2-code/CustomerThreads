using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CustomerThreads
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SecurityHelper.Hash(txtOld.Text) != AdminSettings.PasswordHash)
            {
                MessageBox.Show("Old password is incorrect.");
                return;
            }

            if (txtNew.Text.Length < 4)
            {
                MessageBox.Show("Password too short.");
                return;
            }

            if (txtNew.Text != txtConfirm.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            AdminSettings.PasswordHash = SecurityHelper.Hash(txtNew.Text);
            AdminSettings.Save();

            MessageBox.Show("Password changed successfully.");
            Close();
        }


        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            // No initialization needed yet
        }

        private void lblConfirm_Click(object sender, EventArgs e)
        {

        }

        private void lblOld_Click(object sender, EventArgs e)
        {

        }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomerThreads
{
    public partial class MainForm : Form
    {
        List<CustomerThread> threads = new List<CustomerThread>();
        string dataFile = "data.json";

        bool viewingArchived = false;
        bool isAdmin = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AdminSettings.Load();
            LoadData();

            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;

            RefreshThreadList();
            UpdateAdminUI();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void listThreads_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearAttachmentsUI();

            if (listThreads.SelectedItem is CustomerThread thread)
            {
               // lblThreadTitle.Text = thread.Title;
                lblCustomerName.Text = "Name: " + thread.CustomerName;
                lblCustomerPhone.Text = "Phone: " + thread.Phone;
                lblCustomerCategory.Text = "Category: " + thread.Category;

                // ✅ DEVICE LIST (FIX)
                listDevicesMain.Items.Clear();
                foreach (var device in thread.Devices)
                    listDevicesMain.Items.Add(device);

                listNotes.Items.Clear();
                foreach (var note in thread.Notes)
                    listNotes.Items.Add(note);

                listAttachmentsView.Items.Clear();
                foreach (var att in thread.Attachments)
                    listAttachmentsView.Items.Add(att);
            }
        }

        private void listAttachmentsView_DoubleClick(object sender, EventArgs e)
        {
            if (listAttachmentsView.SelectedItem is ThreadAttachment att)
            {
                if (File.Exists(att.FilePath))
                {
                    System.Diagnostics.Process.Start(att.FilePath);
                }
                else
                {
                    MessageBox.Show("File not found on disk.");
                }
            }
        }

        private void btnNewThread_Click(object sender, EventArgs e)
        {
            using (var form = new NewThreadForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var t = form.CreatedThread;
                    t.Title = t.CustomerName;

                    threads.Add(t);
                    SaveData();
                    RefreshThreadList();
                }
            }
        }

        private void btnEditThread_Click(object sender, EventArgs e)
        {
            if (!(listThreads.SelectedItem is CustomerThread thread))
            {
                MessageBox.Show("Select a thread first.");
                return;
            }

            using (var form = new NewThreadForm(thread))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    thread.Title = thread.CustomerName;

                    SaveData();
                    RefreshThreadList();
                    listThreads.SelectedItem = thread;
                }
            }
        }

        void RefreshThreadList()
        {
            listThreads.Items.Clear();

            string search = txtSearch.Text;
            if (search == "Search...")
                search = "";

            search = search.ToLower();
            string selectedCategory = listCategories.SelectedItem?.ToString();

            if (selectedCategory == "All")
                selectedCategory = null;

            var filtered = threads.Where(t =>
                (viewingArchived ? t.IsArchived : !t.IsArchived) &&
                (string.IsNullOrEmpty(search) ||
                 t.Title.ToLower().Contains(search) ||
                 t.Phone.Contains(search)) &&
                (selectedCategory == null || t.Category == selectedCategory)
            ).ToArray();

            listThreads.Items.AddRange(filtered);
        }

        void SaveData()
        {
            var json = JsonConvert.SerializeObject(threads, Formatting.Indented);
            File.WriteAllText(dataFile, json);
        }

        void LoadData()
        {
            if (!File.Exists(dataFile))
                return;

            var json = File.ReadAllText(dataFile);
            threads = JsonConvert.DeserializeObject<List<CustomerThread>>(json)
                      ?? new List<CustomerThread>();
        }

        void ClearDetails()
        {
          //  lblThreadTitle.Text = "";
            lblCustomerName.Text = "";
            lblCustomerPhone.Text = "";
            lblCustomerDevice.Text = "";
            lblCustomerCategory.Text = "";
            listNotes.Items.Clear();
            ClearAttachmentsUI();
            listDevicesMain.Items.Clear();
        }

        void RefreshApplication()
        {
            LoadData();
            RefreshThreadList();
            ClearDetails();
            ClearAttachmentsUI();
        }

        void ClearAttachmentsUI()
        {
            listAttachmentsView.Items.Clear();   // or ListView.Items.Clear()
            picPreview.Image = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedThreads();
            if (selected.Count == 0)
            {
                MessageBox.Show("Select a job first.");
                return;
            }

            var choice = MessageBox.Show(
                "YES = Archive (Recommended)\nNO = Delete permanently (Admin password required)",
                "Delete Job",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            if (choice == DialogResult.Cancel)
                return;

            if (choice == DialogResult.Yes)
            {
                foreach (var t in selected)
                    t.IsArchived = true;

                SaveData();
                RefreshThreadList();
                ClearDetails();
                ClearAttachmentsUI();
            }
            else if (choice == DialogResult.No)
            {
                foreach (var t in selected)
                    AskPermanentDeletePassword(t);
            }
        }

        void AskPermanentDeletePassword(CustomerThread thread)
        {
            using (var form = new AdminLoginForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                threads.Remove(thread);
                SaveData();
                RefreshThreadList();
                ClearDetails();
              
                MessageBox.Show("Job permanently deleted.");
            }
        }

        private void btnArchived_Click(object sender, EventArgs e)
        {
            viewingArchived = !viewingArchived;
            btnArchived.Text = viewingArchived ? "Archived Jobs" : "Active Jobs";
            RefreshThreadList();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (!viewingArchived)
            {
                MessageBox.Show("Switch to Archived Jobs first.");
                return;
            }

            var selected = GetSelectedThreads();
            if (selected.Count == 0) return;

            foreach (var t in selected)
                t.IsArchived = false;

            SaveData();
            RefreshThreadList();
            ClearDetails();
        }

        // ----------------- CONTEXT MENU HANDLERS -----------------
        private void ctxEdit_Click(object sender, EventArgs e) => EditSelectedThread();

        private void ctxArchive_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedThreads();
            if (selected.Count == 0) return;

            foreach (var thread in selected)
                thread.IsArchived = true;

            SaveData();
            RefreshThreadList();
            ClearDetails();
            ClearAttachmentsUI();
        }

        private void ctxDelete_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("Admin login required.");
                return;
            }

            var selected = GetSelectedThreads();
            if (selected.Count == 0) return;

            var confirm = MessageBox.Show(
                $"Permanently delete {selected.Count} job(s)?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            foreach (var thread in selected)
                threads.Remove(thread);

            SaveData();
            RefreshThreadList();
            ClearDetails();
            ClearAttachmentsUI();
        }

        private void ctxRestore_Click(object sender, EventArgs e)
        {
            var selected = GetSelectedThreads();
            if (selected.Count == 0) return;

            foreach (var thread in selected)
                thread.IsArchived = false;

            SaveData();
            RefreshThreadList();
            ClearDetails();
            ClearAttachmentsUI();
        }

        private void ctxExport_Click(object sender, EventArgs e)
        {
            if (!(listThreads.SelectedItem is CustomerThread thread))
            {
                MessageBox.Show("Select a job first.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel CSV (*.csv)|*.csv";
                sfd.FileName = thread.Title.Replace(" ", "_") + ".csv";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                ExportSelectedThreadToCsv(thread, sfd.FileName);
                MessageBox.Show("Job exported successfully.");
            }
        }

        private void ctxThreadMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var selected = GetSelectedThreads();

            if (selected.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            bool anyArchived = selected.Any(t => t.IsArchived);
            bool anyActive = selected.Any(t => !t.IsArchived);

            ctxEdit.Enabled = selected.Count == 1 && anyActive;
            ctxArchive.Enabled = anyActive;
            ctxRestore.Enabled = anyArchived;
            ctxDelete.Enabled = isAdmin;
            ctxExport.Enabled = selected.Count == 1;

            foreach (var t in selected)
            {
                if (t.Category == "Finished" && !t.FinishedAt.HasValue)
                    t.FinishedAt = DateTime.Now;
            }
        }

        // ----------------- ADMIN MENU -----------------
        private void menuAdminLogin_Click(object sender, EventArgs e)
        {
            using (var form = new AdminLoginForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    isAdmin = true;
                    UpdateAdminUI();
                    MessageBox.Show("Admin mode enabled.");
                }
            }
        }

        private void menuAdminLogout_Click(object sender, EventArgs e)
        {
            isAdmin = false;
            UpdateAdminUI();
            MessageBox.Show("Admin logged out.");
        }

        private void menuAdminChangePassword_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                MessageBox.Show("Admin login required.");
                return;
            }

            using (var form = new ChangePasswordForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // nothing extra needed here
                }
            }
        }

        // ----------------- SEARCH BOX -----------------
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.ForeColor == Color.Gray) return;
            RefreshThreadList();
        }

        // ----------------- LIST CATEGORIES -----------------
        private void listCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshThreadList();
        }

        // ----------------- MOUSE -----------------
        private void listThreads_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listThreads.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                    listThreads.SelectedIndex = index;
                else
                    listThreads.ClearSelected();
            }
        }

        private void panelDetails_Paint(object sender, PaintEventArgs e)
        {
            // Optional: custom painting if needed
        }

        // ----------------- ADMIN UI -----------------
        void UpdateAdminUI()
        {
            ctxDelete.Enabled = isAdmin;
            ctxRestore.Enabled = isAdmin;

            menuAdminChangePassword.Enabled = isAdmin;
            menuAdminLogout.Enabled = isAdmin;
            menuAdminLogin.Enabled = !isAdmin;
        }

        // ----------------- EXPORT -----------------
        void ExportSelectedThreadToCsv(CustomerThread t, string filePath)
        {
            var lines = new List<string>();

            lines.Add("Title,Customer,Phone,Device(s),Category,CreatedAt,FinishedAt,Price,Archived,Notes,Attachments");

            string notes = string.Join(" | ",
                t.Notes.Select(n =>
                    $"{n.CreatedAt:yyyy-MM-dd HH:mm}: {n.Text.Replace(",", " ")}"));

            string attachments = string.Join(" | ", t.Attachments.Select(a => a.FileName));

            string line = string.Join(",",
                Escape(t.Title),
                Escape(t.CustomerName),
                Escape(t.Phone),
                Escape(string.Join(", ", t.Devices)),
                Escape(t.Category),
                t.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                t.FinishedAt.HasValue ? t.FinishedAt.Value.ToString("yyyy-MM-dd HH:mm") : "-",
                t.Price.ToString("0.00"),
                t.IsArchived ? "Yes" : "No",
                Escape(notes),
                Escape(attachments)
            );

            lines.Add(line);
            File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }

        string Escape(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            value = value.Replace("\"", "\"\"");
            return $"\"{value}\"";
        }

        // ----------------- EDIT HELPER -----------------
        private void EditSelectedThread()
        {
            if (!(listThreads.SelectedItem is CustomerThread thread))
            {
                MessageBox.Show("Select a job first");
                return;
            }

            using (var form = new NewThreadForm(thread))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    thread.Title = thread.CustomerName;

                    SaveData();
                    RefreshThreadList();
                    listThreads.SelectedItem = thread;
                }
            }
        }

        List<CustomerThread> GetSelectedThreads()
        {
            return listThreads.SelectedItems
                .Cast<CustomerThread>()
                .ToList();
        }

        private void listAttachmentsView_SelectedIndexChanged(object sender, EventArgs e)
        {
            picPreview.Image = null;
            picPreview.Visible = false;

            if (listAttachmentsView.SelectedItem is ThreadAttachment att)
            {
                string ext = Path.GetExtension(att.FilePath).ToLower();

                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp")
                {
                    if (File.Exists(att.FilePath))
                    {
                        using (var fs = new FileStream(att.FilePath, FileMode.Open, FileAccess.Read))
                        {
                            picPreview.Image = Image.FromStream(fs);
                        }

                        picPreview.Visible = true;
                    }
                }
            }
        }

        private void menuAdminRefresh_Click(object sender, EventArgs e)
        {
            RefreshApplication();
        }
    }
}
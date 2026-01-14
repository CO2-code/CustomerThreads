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
            ShowLogo();

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

            // Clear device notes when thread changes
            listDeviceNote.Items.Clear();

            if (listThreads.SelectedItem is CustomerThread thread)
            {
                ShowDetails();

                lblCustomerName.Text = "Name: " + thread.CustomerName;
                lblCustomerPhone.Text = "Phone: " + thread.Phone;
                lblCustomerCategory.Text = "Category: " + thread.Category;

                // ✅ DEVICE LIST
                listDevicesMain.Items.Clear();
                foreach (var device in thread.Devices)
                    listDevicesMain.Items.Add(device);

                // ✅ ATTACHMENTS
                listAttachmentsView.Items.Clear();
                foreach (var att in thread.Attachments)
                    listAttachmentsView.Items.Add(att);
            }
        }

        private void listDevicesMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear notes first
            listDeviceNote.Items.Clear();

            // Only populate if a device is selected
            if (listDevicesMain.SelectedItem is DeviceItem device)
            {
                // ✅ Show each device note with timestamp
                foreach (var note in device.Notes)
                {
                    string timestamp = note.CreatedAt.ToString("HH:mm dd-MM-yyyy");
                    listDeviceNote.Items.Add($"• ({timestamp}) {note.Text}");
                }

                // ✅ Separator if there are notes
                if (device.Notes.Count > 0)
                    listDeviceNote.Items.Add("----------------------------");

                // ✅ Show optional metadata
                if (!string.IsNullOrWhiteSpace(device.DeviceType))
                    listDeviceNote.Items.Add("Type: " + device.DeviceType);

                if (!string.IsNullOrWhiteSpace(device.ModelNumber))
                    listDeviceNote.Items.Add("Model: " + device.ModelNumber);

                if (!string.IsNullOrWhiteSpace(device.SerialNumber))
                    listDeviceNote.Items.Add("Serial: " + device.SerialNumber);

                // ✅ Show device creation timestamp
                listDeviceNote.Items.Add("Added: " + device.CreatedAt.ToString("HH:mm dd-MM-yyyy"));
            }
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

            // 🔥 Auto backup (fire and forget)
            _ = GoogleDriveBackup.BackupFileAsync(dataFile);
        }

        void LoadData()
        {
            // Try downloading latest backup first
            GoogleDriveBackup.DownloadFile(dataFile);

            if (!File.Exists(dataFile))
                return;

            var json = File.ReadAllText(dataFile);
            threads = JsonConvert.DeserializeObject<List<CustomerThread>>(json)
                      ?? new List<CustomerThread>();
        }

        void ClearDetails()
        {
            lblCustomerName.Text = "";
            lblCustomerPhone.Text = "";
            lblCustomerCategory.Text = "";
            ClearAttachmentsUI();
            listDevicesMain.Items.Clear();
            listDeviceNote.Items.Clear();
        }

        void ClearAttachmentsUI()
        {
            listAttachmentsView.Items.Clear();
            picPreview.Image = null;
        }

        // ----------------- DELETIONS / ARCHIVE -----------------
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

        // ----------------- CONTEXT MENU -----------------
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

        // ----------------- HELPER METHODS -----------------
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

        void UpdateAdminUI()
        {
            ctxDelete.Enabled = isAdmin;
            ctxRestore.Enabled = isAdmin;

            menuAdminChangePassword.Enabled = isAdmin;
            menuAdminLogout.Enabled = isAdmin;
            menuAdminLogin.Enabled = !isAdmin;
        }

        void ExportSelectedThreadToCsv(CustomerThread t, string filePath)
        {
            var lines = new List<string>();
            lines.Add("Title,Customer,Phone,Device(s),Category,CreatedAt,FinishedAt,Price,Archived,Attachments");

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

        private void ShowLogo()
        {
            picPanelLogo.Visible = true;

            foreach (Control c in panelDetails.Controls)
            {
                if (c != picPanelLogo)
                    c.Visible = false;
            }
        }

        private void ShowDetails()
        {
            picPanelLogo.Visible = false;

            foreach (Control c in panelDetails.Controls)
            {
                if (c != picPanelLogo)
                    c.Visible = true;
            }
        }
    }
}
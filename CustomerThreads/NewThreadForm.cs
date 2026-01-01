using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CustomerThreads
{
    public partial class NewThreadForm : Form
    {
        public CustomerThread CreatedThread { get; private set; }

        private bool isEditMode = false;
        private CustomerThread editingThread;

        public NewThreadForm()
        {
            InitializeComponent();
        }

        public NewThreadForm(CustomerThread threadToEdit)
        {
            InitializeComponent();

            isEditMode = true;
            editingThread = threadToEdit;

            txtName.Text = threadToEdit.CustomerName;
            txtPhone.Text = threadToEdit.Phone;
            txtDevice.Text = string.Join(", ", threadToEdit.Devices);
            cmbCategory.Text = threadToEdit.Category;

            Text = "Edit Thread";
            btnCreate.Text = "Save Changes";

            numPrice.Value = threadToEdit.Price;

            if (threadToEdit.FinishedAt.HasValue)
            {
                dtFinishedAt.Value = threadToEdit.FinishedAt.Value;
                dtFinishedAt.Checked = true;
            }
            else
            {
                dtFinishedAt.Checked = false;
            }

            if (threadToEdit.CustomerType == CustomerType.Company)
            {
                rbCompany.Checked = true;
                txtCompanyName.Text = threadToEdit.CompanyName;
            }
            else
            {
                rbIndividual.Checked = true;
            }

            // Load attachments
            listAttachments.Items.Clear();
            foreach (var att in threadToEdit.Attachments)
                listAttachments.Items.Add(att.FileName);
        }

        private void NewThreadForm_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new[]
            {
                "New",
                "In Repair",
                "Waiting for Parts",
                "Finished"
            });

            if (!isEditMode)
                cmbCategory.SelectedIndex = 0;

            txtCompanyName.Enabled = rbCompany.Checked;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Customer name is required");
                return;
            }

            CustomerType type = rbCompany.Checked ? CustomerType.Company : CustomerType.Individual;
            string companyName = rbCompany.Checked ? txtCompanyName.Text : null;

            var devices = txtDevice.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(d => d.Trim())
                                        .ToList();

            if (tempDevices.Count == 0)
            {
                MessageBox.Show("Add at least one device.");
                return;
            }

            if (isEditMode)
            {
                editingThread.CustomerName = txtName.Text;
                editingThread.Phone = txtPhone.Text;
                editingThread.Devices = tempDevices;
                editingThread.Category = cmbCategory.Text;
                editingThread.Title = $"{txtName.Text} - {string.Join(", ", devices)}";
                editingThread.Price = numPrice.Value;
                editingThread.FinishedAt = dtFinishedAt.Checked ? dtFinishedAt.Value : (DateTime?)null;

                editingThread.CustomerType = type;
                editingThread.CompanyName = companyName;

                if (editingThread.Category == "Finished" && !editingThread.FinishedAt.HasValue)
                    editingThread.FinishedAt = DateTime.Now;

                if (!string.IsNullOrWhiteSpace(txtNote.Text))
                {
                    var note = new ThreadNote();
                    note.Text = txtNote.Text;
                    note.CreatedAt = DateTime.Now;
                    editingThread.Notes.Add(note);
                }

                // Save attachments
                editingThread.Attachments.Clear();
                foreach (var item in listAttachments.Items)
                {
                    var filePath = item as string;
                    if (File.Exists(filePath))
                        editingThread.Attachments.Add(new ThreadAttachment
                        {
                            FileName = Path.GetFileName(filePath),
                            FilePath = filePath
                        });
                }
            }
            else
            {
                CreatedThread = new CustomerThread
                {
                    CustomerName = txtName.Text,
                    Phone = txtPhone.Text,
                    Devices = tempDevices,
                    Category = cmbCategory.Text,
                    Title = $"{txtName.Text} - {string.Join(", ", devices)}",
                    CreatedAt = DateTime.Now,
                    Price = numPrice.Value,
                    FinishedAt = dtFinishedAt.Checked ? dtFinishedAt.Value : (DateTime?)null,
                    CustomerType = type,
                    CompanyName = companyName,
                    Attachments = new List<ThreadAttachment>()
                };

                if (!string.IsNullOrWhiteSpace(txtNote.Text))
                {
                    var note = new ThreadNote();
                    note.Text = txtNote.Text;
                    note.CreatedAt = DateTime.Now;
                    CreatedThread.Notes.Add(note);
                }

                // Save attachments
                foreach (var item in listAttachments.Items)
                {
                    var filePath = item as string;
                    if (File.Exists(filePath))
                        CreatedThread.Attachments.Add(new ThreadAttachment
                        {
                            FileName = Path.GetFileName(filePath),
                            FilePath = filePath
                        });
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void rbCompany_CheckedChanged(object sender, EventArgs e)
        {
            txtCompanyName.Enabled = rbCompany.Checked;
        }

        // ------------------- Attachments Buttons -------------------
        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images & PDFs|*.jpg;*.jpeg;*.png;*.bmp;*.pdf|All Files|*.*";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() != DialogResult.OK) return;

                foreach (var file in ofd.FileNames)
                {
                    listAttachments.Items.Add(file);
                }
            }
        }

        private void btnRemoveAttachment_Click(object sender, EventArgs e)
        {
            var selectedIndices = listAttachments.SelectedIndices.Cast<int>().OrderByDescending(i => i).ToList();
            foreach (var i in selectedIndices)
                listAttachments.Items.RemoveAt(i);
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDevice.Text))
            {
                MessageBox.Show("Device name is required.");
                return;
            }

            var device = new DeviceItem
            {
                Name = txtDevice.Text.Trim(),
                Price = numPrice.Value,
                FinishedAt = dtFinishedAt.Checked
                    ? dtFinishedAt.Value
                    : (DateTime?)null
            };

            tempDevices.Add(device);
            listDevices.Items.Add(device);

            // Reset inputs for next device
            txtDevice.Clear();
            numPrice.Value = 0;
            dtFinishedAt.Checked = false;
        }

        private List<DeviceItem> tempDevices = new List<DeviceItem>();

        private void btnRemoveDevice_Click(object sender, EventArgs e)
        {
            if (listDevices.SelectedItem is DeviceItem device)
            {
                tempDevices.Remove(device);
                listDevices.Items.Remove(device);
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            txtPhone.SelectionStart = 0;
            txtPhone.SelectionLength = 0;
        }
    }
}
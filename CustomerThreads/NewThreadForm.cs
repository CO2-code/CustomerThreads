using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace CustomerThreads
{
    public partial class NewThreadForm : Form
    {
        public CustomerThread CreatedThread { get; private set; }

        private bool isEditMode = false;
        private CustomerThread editingThread;

        private List<DeviceItem> tempDevices = new List<DeviceItem>();

        // Automatic mode
        private bool isAutomatic = false;
        private bool autoParsed = false;
        private CheckBox chkAutomatic;
        private TextBox txtAutomaticInput;
        private Button btnParseAutomatic;
        private Label lblAutomaticHint;
        private DateTime? parsedCreatedAt = null;
        private DateTime? parsedFinishedAt = null;

        // Device edit tracking
        private DeviceItem editingDevice = null;

        public NewThreadForm()
        {
            InitializeComponent();
            SetupAutomaticControls();
        }

        public NewThreadForm(CustomerThread threadToEdit)
        {
            InitializeComponent();
            SetupAutomaticControls();

            isEditMode = true;
            editingThread = threadToEdit;

            txtName.Text = threadToEdit.CustomerName;
            txtPhone.Text = threadToEdit.Phone;
            cmbCategory.Text = threadToEdit.Category;
            numPrice.Value = threadToEdit.Price;

            Text = "Edit Thread";
            btnCreate.Text = "Save Changes";

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
                rbCompany.Checked = true;
            else
                rbIndividual.Checked = true;

            tempDevices = new List<DeviceItem>();
            listDevices.Items.Clear();

            foreach (var device in threadToEdit.Devices)
            {
                tempDevices.Add(device);
                listDevices.Items.Add(device);
            }

            ClearDeviceInputs();

            listAttachments.Items.Clear();
            foreach (var att in threadToEdit.Attachments)
                listAttachments.Items.Add(att.FilePath);
        }

        private void SetupAutomaticControls()
        {
            // Checkbox to enable automatic mode
            chkAutomatic = new CheckBox();
            chkAutomatic.Text = "Automatic";
            chkAutomatic.AutoSize = true;
            chkAutomatic.Checked = false;
            chkAutomatic.CheckedChanged += chkAutomatic_CheckedChanged;

            // Place the checkbox near the customer name textbox if available
            try
            {
                chkAutomatic.Location = new System.Drawing.Point(txtName.Right + 10, txtName.Top);
            }
            catch
            {
                chkAutomatic.Location = new System.Drawing.Point(10, 10);
            }

            // Multiline textbox for automatic raw input
            txtAutomaticInput = new TextBox();
            txtAutomaticInput.Multiline = true;
            txtAutomaticInput.ScrollBars = ScrollBars.Vertical;
            txtAutomaticInput.Visible = false;
            txtAutomaticInput.Width = 300;
            txtAutomaticInput.Height = 120;

            // Place below the name field if possible
            try
            {
                txtAutomaticInput.Location = new System.Drawing.Point(txtName.Left, txtName.Bottom + 6);
            }
            catch
            {
                txtAutomaticInput.Location = new System.Drawing.Point(10, 40);
            }

            // Parse button
            btnParseAutomatic = new Button();
            btnParseAutomatic.Text = "Parse Automatic";
            btnParseAutomatic.AutoSize = true;
            btnParseAutomatic.Visible = false;
            btnParseAutomatic.Click += btnParseAutomatic_Click;

            try
            {
                btnParseAutomatic.Location = new System.Drawing.Point(txtAutomaticInput.Right + 8, txtAutomaticInput.Top);
            }
            catch
            {
                btnParseAutomatic.Location = new System.Drawing.Point(txtAutomaticInput.Right + 8, txtAutomaticInput.Top);
            }

            // Hint label
            lblAutomaticHint = new Label();
            lblAutomaticHint.Text = "Format: line1 = name, line2 = phone, optional 'Created: yyyy-MM-dd' and 'Finished: yyyy-MM-dd' lines, then devices.\nDevice format per line: name|type|model|serial|price (separators: | , ; tab).";
            lblAutomaticHint.AutoSize = true;
            lblAutomaticHint.Visible = false;
            try
            {
                lblAutomaticHint.Location = new System.Drawing.Point(txtAutomaticInput.Left, txtAutomaticInput.Bottom + 4);
            }
            catch
            {
                lblAutomaticHint.Location = new System.Drawing.Point(txtAutomaticInput.Left, txtAutomaticInput.Bottom + 4);
            }

            // Add controls to the form
            this.Controls.Add(chkAutomatic);
            this.Controls.Add(txtAutomaticInput);
            this.Controls.Add(btnParseAutomatic);
            this.Controls.Add(lblAutomaticHint);
        }

        private void chkAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            isAutomatic = chkAutomatic.Checked;
            txtAutomaticInput.Visible = isAutomatic;
            btnParseAutomatic.Visible = isAutomatic;
            lblAutomaticHint.Visible = isAutomatic;

            // When switching to automatic mode, clear manual inputs or disable them
            SetManualControlsEnabled(!isAutomatic);

            if (!isAutomatic)
            {
                autoParsed = false;
            }
        }

        private void btnParseAutomatic_Click(object sender, EventArgs e)
        {
            if (ParseAutomaticText())
            {
                MessageBox.Show("Automatic input parsed successfully.");
            }
        }

        private bool ParseAutomaticText()
        {
            var raw = txtAutomaticInput.Text ?? string.Empty;
            var lines = raw.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(l => l.Trim())
                           .Where(l => !string.IsNullOrWhiteSpace(l))
                           .ToList();

            if (lines.Count == 0)
            {
                MessageBox.Show("Automatic input is empty.");
                return false;
            }

            // Expect at least name and phone (optional devices after)
            if (lines.Count < 2)
            {
                MessageBox.Show("Automatic input must contain at least a name and a phone number on separate lines.");
                return false;
            }

            txtName.Text = lines[0];
            txtPhone.Text = lines[1];

            // Devices start from line 3 (index 2)
            tempDevices.Clear();
            listDevices.Items.Clear();

            // Reset parsed dates
            parsedCreatedAt = null;
            parsedFinishedAt = null;

            for (int i = 2; i < lines.Count; i++)
            {
                var deviceLine = lines[i];
                if (string.IsNullOrWhiteSpace(deviceLine))
                    continue;

                // Check for Created/Finished directives
                var lower = deviceLine.ToLowerInvariant();
                if (lower.StartsWith("created:") || lower.StartsWith("createdat:"))
                {
                    var datePart = deviceLine.Substring(deviceLine.IndexOf(':') + 1).Trim();
                    if (DateTime.TryParse(datePart, out DateTime cd))
                        parsedCreatedAt = cd;
                    continue;
                }

                if (lower.StartsWith("finished:") || lower.StartsWith("finishedat:"))
                {
                    var datePart = deviceLine.Substring(deviceLine.IndexOf(':') + 1).Trim();
                    if (DateTime.TryParse(datePart, out DateTime fd))
                    {
                        parsedFinishedAt = fd;
                        // reflect on the UI finished date control
                        try
                        {
                            dtFinishedAt.Value = fd;
                            dtFinishedAt.Checked = true;
                        }
                        catch
                        {
                        }
                    }
                    continue;
                }

                // Support several separators: | , ; \t
                string[] parts = deviceLine.Split(new[] { '|', ',', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(p => p.Trim())
                                           .ToArray();

                var device = new DeviceItem
                {
                    Name = parts.Length > 0 ? parts[0] : string.Empty,
                    DeviceType = parts.Length > 1 ? parts[1] : string.Empty,
                    ModelNumber = parts.Length > 2 ? parts[2] : string.Empty,
                    SerialNumber = parts.Length > 3 ? parts[3] : string.Empty,
                    Price = 0,
                    DateReceived = null,
                    FinishedAt = null,
                    State = "In Progress",
                };

                // If there's a 5th part try parsing price
                if (parts.Length > 4)
                {
                    var priceText = parts[4];
                    // Remove currency symbols and whitespace
                    priceText = new string(priceText.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
                    decimal parsedPrice;
                    if (decimal.TryParse(priceText, NumberStyles.Number, CultureInfo.InvariantCulture, out parsedPrice)
                        || decimal.TryParse(priceText, NumberStyles.Number, CultureInfo.CurrentCulture, out parsedPrice))
                    {
                        device.Price = parsedPrice;
                    }
                }

                tempDevices.Add(device);
                listDevices.Items.Add(device);
            }

            // Mark parsed so create flow can proceed
            autoParsed = true;
            return true;
        }

        private void SetManualControlsEnabled(bool enabled)
        {
            try
            {
                // Hide manual controls when automatic mode is active
                txtName.Enabled = enabled;
                txtName.Visible = enabled;

                txtPhone.Enabled = enabled;
                txtPhone.Visible = enabled;

                cmbCategory.Enabled = enabled;
                cmbCategory.Visible = enabled;

                numPrice.Enabled = enabled;
                numPrice.Visible = enabled;

                rbCompany.Enabled = enabled;
                rbCompany.Visible = enabled;

                rbIndividual.Enabled = enabled;
                rbIndividual.Visible = enabled;

                // Finished date control
                dtFinishedAt.Enabled = enabled;
                dtFinishedAt.Visible = enabled;

                // Device inputs
                txtDevice.Enabled = enabled;
                txtDevice.Visible = enabled;

                txtDeviceType.Enabled = enabled;
                txtDeviceType.Visible = enabled;

                txtModelNumber.Enabled = enabled;
                txtModelNumber.Visible = enabled;

                txtSerialNumber.Enabled = enabled;
                txtSerialNumber.Visible = enabled;

                txtDeviceNote.Enabled = enabled;
                txtDeviceNote.Visible = enabled;

                txtDate.Enabled = enabled;
                txtDate.Visible = enabled;

                btnAddDevice.Enabled = enabled;
                btnAddDevice.Visible = enabled;

                btnRemoveDevice.Enabled = enabled;
                btnRemoveDevice.Visible = enabled;

                // Attachments
                btnAddAttachment.Enabled = enabled;
                btnAddAttachment.Visible = enabled;

                btnRemoveAttachment.Enabled = enabled;
                btnRemoveAttachment.Visible = enabled;

                listAttachments.Enabled = enabled;
                listAttachments.Visible = enabled;

                // Keep listDevices visible so parsed devices are visible; hide only device-edit UI
                listDevices.Enabled = true;
                listDevices.Visible = true;
            }
            catch
            {
                // Ignore if some controls are not present for any reason
            }
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
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (isAutomatic && !autoParsed)
            {
                // try to parse automatically before creating
                if (!ParseAutomaticText())
                    return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Customer name is required");
                return;
            }

            if (tempDevices.Count == 0)
            {
                MessageBox.Show("Add at least one device.");
                return;
            }

            CustomerType type = rbCompany.Checked ? CustomerType.Company : CustomerType.Individual;
            string title = $"{txtName.Text} - {string.Join(", ", tempDevices.Select(d => d.Name))}";

            if (isEditMode)
            {
                editingThread.CustomerName = txtName.Text;
                editingThread.Phone = txtPhone.Text;
                editingThread.Devices = tempDevices;
                editingThread.Category = cmbCategory.Text;
                editingThread.Title = title;
                editingThread.Price = numPrice.Value;
                editingThread.FinishedAt = dtFinishedAt.Checked ? dtFinishedAt.Value : (DateTime?)null;
                editingThread.CustomerType = type;

                if (editingThread.Category == "Finished" && !editingThread.FinishedAt.HasValue)
                    editingThread.FinishedAt = DateTime.Now;

                editingThread.Attachments.Clear();
                foreach (var item in listAttachments.Items)
                {
                    var filePath = item as string;
                    if (File.Exists(filePath))
                    {
                        editingThread.Attachments.Add(new ThreadAttachment
                        {
                            FileName = Path.GetFileName(filePath),
                            FilePath = filePath
                        });
                    }
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
                    Title = title,
                    CreatedAt = DateTime.Now,
                    Price = numPrice.Value,
                    FinishedAt = dtFinishedAt.Checked ? dtFinishedAt.Value : (DateTime?)null,
                    CustomerType = type,
                    Attachments = new List<ThreadAttachment>()
                };

                foreach (var item in listAttachments.Items)
                {
                    var filePath = item as string;
                    if (File.Exists(filePath))
                    {
                        CreatedThread.Attachments.Add(new ThreadAttachment
                        {
                            FileName = Path.GetFileName(filePath),
                            FilePath = filePath
                        });
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDevice.Text))
            {
                MessageBox.Show("Device name is required.");
                return;
            }

            if (editingDevice == null)
            {
                var device = new DeviceItem();
                FillDeviceFromInputs(device);
                tempDevices.Add(device);
                listDevices.Items.Add(device);
            }
            else
            {
                FillDeviceFromInputs(editingDevice);
                listDevices.Refresh();
                editingDevice = null;
            }

            ClearDeviceInputs();
        }

        private void FillDeviceFromInputs(DeviceItem device)
        {
            device.Name = txtDevice.Text.Trim();
            device.DeviceType = txtDeviceType.Text.Trim();
            device.ModelNumber = txtModelNumber.Text.Trim();
            device.SerialNumber = txtSerialNumber.Text.Trim();
            device.Price = numPrice.Value;

            // Parse txtDate safely
            if (DateTime.TryParse(txtDate.Text.Trim(), out DateTime parsedDate))
                device.DateReceived = parsedDate;
            else
                device.DateReceived = null;

            // ✅ Update FinishedAt and State properly
            if (dtFinishedAt.Checked)
            {
                device.FinishedAt = DateTime.Now;
                device.State = "Finished";
            }
            else
            {
                device.FinishedAt = null;
                device.State = "In Progress";
            }

            device.Notes.Clear();
            if (!string.IsNullOrWhiteSpace(txtDeviceNote.Text))
                device.Notes.Add(new DeviceNote { Text = txtDeviceNote.Text.Trim() });
        }

        private void listDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDevices.SelectedItem is DeviceItem device)
            {
                // Only allow editing devices that are not finished
                if (device.State == "Finished")
                {
                    editingDevice = null;
                    ClearDeviceInputs();
                    return;
                }

                editingDevice = device;

                txtDevice.Text = device.Name;
                txtDeviceType.Text = device.DeviceType;
                txtModelNumber.Text = device.ModelNumber;
                txtSerialNumber.Text = device.SerialNumber;
                numPrice.Value = device.Price;
                txtDate.Text = device.DateReceived?.ToString("dd-MM-yyyy") ?? "";
                txtDeviceNote.Text = device.Notes.FirstOrDefault()?.Text ?? "";

                dtFinishedAt.Checked = device.State == "Finished";
            }
        }

        private void btnRemoveDevice_Click(object sender, EventArgs e)
        {
            if (listDevices.SelectedItem is DeviceItem device)
            {
                tempDevices.Remove(device);
                listDevices.Items.Remove(device);
                ClearDeviceInputs();
            }
        }

        private void ClearDeviceInputs()
        {
            editingDevice = null;
            txtDevice.Clear();
            txtDeviceType.Clear();
            txtModelNumber.Clear();
            txtSerialNumber.Clear();
            txtDeviceNote.Clear();
            txtDate.Clear();
            numPrice.Value = 0;
            dtFinishedAt.Checked = false;
        }

        private void btnAddAttachment_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Images & PDFs|*.jpg;*.jpeg;*.png;*.bmp;*.pdf|All Files|*.*";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                foreach (var file in ofd.FileNames)
                    listAttachments.Items.Add(file);
            }
        }

        private void btnRemoveAttachment_Click(object sender, EventArgs e)
        {
            var selected = listAttachments.SelectedIndices
                .Cast<int>()
                .OrderByDescending(i => i)
                .ToList();

            foreach (var i in selected)
                listAttachments.Items.RemoveAt(i);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // original behavior kept
        }

        private void rbCompany_CheckedChanged(object sender, EventArgs e)
        {
            // original behavior kept
            // txtCompanyName.Enabled = rbCompany.Checked;
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            txtPhone.SelectionStart = 0;
            txtPhone.SelectionLength = 0;
        }
    }
}
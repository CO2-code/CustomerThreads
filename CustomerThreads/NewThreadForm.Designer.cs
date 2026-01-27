namespace CustomerThreads
{
    partial class NewThreadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtDeviceNote = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.dtFinishedAt = new System.Windows.Forms.DateTimePicker();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbIndividual = new System.Windows.Forms.RadioButton();
            this.rbCompany = new System.Windows.Forms.RadioButton();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.listAttachments = new System.Windows.Forms.ListBox();
            this.btnAddAttachment = new System.Windows.Forms.Button();
            this.btnRemoveAttachment = new System.Windows.Forms.Button();
            this.listDevices = new System.Windows.Forms.ListBox();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.btnRemoveDevice = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtModelNumber = new System.Windows.Forms.TextBox();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.txtDeviceType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(17, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(118, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Customer Name :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(141, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(79, 65);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(56, 15);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Phone :";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.Location = new System.Drawing.Point(80, 107);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(55, 13);
            this.lblDevice.TabIndex = 4;
            this.lblDevice.Text = "Device :";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(433, 139);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(78, 16);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category :";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(517, 134);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 21);
            this.cmbCategory.TabIndex = 7;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Lime;
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(0, 637);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(1310, 40);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Create Thread";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.BackColor = System.Drawing.Color.Lavender;
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(0, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(66, 20);
            this.lblNote.TabIndex = 9;
            this.lblNote.Text = "Notes :";
            // 
            // txtDeviceNote
            // 
            this.txtDeviceNote.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDeviceNote.Location = new System.Drawing.Point(0, 22);
            this.txtDeviceNote.Margin = new System.Windows.Forms.Padding(0);
            this.txtDeviceNote.MaximumSize = new System.Drawing.Size(800, 400);
            this.txtDeviceNote.MinimumSize = new System.Drawing.Size(750, 380);
            this.txtDeviceNote.Multiline = true;
            this.txtDeviceNote.Name = "txtDeviceNote";
            this.txtDeviceNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDeviceNote.Size = new System.Drawing.Size(800, 400);
            this.txtDeviceNote.TabIndex = 10;
            // 
            // txtPhone
            // 
            this.txtPhone.HidePromptOnLeave = true;
            this.txtPhone.Location = new System.Drawing.Point(141, 60);
            this.txtPhone.Mask = "00 000 000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPhone.Size = new System.Drawing.Size(200, 20);
            this.txtPhone.TabIndex = 11;
            this.txtPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtPhone.Click += new System.EventHandler(this.txtPhone_Enter);
            // 
            // dtFinishedAt
            // 
            this.dtFinishedAt.Checked = false;
            this.dtFinishedAt.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtFinishedAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinishedAt.Location = new System.Drawing.Point(517, 20);
            this.dtFinishedAt.Name = "dtFinishedAt";
            this.dtFinishedAt.ShowCheckBox = true;
            this.dtFinishedAt.Size = new System.Drawing.Size(200, 20);
            this.dtFinishedAt.TabIndex = 12;
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(517, 100);
            this.numPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(200, 20);
            this.numPrice.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(445, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Amount :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(419, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Finished At :";
            // 
            // rbIndividual
            // 
            this.rbIndividual.AutoSize = true;
            this.rbIndividual.Location = new System.Drawing.Point(413, 192);
            this.rbIndividual.Name = "rbIndividual";
            this.rbIndividual.Size = new System.Drawing.Size(70, 17);
            this.rbIndividual.TabIndex = 16;
            this.rbIndividual.TabStop = true;
            this.rbIndividual.Text = "Individual";
            this.rbIndividual.UseVisualStyleBackColor = true;
            // 
            // rbCompany
            // 
            this.rbCompany.AutoSize = true;
            this.rbCompany.Location = new System.Drawing.Point(506, 192);
            this.rbCompany.Name = "rbCompany";
            this.rbCompany.Size = new System.Drawing.Size(69, 17);
            this.rbCompany.TabIndex = 17;
            this.rbCompany.TabStop = true;
            this.rbCompany.Text = "Company";
            this.rbCompany.UseVisualStyleBackColor = true;
            this.rbCompany.CheckedChanged += new System.EventHandler(this.rbCompany_CheckedChanged);
            // 
            // txtDevice
            // 
            this.txtDevice.Location = new System.Drawing.Point(141, 100);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Size = new System.Drawing.Size(200, 20);
            this.txtDevice.TabIndex = 19;
            // 
            // listAttachments
            // 
            this.listAttachments.Dock = System.Windows.Forms.DockStyle.Right;
            this.listAttachments.FormattingEnabled = true;
            this.listAttachments.Location = new System.Drawing.Point(902, 0);
            this.listAttachments.Name = "listAttachments";
            this.listAttachments.Size = new System.Drawing.Size(408, 422);
            this.listAttachments.TabIndex = 20;
            // 
            // btnAddAttachment
            // 
            this.btnAddAttachment.Location = new System.Drawing.Point(818, 31);
            this.btnAddAttachment.Name = "btnAddAttachment";
            this.btnAddAttachment.Size = new System.Drawing.Size(75, 23);
            this.btnAddAttachment.TabIndex = 21;
            this.btnAddAttachment.Text = "Add";
            this.btnAddAttachment.UseVisualStyleBackColor = true;
            this.btnAddAttachment.Click += new System.EventHandler(this.btnAddAttachment_Click);
            // 
            // btnRemoveAttachment
            // 
            this.btnRemoveAttachment.Location = new System.Drawing.Point(818, 335);
            this.btnRemoveAttachment.Name = "btnRemoveAttachment";
            this.btnRemoveAttachment.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAttachment.TabIndex = 22;
            this.btnRemoveAttachment.Text = "Remove";
            this.btnRemoveAttachment.UseVisualStyleBackColor = true;
            this.btnRemoveAttachment.Click += new System.EventHandler(this.btnRemoveAttachment_Click);
            // 
            // listDevices
            // 
            this.listDevices.Dock = System.Windows.Forms.DockStyle.Right;
            this.listDevices.FormattingEnabled = true;
            this.listDevices.Location = new System.Drawing.Point(110, 0);
            this.listDevices.MaximumSize = new System.Drawing.Size(455, 216);
            this.listDevices.MinimumSize = new System.Drawing.Size(450, 215);
            this.listDevices.Name = "listDevices";
            this.listDevices.Size = new System.Drawing.Size(450, 215);
            this.listDevices.TabIndex = 23;
            this.listDevices.SelectedIndexChanged += new System.EventHandler(this.listDevices_SelectedIndexChanged);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDevice.Location = new System.Drawing.Point(347, 97);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(34, 29);
            this.btnAddDevice.TabIndex = 24;
            this.btnAddDevice.Text = "+";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // btnRemoveDevice
            // 
            this.btnRemoveDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDevice.Location = new System.Drawing.Point(62, 174);
            this.btnRemoveDevice.Name = "btnRemoveDevice";
            this.btnRemoveDevice.Size = new System.Drawing.Size(34, 33);
            this.btnRemoveDevice.TabIndex = 25;
            this.btnRemoveDevice.Text = "-";
            this.btnRemoveDevice.UseVisualStyleBackColor = true;
            this.btnRemoveDevice.Click += new System.EventHandler(this.btnRemoveDevice_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.lblNote);
            this.panel1.Controls.Add(this.txtDeviceNote);
            this.panel1.Controls.Add(this.btnAddAttachment);
            this.panel1.Controls.Add(this.btnRemoveAttachment);
            this.panel1.Controls.Add(this.listAttachments);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1310, 422);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRemoveDevice);
            this.panel2.Controls.Add(this.listDevices);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(750, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 215);
            this.panel2.TabIndex = 27;
            // 
            // txtModelNumber
            // 
            this.txtModelNumber.Location = new System.Drawing.Point(141, 127);
            this.txtModelNumber.Name = "txtModelNumber";
            this.txtModelNumber.Size = new System.Drawing.Size(200, 20);
            this.txtModelNumber.TabIndex = 28;
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(141, 154);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(200, 20);
            this.txtSerialNumber.TabIndex = 29;
            // 
            // txtDeviceType
            // 
            this.txtDeviceType.Location = new System.Drawing.Point(141, 181);
            this.txtDeviceType.Name = "txtDeviceType";
            this.txtDeviceType.Size = new System.Drawing.Size(200, 20);
            this.txtDeviceType.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "M. N :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "S. N :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(84, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Type :";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(517, 60);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(200, 20);
            this.txtDate.TabIndex = 34;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(437, 65);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(74, 16);
            this.lblDate.TabIndex = 35;
            this.lblDate.Text = "Date rec :";
            // 
            // NewThreadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1310, 677);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDeviceType);
            this.Controls.Add(this.txtSerialNumber);
            this.Controls.Add(this.txtModelNumber);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.txtDevice);
            this.Controls.Add(this.rbCompany);
            this.Controls.Add(this.rbIndividual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.dtFinishedAt);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "NewThreadForm";
            this.ShowIcon = false;
            this.Text = "New Thread";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NewThreadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtFinishedAt;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbIndividual;
        private System.Windows.Forms.RadioButton rbCompany;
        // private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtDevice;
        private System.Windows.Forms.ListBox listAttachments;
        private System.Windows.Forms.Button btnAddAttachment;
        private System.Windows.Forms.Button btnRemoveAttachment;
        private System.Windows.Forms.ListBox listDevices;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Button btnRemoveDevice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDeviceNote;
        private System.Windows.Forms.TextBox txtModelNumber;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.TextBox txtDeviceType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label lblDate;
    }
}
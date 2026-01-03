namespace CustomerThreads
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listCategories = new System.Windows.Forms.ListBox();
            this.panelThreads = new System.Windows.Forms.Panel();
            this.listThreads = new System.Windows.Forms.ListBox();
            this.ctxThreadMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxExport = new System.Windows.Forms.ToolStripMenuItem();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblLastBackup = new System.Windows.Forms.Label();
            this.btnArchived = new System.Windows.Forms.Button();
            this.btnNewThread = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCustomerInfo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCustomerCategory = new System.Windows.Forms.Label();
            this.listDevicesMain = new System.Windows.Forms.ListBox();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblCustomerDevice = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listAttachmentsView = new System.Windows.Forms.ListBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.listNotes = new System.Windows.Forms.ListBox();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.picPanelLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelThreads.SuspendLayout();
            this.ctxThreadMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelCustomerInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPanelLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // listCategories
            // 
            this.listCategories.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCategories.FormattingEnabled = true;
            this.listCategories.ItemHeight = 20;
            this.listCategories.Items.AddRange(new object[] {
            "All",
            "New",
            "In Repair",
            "Waiting for Parts",
            "Finished"});
            this.listCategories.Location = new System.Drawing.Point(51, 3);
            this.listCategories.Name = "listCategories";
            this.listCategories.Size = new System.Drawing.Size(199, 24);
            this.listCategories.TabIndex = 1;
            this.listCategories.SelectedIndexChanged += new System.EventHandler(this.listCategories_SelectedIndexChanged);
            // 
            // panelThreads
            // 
            this.panelThreads.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelThreads.Controls.Add(this.listThreads);
            this.panelThreads.Controls.Add(this.txtSearch);
            this.panelThreads.Controls.Add(this.lblLastBackup);
            this.panelThreads.Controls.Add(this.btnArchived);
            this.panelThreads.Controls.Add(this.btnNewThread);
            this.panelThreads.Controls.Add(this.menuStrip1);
            this.panelThreads.Controls.Add(this.listCategories);
            this.panelThreads.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelThreads.Location = new System.Drawing.Point(0, 0);
            this.panelThreads.Name = "panelThreads";
            this.panelThreads.Size = new System.Drawing.Size(250, 550);
            this.panelThreads.TabIndex = 1;
            // 
            // listThreads
            // 
            this.listThreads.BackColor = System.Drawing.Color.Lavender;
            this.listThreads.ContextMenuStrip = this.ctxThreadMenu;
            this.listThreads.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listThreads.ForeColor = System.Drawing.Color.Black;
            this.listThreads.FormattingEnabled = true;
            this.listThreads.ItemHeight = 25;
            this.listThreads.Location = new System.Drawing.Point(0, 139);
            this.listThreads.MaximumSize = new System.Drawing.Size(250, 615);
            this.listThreads.MinimumSize = new System.Drawing.Size(247, 610);
            this.listThreads.Name = "listThreads";
            this.listThreads.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listThreads.Size = new System.Drawing.Size(247, 610);
            this.listThreads.TabIndex = 1;
            this.listThreads.SelectedIndexChanged += new System.EventHandler(this.listThreads_SelectedIndexChanged);
            this.listThreads.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listThreads_MouseDown);
            // 
            // ctxThreadMenu
            // 
            this.ctxThreadMenu.BackColor = System.Drawing.Color.SkyBlue;
            this.ctxThreadMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxEdit,
            this.ctxArchive,
            this.ctxDelete,
            this.ctxRestore,
            this.ctxExport});
            this.ctxThreadMenu.Name = "ctxThreadMenu";
            this.ctxThreadMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ctxThreadMenu.Size = new System.Drawing.Size(153, 114);
            this.ctxThreadMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxThreadMenu_Opening);
            // 
            // ctxEdit
            // 
            this.ctxEdit.Name = "ctxEdit";
            this.ctxEdit.Size = new System.Drawing.Size(152, 22);
            this.ctxEdit.Text = "Edit";
            this.ctxEdit.Click += new System.EventHandler(this.ctxEdit_Click);
            // 
            // ctxArchive
            // 
            this.ctxArchive.Name = "ctxArchive";
            this.ctxArchive.Size = new System.Drawing.Size(152, 22);
            this.ctxArchive.Text = "Archive";
            this.ctxArchive.Click += new System.EventHandler(this.ctxArchive_Click);
            // 
            // ctxDelete
            // 
            this.ctxDelete.Name = "ctxDelete";
            this.ctxDelete.Size = new System.Drawing.Size(152, 22);
            this.ctxDelete.Text = "Delete";
            this.ctxDelete.Click += new System.EventHandler(this.ctxDelete_Click);
            // 
            // ctxRestore
            // 
            this.ctxRestore.Name = "ctxRestore";
            this.ctxRestore.Size = new System.Drawing.Size(152, 22);
            this.ctxRestore.Text = "Restore";
            this.ctxRestore.Click += new System.EventHandler(this.ctxRestore_Click);
            // 
            // ctxExport
            // 
            this.ctxExport.Name = "ctxExport";
            this.ctxExport.Size = new System.Drawing.Size(152, 22);
            this.ctxExport.Text = "Export to Excel";
            this.ctxExport.Click += new System.EventHandler(this.ctxExport_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(0, 116);
            this.txtSearch.MaximumSize = new System.Drawing.Size(250, 25);
            this.txtSearch.MinimumSize = new System.Drawing.Size(248, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(248, 23);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lblLastBackup
            // 
            this.lblLastBackup.AutoSize = true;
            this.lblLastBackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLastBackup.Location = new System.Drawing.Point(0, 103);
            this.lblLastBackup.MaximumSize = new System.Drawing.Size(100, 20);
            this.lblLastBackup.MinimumSize = new System.Drawing.Size(80, 10);
            this.lblLastBackup.Name = "lblLastBackup";
            this.lblLastBackup.Size = new System.Drawing.Size(80, 13);
            this.lblLastBackup.TabIndex = 5;
            this.lblLastBackup.Text = "Last backup:";
            // 
            // btnArchived
            // 
            this.btnArchived.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnArchived.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnArchived.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchived.ForeColor = System.Drawing.Color.Black;
            this.btnArchived.Location = new System.Drawing.Point(0, 40);
            this.btnArchived.Name = "btnArchived";
            this.btnArchived.Size = new System.Drawing.Size(204, 63);
            this.btnArchived.TabIndex = 3;
            this.btnArchived.Text = "Open Archive";
            this.btnArchived.UseVisualStyleBackColor = false;
            this.btnArchived.Click += new System.EventHandler(this.btnArchived_Click);
            // 
            // btnNewThread
            // 
            this.btnNewThread.BackColor = System.Drawing.Color.Blue;
            this.btnNewThread.Cursor = System.Windows.Forms.Cursors.Cross;
            this.btnNewThread.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNewThread.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewThread.ForeColor = System.Drawing.Color.Black;
            this.btnNewThread.Location = new System.Drawing.Point(204, 40);
            this.btnNewThread.MaximumSize = new System.Drawing.Size(46, 35);
            this.btnNewThread.MinimumSize = new System.Drawing.Size(45, 30);
            this.btnNewThread.Name = "btnNewThread";
            this.btnNewThread.Size = new System.Drawing.Size(46, 35);
            this.btnNewThread.TabIndex = 2;
            this.btnNewThread.Text = " +";
            this.btnNewThread.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewThread.UseVisualStyleBackColor = false;
            this.btnNewThread.Click += new System.EventHandler(this.btnNewThread_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdmin});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(3);
            this.menuStrip1.MaximumSize = new System.Drawing.Size(45, 40);
            this.menuStrip1.MinimumSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(45, 40);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuAdmin
            // 
            this.menuAdmin.BackColor = System.Drawing.Color.Transparent;
            this.menuAdmin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdminLogin,
            this.menuAdminLogout,
            this.menuAdminChangePassword,
            this.menuAdminRefresh});
            this.menuAdmin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuAdmin.Image = ((System.Drawing.Image)(resources.GetObject("menuAdmin.Image")));
            this.menuAdmin.ImageTransparentColor = System.Drawing.Color.White;
            this.menuAdmin.Name = "menuAdmin";
            this.menuAdmin.Padding = new System.Windows.Forms.Padding(4);
            this.menuAdmin.Size = new System.Drawing.Size(37, 36);
            this.menuAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuAdminLogin
            // 
            this.menuAdminLogin.Name = "menuAdminLogin";
            this.menuAdminLogin.Size = new System.Drawing.Size(168, 22);
            this.menuAdminLogin.Text = "Log in ";
            this.menuAdminLogin.Click += new System.EventHandler(this.menuAdminLogin_Click);
            // 
            // menuAdminLogout
            // 
            this.menuAdminLogout.Name = "menuAdminLogout";
            this.menuAdminLogout.Size = new System.Drawing.Size(168, 22);
            this.menuAdminLogout.Text = "Log out";
            this.menuAdminLogout.Click += new System.EventHandler(this.menuAdminLogout_Click);
            // 
            // menuAdminChangePassword
            // 
            this.menuAdminChangePassword.Name = "menuAdminChangePassword";
            this.menuAdminChangePassword.Size = new System.Drawing.Size(168, 22);
            this.menuAdminChangePassword.Text = "Change Password";
            this.menuAdminChangePassword.Click += new System.EventHandler(this.menuAdminChangePassword_Click);
            // 
            // menuAdminRefresh
            // 
            this.menuAdminRefresh.Name = "menuAdminRefresh";
            this.menuAdminRefresh.Size = new System.Drawing.Size(168, 22);
            this.menuAdminRefresh.Text = "Refresh";
            this.menuAdminRefresh.Click += new System.EventHandler(this.menuAdminRefresh_Click);
            // 
            // panelCustomerInfo
            // 
            this.panelCustomerInfo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelCustomerInfo.Controls.Add(this.groupBox1);
            this.panelCustomerInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustomerInfo.Location = new System.Drawing.Point(0, 0);
            this.panelCustomerInfo.Name = "panelCustomerInfo";
            this.panelCustomerInfo.Size = new System.Drawing.Size(1065, 136);
            this.panelCustomerInfo.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.lblCustomerCategory);
            this.groupBox1.Controls.Add(this.listDevicesMain);
            this.groupBox1.Controls.Add(this.lblCustomerPhone);
            this.groupBox1.Controls.Add(this.lblCustomerDevice);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1065, 136);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // lblCustomerCategory
            // 
            this.lblCustomerCategory.AutoSize = true;
            this.lblCustomerCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerCategory.Location = new System.Drawing.Point(4, 92);
            this.lblCustomerCategory.Name = "lblCustomerCategory";
            this.lblCustomerCategory.Size = new System.Drawing.Size(78, 16);
            this.lblCustomerCategory.TabIndex = 4;
            this.lblCustomerCategory.Text = "Category :";
            // 
            // listDevicesMain
            // 
            this.listDevicesMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.listDevicesMain.FormattingEnabled = true;
            this.listDevicesMain.Location = new System.Drawing.Point(252, 16);
            this.listDevicesMain.MaximumSize = new System.Drawing.Size(815, 118);
            this.listDevicesMain.MinimumSize = new System.Drawing.Size(810, 117);
            this.listDevicesMain.Name = "listDevicesMain";
            this.listDevicesMain.Size = new System.Drawing.Size(810, 117);
            this.listDevicesMain.TabIndex = 5;
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerPhone.Location = new System.Drawing.Point(23, 58);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(59, 16);
            this.lblCustomerPhone.TabIndex = 1;
            this.lblCustomerPhone.Text = "Phone :";
            // 
            // lblCustomerDevice
            // 
            this.lblCustomerDevice.AutoSize = true;
            this.lblCustomerDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerDevice.Location = new System.Drawing.Point(190, 16);
            this.lblCustomerDevice.Name = "lblCustomerDevice";
            this.lblCustomerDevice.Size = new System.Drawing.Size(82, 16);
            this.lblCustomerDevice.TabIndex = 2;
            this.lblCustomerDevice.Text = "Device(s) :";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(26, 16);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(56, 16);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Name :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.listAttachmentsView);
            this.groupBox2.Controls.Add(this.picPreview);
            this.groupBox2.Controls.Add(this.listNotes);
            this.groupBox2.Location = new System.Drawing.Point(0, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1068, 636);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // listAttachmentsView
            // 
            this.listAttachmentsView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listAttachmentsView.Dock = System.Windows.Forms.DockStyle.Left;
            this.listAttachmentsView.FormattingEnabled = true;
            this.listAttachmentsView.Location = new System.Drawing.Point(306, 16);
            this.listAttachmentsView.Name = "listAttachmentsView";
            this.listAttachmentsView.Size = new System.Drawing.Size(220, 617);
            this.listAttachmentsView.TabIndex = 3;
            this.listAttachmentsView.SelectedIndexChanged += new System.EventHandler(this.listAttachmentsView_SelectedIndexChanged);
            this.listAttachmentsView.DoubleClick += new System.EventHandler(this.listAttachmentsView_DoubleClick);
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(532, 16);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(530, 393);
            this.picPreview.TabIndex = 4;
            this.picPreview.TabStop = false;
            this.picPreview.Visible = false;
            // 
            // listNotes
            // 
            this.listNotes.Dock = System.Windows.Forms.DockStyle.Left;
            this.listNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listNotes.FormattingEnabled = true;
            this.listNotes.ItemHeight = 18;
            this.listNotes.Location = new System.Drawing.Point(3, 16);
            this.listNotes.Name = "listNotes";
            this.listNotes.Size = new System.Drawing.Size(303, 617);
            this.listNotes.TabIndex = 2;
            // 
            // panelDetails
            // 
            this.panelDetails.AutoSize = true;
            this.panelDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDetails.Controls.Add(this.groupBox2);
            this.panelDetails.Controls.Add(this.panelCustomerInfo);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(250, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(1069, 550);
            this.panelDetails.TabIndex = 2;
            this.panelDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDetails_Paint);
            // 
            // picPanelLogo
            // 
            this.picPanelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picPanelLogo.Cursor = System.Windows.Forms.Cursors.No;
            this.picPanelLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picPanelLogo.Enabled = false;
            this.picPanelLogo.Image = ((System.Drawing.Image)(resources.GetObject("picPanelLogo.Image")));
            this.picPanelLogo.Location = new System.Drawing.Point(250, 0);
            this.picPanelLogo.Name = "picPanelLogo";
            this.picPanelLogo.Size = new System.Drawing.Size(1069, 550);
            this.picPanelLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPanelLogo.TabIndex = 6;
            this.picPanelLogo.TabStop = false;
            this.picPanelLogo.Click += new System.EventHandler(this.picPanelLogo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Turquoise;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 550);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1319, 10);
            this.panel1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1319, 560);
            this.Controls.Add(this.picPanelLogo);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelThreads);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Customer Threads";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelThreads.ResumeLayout(false);
            this.panelThreads.PerformLayout();
            this.ctxThreadMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelCustomerInfo.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPanelLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelThreads;
        private System.Windows.Forms.ListBox listCategories;
        private System.Windows.Forms.ListBox listThreads;
        private System.Windows.Forms.Button btnNewThread;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem menuAdminLogin;
        private System.Windows.Forms.ToolStripMenuItem menuAdminLogout;
        private System.Windows.Forms.ToolStripMenuItem menuAdminChangePassword;
        private System.Windows.Forms.ContextMenuStrip ctxThreadMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxEdit;
        private System.Windows.Forms.ToolStripMenuItem ctxArchive;
        private System.Windows.Forms.ToolStripMenuItem ctxDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxExport;
        private System.Windows.Forms.ToolStripMenuItem ctxRestore;
        private System.Windows.Forms.ToolStripMenuItem menuAdminRefresh;
        private System.Windows.Forms.Button btnArchived;
        private System.Windows.Forms.Panel panelCustomerInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCustomerCategory;
        private System.Windows.Forms.ListBox listDevicesMain;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblCustomerDevice;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listAttachmentsView;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.ListBox listNotes;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.PictureBox picPanelLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLastBackup;
    }
}


namespace BerryBox
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCodLoader = new System.Windows.Forms.TabPage();
            this.lvCodLoaderFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel_CodLoader = new System.Windows.Forms.Panel();
            this.cbForceDelete = new System.Windows.Forms.CheckBox();
            this.cbHideRimCods = new System.Windows.Forms.CheckBox();
            this.cbCheckAll = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.btnSaveSelected = new System.Windows.Forms.Button();
            this.btnLoadDeviceModules = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnInstallSelected = new System.Windows.Forms.Button();
            this.btnSelectCodFolder = new System.Windows.Forms.Button();
            this.tabJadCreator = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuildJad = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSoftVendor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSoftDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSoftVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSoftName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbCodFileList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowserCodFolder = new System.Windows.Forms.Button();
            this.tbCodPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSysTools = new System.Windows.Forms.TabPage();
            this.panel_SysTools_Right = new System.Windows.Forms.Panel();
            this.picture_SysTools_Screen = new System.Windows.Forms.PictureBox();
            this.groupBox_SysTools = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_SysTools_Capture = new System.Windows.Forms.Button();
            this.ddl_SysTools_ImageType = new System.Windows.Forms.ComboBox();
            this.btn_SysTools_ScreenCaptureBrowser = new System.Windows.Forms.Button();
            this.tb_SysTools_ScreenCaptureLocation = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btn_SysTools_TimeSync = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btn_SysTools_WirelessON = new System.Windows.Forms.Button();
            this.btn_SysTools_WirelessOFF = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbl_SysTools_Wipe = new System.Windows.Forms.Label();
            this.cb_SysTools_F = new System.Windows.Forms.CheckBox();
            this.cb_SysTools_A = new System.Windows.Forms.CheckBox();
            this.btn_SysTools_Wipe = new System.Windows.Forms.Button();
            this.tabOTADownloader = new System.Windows.Forms.TabPage();
            this.tb_OTA_CodFiles = new System.Windows.Forms.TextBox();
            this.progressBar_OTA = new System.Windows.Forms.ProgressBar();
            this.groupBox_OTA = new System.Windows.Forms.GroupBox();
            this.link_OTA_Help = new System.Windows.Forms.LinkLabel();
            this.btn_OTA_BrowseSaveFolder = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBox_OTA_OS = new System.Windows.Forms.ComboBox();
            this.comboBox_OTA_DeviceModel = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tb_OTA_SavePath = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label_OTA_CodCount = new System.Windows.Forms.Label();
            this.label_OTA_MIDletName = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btn_OTA_Download = new System.Windows.Forms.Button();
            this.tb_OTA_URL = new System.Windows.Forms.TextBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.labelBuild = new System.Windows.Forms.Label();
            this.linkLabelHomeWeb = new System.Windows.Forms.LinkLabel();
            this.labelBerryBoxTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbCodLoaderLog = new System.Windows.Forms.TextBox();
            this.dialogBrowserCodFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label_Global_OS = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label_Global_Status = new System.Windows.Forms.Label();
            this.label_Global_Vendor = new System.Windows.Forms.Label();
            this.label_Global_DeviceType = new System.Windows.Forms.Label();
            this.lable_Global_PIN = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Global_ConnectDevice = new System.Windows.Forms.Button();
            this.tb_Global_DevicePasswd = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabCodLoader.SuspendLayout();
            this.panel_CodLoader.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabJadCreator.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabSysTools.SuspendLayout();
            this.panel_SysTools_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_SysTools_Screen)).BeginInit();
            this.groupBox_SysTools.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabOTADownloader.SuspendLayout();
            this.groupBox_OTA.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCodLoader);
            this.tabControl1.Controls.Add(this.tabJadCreator);
            this.tabControl1.Controls.Add(this.tabSysTools);
            this.tabControl1.Controls.Add(this.tabOTADownloader);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 82);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(592, 338);
            this.tabControl1.TabIndex = 0;
            // 
            // tabCodLoader
            // 
            this.tabCodLoader.BackColor = System.Drawing.Color.Transparent;
            this.tabCodLoader.Controls.Add(this.lvCodLoaderFiles);
            this.tabCodLoader.Controls.Add(this.panel_CodLoader);
            this.tabCodLoader.Location = new System.Drawing.Point(4, 22);
            this.tabCodLoader.Name = "tabCodLoader";
            this.tabCodLoader.Padding = new System.Windows.Forms.Padding(3);
            this.tabCodLoader.Size = new System.Drawing.Size(584, 312);
            this.tabCodLoader.TabIndex = 1;
            this.tabCodLoader.Text = "COD安装器";
            this.tabCodLoader.UseVisualStyleBackColor = true;
            // 
            // lvCodLoaderFiles
            // 
            this.lvCodLoaderFiles.AllowDrop = true;
            this.lvCodLoaderFiles.CheckBoxes = true;
            this.lvCodLoaderFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvCodLoaderFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCodLoaderFiles.Enabled = false;
            this.lvCodLoaderFiles.FullRowSelect = true;
            this.lvCodLoaderFiles.GridLines = true;
            this.lvCodLoaderFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCodLoaderFiles.Location = new System.Drawing.Point(3, 88);
            this.lvCodLoaderFiles.Name = "lvCodLoaderFiles";
            this.lvCodLoaderFiles.ShowGroups = false;
            this.lvCodLoaderFiles.Size = new System.Drawing.Size(578, 221);
            this.lvCodLoaderFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCodLoaderFiles.TabIndex = 4;
            this.lvCodLoaderFiles.UseCompatibleStateImageBehavior = false;
            this.lvCodLoaderFiles.View = System.Windows.Forms.View.Details;
            this.lvCodLoaderFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvCodLoaderFiles_DragDrop);
            this.lvCodLoaderFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbCodFileList_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "大小";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "版本";
            // 
            // panel_CodLoader
            // 
            this.panel_CodLoader.Controls.Add(this.cbForceDelete);
            this.panel_CodLoader.Controls.Add(this.cbHideRimCods);
            this.panel_CodLoader.Controls.Add(this.cbCheckAll);
            this.panel_CodLoader.Controls.Add(this.groupBox4);
            this.panel_CodLoader.Controls.Add(this.groupBox3);
            this.panel_CodLoader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_CodLoader.Enabled = false;
            this.panel_CodLoader.Location = new System.Drawing.Point(3, 3);
            this.panel_CodLoader.Name = "panel_CodLoader";
            this.panel_CodLoader.Size = new System.Drawing.Size(578, 85);
            this.panel_CodLoader.TabIndex = 8;
            // 
            // cbForceDelete
            // 
            this.cbForceDelete.AutoSize = true;
            this.cbForceDelete.Location = new System.Drawing.Point(451, 40);
            this.cbForceDelete.Name = "cbForceDelete";
            this.cbForceDelete.Size = new System.Drawing.Size(72, 16);
            this.cbForceDelete.TabIndex = 12;
            this.cbForceDelete.Text = "强制删除";
            this.cbForceDelete.UseVisualStyleBackColor = true;
            // 
            // cbHideRimCods
            // 
            this.cbHideRimCods.AutoSize = true;
            this.cbHideRimCods.Checked = true;
            this.cbHideRimCods.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHideRimCods.Location = new System.Drawing.Point(451, 21);
            this.cbHideRimCods.Name = "cbHideRimCods";
            this.cbHideRimCods.Size = new System.Drawing.Size(132, 16);
            this.cbHideRimCods.TabIndex = 11;
            this.cbHideRimCods.Text = "读取时隐藏系统模块";
            this.cbHideRimCods.UseVisualStyleBackColor = true;
            // 
            // cbCheckAll
            // 
            this.cbCheckAll.AutoSize = true;
            this.cbCheckAll.Location = new System.Drawing.Point(451, 59);
            this.cbCheckAll.Name = "cbCheckAll";
            this.cbCheckAll.Size = new System.Drawing.Size(78, 16);
            this.cbCheckAll.TabIndex = 10;
            this.cbCheckAll.Text = "全选/不选";
            this.cbCheckAll.UseVisualStyleBackColor = true;
            this.cbCheckAll.Click += new System.EventHandler(this.cbCheckAll_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeleteSelected);
            this.groupBox4.Controls.Add(this.btnSaveSelected);
            this.groupBox4.Controls.Add(this.btnLoadDeviceModules);
            this.groupBox4.Location = new System.Drawing.Point(176, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 74);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "管理";
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(187, 29);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(69, 23);
            this.btnDeleteSelected.TabIndex = 6;
            this.btnDeleteSelected.Text = "删除选定";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnSaveSelected
            // 
            this.btnSaveSelected.Location = new System.Drawing.Point(112, 29);
            this.btnSaveSelected.Name = "btnSaveSelected";
            this.btnSaveSelected.Size = new System.Drawing.Size(69, 23);
            this.btnSaveSelected.TabIndex = 5;
            this.btnSaveSelected.Text = "保存选定";
            this.btnSaveSelected.UseVisualStyleBackColor = true;
            this.btnSaveSelected.Click += new System.EventHandler(this.btnSaveSelected_Click);
            // 
            // btnLoadDeviceModules
            // 
            this.btnLoadDeviceModules.Location = new System.Drawing.Point(10, 29);
            this.btnLoadDeviceModules.Name = "btnLoadDeviceModules";
            this.btnLoadDeviceModules.Size = new System.Drawing.Size(96, 23);
            this.btnLoadDeviceModules.TabIndex = 4;
            this.btnLoadDeviceModules.Text = "读取手机模块";
            this.btnLoadDeviceModules.UseVisualStyleBackColor = true;
            this.btnLoadDeviceModules.Click += new System.EventHandler(this.btnLoadDeviceModules_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnInstallSelected);
            this.groupBox3.Controls.Add(this.btnSelectCodFolder);
            this.groupBox3.Location = new System.Drawing.Point(3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 74);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "安装";
            // 
            // btnInstallSelected
            // 
            this.btnInstallSelected.Location = new System.Drawing.Point(24, 43);
            this.btnInstallSelected.Name = "btnInstallSelected";
            this.btnInstallSelected.Size = new System.Drawing.Size(107, 23);
            this.btnInstallSelected.TabIndex = 4;
            this.btnInstallSelected.Text = "安装选定";
            this.btnInstallSelected.UseVisualStyleBackColor = true;
            this.btnInstallSelected.Click += new System.EventHandler(this.btnInstallSelected_Click);
            // 
            // btnSelectCodFolder
            // 
            this.btnSelectCodFolder.Location = new System.Drawing.Point(24, 14);
            this.btnSelectCodFolder.Name = "btnSelectCodFolder";
            this.btnSelectCodFolder.Size = new System.Drawing.Size(107, 23);
            this.btnSelectCodFolder.TabIndex = 3;
            this.btnSelectCodFolder.Text = "选择COD目录";
            this.btnSelectCodFolder.UseVisualStyleBackColor = true;
            this.btnSelectCodFolder.Click += new System.EventHandler(this.btnSelectCodFolder_Click);
            // 
            // tabJadCreator
            // 
            this.tabJadCreator.BackColor = System.Drawing.Color.Transparent;
            this.tabJadCreator.Controls.Add(this.groupBox2);
            this.tabJadCreator.Controls.Add(this.groupBox1);
            this.tabJadCreator.Location = new System.Drawing.Point(4, 22);
            this.tabJadCreator.Name = "tabJadCreator";
            this.tabJadCreator.Padding = new System.Windows.Forms.Padding(3);
            this.tabJadCreator.Size = new System.Drawing.Size(584, 312);
            this.tabJadCreator.TabIndex = 0;
            this.tabJadCreator.Text = "JAD生成器";
            this.tabJadCreator.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuildJad);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbSoftVendor);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbSoftDescription);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbSoftVersion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbSoftName);
            this.groupBox2.Location = new System.Drawing.Point(300, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 299);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "软件信息";
            // 
            // btnBuildJad
            // 
            this.btnBuildJad.Enabled = false;
            this.btnBuildJad.Location = new System.Drawing.Point(114, 250);
            this.btnBuildJad.Name = "btnBuildJad";
            this.btnBuildJad.Size = new System.Drawing.Size(69, 23);
            this.btnBuildJad.TabIndex = 2;
            this.btnBuildJad.Text = "生成Jad";
            this.btnBuildJad.UseVisualStyleBackColor = true;
            this.btnBuildJad.Click += new System.EventHandler(this.btnBuildJad_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "软件供应商：";
            // 
            // tbSoftVendor
            // 
            this.tbSoftVendor.Location = new System.Drawing.Point(90, 153);
            this.tbSoftVendor.Name = "tbSoftVendor";
            this.tbSoftVendor.Size = new System.Drawing.Size(185, 21);
            this.tbSoftVendor.TabIndex = 8;
            this.tbSoftVendor.Text = "BerryBox";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "软件说明：";
            // 
            // tbSoftDescription
            // 
            this.tbSoftDescription.Location = new System.Drawing.Point(90, 116);
            this.tbSoftDescription.Name = "tbSoftDescription";
            this.tbSoftDescription.Size = new System.Drawing.Size(185, 21);
            this.tbSoftDescription.TabIndex = 6;
            this.tbSoftDescription.Text = "BerryBox";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "软件版本：";
            // 
            // tbSoftVersion
            // 
            this.tbSoftVersion.Location = new System.Drawing.Point(90, 78);
            this.tbSoftVersion.Name = "tbSoftVersion";
            this.tbSoftVersion.Size = new System.Drawing.Size(185, 21);
            this.tbSoftVersion.TabIndex = 4;
            this.tbSoftVersion.Text = "1.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "软件名称：";
            // 
            // tbSoftName
            // 
            this.tbSoftName.Location = new System.Drawing.Point(90, 39);
            this.tbSoftName.Name = "tbSoftName";
            this.tbSoftName.Size = new System.Drawing.Size(185, 21);
            this.tbSoftName.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCodFileList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBrowserCodFolder);
            this.groupBox1.Controls.Add(this.tbCodPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 299);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cod文件";
            // 
            // tbCodFileList
            // 
            this.tbCodFileList.AllowDrop = true;
            this.tbCodFileList.BackColor = System.Drawing.SystemColors.Window;
            this.tbCodFileList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCodFileList.Location = new System.Drawing.Point(10, 83);
            this.tbCodFileList.Multiline = true;
            this.tbCodFileList.Name = "tbCodFileList";
            this.tbCodFileList.ReadOnly = true;
            this.tbCodFileList.Size = new System.Drawing.Size(252, 210);
            this.tbCodFileList.TabIndex = 3;
            this.tbCodFileList.Text = "请从上面选择目录来列出cod文件，或者直接把要生成jad的cod文件拖入本窗口";
            this.tbCodFileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbCodFileList_DragDrop);
            this.tbCodFileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbCodFileList_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cod文件列表：";
            // 
            // btnBrowserCodFolder
            // 
            this.btnBrowserCodFolder.Location = new System.Drawing.Point(201, 30);
            this.btnBrowserCodFolder.Name = "btnBrowserCodFolder";
            this.btnBrowserCodFolder.Size = new System.Drawing.Size(37, 23);
            this.btnBrowserCodFolder.TabIndex = 1;
            this.btnBrowserCodFolder.Text = "...";
            this.btnBrowserCodFolder.UseVisualStyleBackColor = true;
            this.btnBrowserCodFolder.Click += new System.EventHandler(this.btnBrowserCodFolder_Click);
            // 
            // tbCodPath
            // 
            this.tbCodPath.BackColor = System.Drawing.SystemColors.Window;
            this.tbCodPath.Location = new System.Drawing.Point(10, 32);
            this.tbCodPath.Name = "tbCodPath";
            this.tbCodPath.ReadOnly = true;
            this.tbCodPath.Size = new System.Drawing.Size(185, 21);
            this.tbCodPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择Cod所在文件夹：";
            // 
            // tabSysTools
            // 
            this.tabSysTools.BackColor = System.Drawing.Color.Transparent;
            this.tabSysTools.Controls.Add(this.panel_SysTools_Right);
            this.tabSysTools.Controls.Add(this.groupBox_SysTools);
            this.tabSysTools.Location = new System.Drawing.Point(4, 22);
            this.tabSysTools.Name = "tabSysTools";
            this.tabSysTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabSysTools.Size = new System.Drawing.Size(584, 312);
            this.tabSysTools.TabIndex = 3;
            this.tabSysTools.Text = "系统工具";
            this.tabSysTools.UseVisualStyleBackColor = true;
            // 
            // panel_SysTools_Right
            // 
            this.panel_SysTools_Right.AutoScroll = true;
            this.panel_SysTools_Right.Controls.Add(this.picture_SysTools_Screen);
            this.panel_SysTools_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_SysTools_Right.Location = new System.Drawing.Point(261, 3);
            this.panel_SysTools_Right.Name = "panel_SysTools_Right";
            this.panel_SysTools_Right.Size = new System.Drawing.Size(320, 306);
            this.panel_SysTools_Right.TabIndex = 1;
            // 
            // picture_SysTools_Screen
            // 
            this.picture_SysTools_Screen.Location = new System.Drawing.Point(0, 8);
            this.picture_SysTools_Screen.Name = "picture_SysTools_Screen";
            this.picture_SysTools_Screen.Size = new System.Drawing.Size(320, 240);
            this.picture_SysTools_Screen.TabIndex = 0;
            this.picture_SysTools_Screen.TabStop = false;
            // 
            // groupBox_SysTools
            // 
            this.groupBox_SysTools.Controls.Add(this.groupBox10);
            this.groupBox_SysTools.Controls.Add(this.groupBox9);
            this.groupBox_SysTools.Controls.Add(this.groupBox8);
            this.groupBox_SysTools.Controls.Add(this.groupBox7);
            this.groupBox_SysTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox_SysTools.Enabled = false;
            this.groupBox_SysTools.Location = new System.Drawing.Point(3, 3);
            this.groupBox_SysTools.Name = "groupBox_SysTools";
            this.groupBox_SysTools.Size = new System.Drawing.Size(258, 306);
            this.groupBox_SysTools.TabIndex = 0;
            this.groupBox_SysTools.TabStop = false;
            this.groupBox_SysTools.Text = "系统工具";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label16);
            this.groupBox10.Controls.Add(this.btn_SysTools_Capture);
            this.groupBox10.Controls.Add(this.ddl_SysTools_ImageType);
            this.groupBox10.Controls.Add(this.btn_SysTools_ScreenCaptureBrowser);
            this.groupBox10.Controls.Add(this.tb_SysTools_ScreenCaptureLocation);
            this.groupBox10.Controls.Add(this.label14);
            this.groupBox10.Location = new System.Drawing.Point(3, 175);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(246, 126);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "截图";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 6;
            this.label16.Text = "图片格式:";
            // 
            // btn_SysTools_Capture
            // 
            this.btn_SysTools_Capture.Location = new System.Drawing.Point(163, 60);
            this.btn_SysTools_Capture.Name = "btn_SysTools_Capture";
            this.btn_SysTools_Capture.Size = new System.Drawing.Size(62, 52);
            this.btn_SysTools_Capture.TabIndex = 1;
            this.btn_SysTools_Capture.Text = "截图";
            this.btn_SysTools_Capture.UseVisualStyleBackColor = true;
            this.btn_SysTools_Capture.Click += new System.EventHandler(this.btn_SysTools_Capture_Click);
            // 
            // ddl_SysTools_ImageType
            // 
            this.ddl_SysTools_ImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddl_SysTools_ImageType.FormattingEnabled = true;
            this.ddl_SysTools_ImageType.Items.AddRange(new object[] {
            "JPG",
            "PNG",
            "BMP"});
            this.ddl_SysTools_ImageType.Location = new System.Drawing.Point(68, 59);
            this.ddl_SysTools_ImageType.Name = "ddl_SysTools_ImageType";
            this.ddl_SysTools_ImageType.Size = new System.Drawing.Size(57, 20);
            this.ddl_SysTools_ImageType.TabIndex = 5;
            // 
            // btn_SysTools_ScreenCaptureBrowser
            // 
            this.btn_SysTools_ScreenCaptureBrowser.Location = new System.Drawing.Point(200, 31);
            this.btn_SysTools_ScreenCaptureBrowser.Name = "btn_SysTools_ScreenCaptureBrowser";
            this.btn_SysTools_ScreenCaptureBrowser.Size = new System.Drawing.Size(37, 23);
            this.btn_SysTools_ScreenCaptureBrowser.TabIndex = 3;
            this.btn_SysTools_ScreenCaptureBrowser.Text = "...";
            this.btn_SysTools_ScreenCaptureBrowser.UseVisualStyleBackColor = true;
            this.btn_SysTools_ScreenCaptureBrowser.Click += new System.EventHandler(this.btn_SysTools_ScreenCaptureBrowser_Click);
            // 
            // tb_SysTools_ScreenCaptureLocation
            // 
            this.tb_SysTools_ScreenCaptureLocation.BackColor = System.Drawing.SystemColors.Window;
            this.tb_SysTools_ScreenCaptureLocation.Location = new System.Drawing.Point(9, 33);
            this.tb_SysTools_ScreenCaptureLocation.Name = "tb_SysTools_ScreenCaptureLocation";
            this.tb_SysTools_ScreenCaptureLocation.ReadOnly = true;
            this.tb_SysTools_ScreenCaptureLocation.Size = new System.Drawing.Size(185, 21);
            this.tb_SysTools_ScreenCaptureLocation.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "保存路径:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btn_SysTools_TimeSync);
            this.groupBox9.Location = new System.Drawing.Point(130, 101);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(119, 68);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "时间同步";
            // 
            // btn_SysTools_TimeSync
            // 
            this.btn_SysTools_TimeSync.Location = new System.Drawing.Point(23, 20);
            this.btn_SysTools_TimeSync.Name = "btn_SysTools_TimeSync";
            this.btn_SysTools_TimeSync.Size = new System.Drawing.Size(75, 35);
            this.btn_SysTools_TimeSync.TabIndex = 1;
            this.btn_SysTools_TimeSync.Text = "同步时间";
            this.btn_SysTools_TimeSync.UseVisualStyleBackColor = true;
            this.btn_SysTools_TimeSync.Click += new System.EventHandler(this.btn_SysTools_TimeSync_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btn_SysTools_WirelessON);
            this.groupBox8.Controls.Add(this.btn_SysTools_WirelessOFF);
            this.groupBox8.Location = new System.Drawing.Point(3, 101);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(119, 68);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "无线电";
            // 
            // btn_SysTools_WirelessON
            // 
            this.btn_SysTools_WirelessON.Location = new System.Drawing.Point(10, 20);
            this.btn_SysTools_WirelessON.Name = "btn_SysTools_WirelessON";
            this.btn_SysTools_WirelessON.Size = new System.Drawing.Size(40, 35);
            this.btn_SysTools_WirelessON.TabIndex = 1;
            this.btn_SysTools_WirelessON.Text = "开";
            this.btn_SysTools_WirelessON.UseVisualStyleBackColor = true;
            this.btn_SysTools_WirelessON.Click += new System.EventHandler(this.btn_SysTools_WirelessON_Click);
            // 
            // btn_SysTools_WirelessOFF
            // 
            this.btn_SysTools_WirelessOFF.Location = new System.Drawing.Point(68, 20);
            this.btn_SysTools_WirelessOFF.Name = "btn_SysTools_WirelessOFF";
            this.btn_SysTools_WirelessOFF.Size = new System.Drawing.Size(40, 35);
            this.btn_SysTools_WirelessOFF.TabIndex = 0;
            this.btn_SysTools_WirelessOFF.Text = "关";
            this.btn_SysTools_WirelessOFF.UseVisualStyleBackColor = true;
            this.btn_SysTools_WirelessOFF.Click += new System.EventHandler(this.btn_SysTools_WirelessOFF_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lbl_SysTools_Wipe);
            this.groupBox7.Controls.Add(this.cb_SysTools_F);
            this.groupBox7.Controls.Add(this.cb_SysTools_A);
            this.groupBox7.Controls.Add(this.btn_SysTools_Wipe);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 17);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(252, 78);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "WIPE手机";
            // 
            // lbl_SysTools_Wipe
            // 
            this.lbl_SysTools_Wipe.AutoSize = true;
            this.lbl_SysTools_Wipe.ForeColor = System.Drawing.Color.Red;
            this.lbl_SysTools_Wipe.Location = new System.Drawing.Point(85, 59);
            this.lbl_SysTools_Wipe.Name = "lbl_SysTools_Wipe";
            this.lbl_SysTools_Wipe.Size = new System.Drawing.Size(161, 12);
            this.lbl_SysTools_Wipe.TabIndex = 3;
            this.lbl_SysTools_Wipe.Text = "警告：此功能将擦除机器数据";
            // 
            // cb_SysTools_F
            // 
            this.cb_SysTools_F.AutoSize = true;
            this.cb_SysTools_F.Location = new System.Drawing.Point(113, 40);
            this.cb_SysTools_F.Name = "cb_SysTools_F";
            this.cb_SysTools_F.Size = new System.Drawing.Size(126, 16);
            this.cb_SysTools_F.TabIndex = 2;
            this.cb_SysTools_F.Text = "-f 只擦除文件系统";
            this.cb_SysTools_F.UseVisualStyleBackColor = true;
            // 
            // cb_SysTools_A
            // 
            this.cb_SysTools_A.AutoSize = true;
            this.cb_SysTools_A.Location = new System.Drawing.Point(113, 18);
            this.cb_SysTools_A.Name = "cb_SysTools_A";
            this.cb_SysTools_A.Size = new System.Drawing.Size(126, 16);
            this.cb_SysTools_A.TabIndex = 1;
            this.cb_SysTools_A.Text = "-a 只擦除应用程序";
            this.cb_SysTools_A.UseVisualStyleBackColor = true;
            // 
            // btn_SysTools_Wipe
            // 
            this.btn_SysTools_Wipe.Location = new System.Drawing.Point(10, 18);
            this.btn_SysTools_Wipe.Name = "btn_SysTools_Wipe";
            this.btn_SysTools_Wipe.Size = new System.Drawing.Size(62, 52);
            this.btn_SysTools_Wipe.TabIndex = 0;
            this.btn_SysTools_Wipe.Text = "WIPE";
            this.btn_SysTools_Wipe.UseVisualStyleBackColor = true;
            this.btn_SysTools_Wipe.Click += new System.EventHandler(this.btn_SysTools_Wipe_Click);
            // 
            // tabOTADownloader
            // 
            this.tabOTADownloader.BackColor = System.Drawing.SystemColors.Control;
            this.tabOTADownloader.Controls.Add(this.tb_OTA_CodFiles);
            this.tabOTADownloader.Controls.Add(this.progressBar_OTA);
            this.tabOTADownloader.Controls.Add(this.groupBox_OTA);
            this.tabOTADownloader.Location = new System.Drawing.Point(4, 22);
            this.tabOTADownloader.Name = "tabOTADownloader";
            this.tabOTADownloader.Size = new System.Drawing.Size(584, 312);
            this.tabOTADownloader.TabIndex = 4;
            this.tabOTADownloader.Text = "OTA下载";
            // 
            // tb_OTA_CodFiles
            // 
            this.tb_OTA_CodFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_OTA_CodFiles.Location = new System.Drawing.Point(0, 105);
            this.tb_OTA_CodFiles.Multiline = true;
            this.tb_OTA_CodFiles.Name = "tb_OTA_CodFiles";
            this.tb_OTA_CodFiles.ReadOnly = true;
            this.tb_OTA_CodFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_OTA_CodFiles.Size = new System.Drawing.Size(584, 184);
            this.tb_OTA_CodFiles.TabIndex = 15;
            // 
            // progressBar_OTA
            // 
            this.progressBar_OTA.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar_OTA.Location = new System.Drawing.Point(0, 289);
            this.progressBar_OTA.Name = "progressBar_OTA";
            this.progressBar_OTA.Size = new System.Drawing.Size(584, 23);
            this.progressBar_OTA.Step = 1;
            this.progressBar_OTA.TabIndex = 16;
            // 
            // groupBox_OTA
            // 
            this.groupBox_OTA.Controls.Add(this.link_OTA_Help);
            this.groupBox_OTA.Controls.Add(this.btn_OTA_BrowseSaveFolder);
            this.groupBox_OTA.Controls.Add(this.label21);
            this.groupBox_OTA.Controls.Add(this.comboBox_OTA_OS);
            this.groupBox_OTA.Controls.Add(this.comboBox_OTA_DeviceModel);
            this.groupBox_OTA.Controls.Add(this.label20);
            this.groupBox_OTA.Controls.Add(this.tb_OTA_SavePath);
            this.groupBox_OTA.Controls.Add(this.label19);
            this.groupBox_OTA.Controls.Add(this.label_OTA_CodCount);
            this.groupBox_OTA.Controls.Add(this.label_OTA_MIDletName);
            this.groupBox_OTA.Controls.Add(this.label18);
            this.groupBox_OTA.Controls.Add(this.label17);
            this.groupBox_OTA.Controls.Add(this.btn_OTA_Download);
            this.groupBox_OTA.Controls.Add(this.tb_OTA_URL);
            this.groupBox_OTA.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_OTA.Location = new System.Drawing.Point(0, 0);
            this.groupBox_OTA.Name = "groupBox_OTA";
            this.groupBox_OTA.Size = new System.Drawing.Size(584, 105);
            this.groupBox_OTA.TabIndex = 14;
            this.groupBox_OTA.TabStop = false;
            this.groupBox_OTA.Text = "OTA地址";
            // 
            // link_OTA_Help
            // 
            this.link_OTA_Help.AutoSize = true;
            this.link_OTA_Help.Location = new System.Drawing.Point(555, 23);
            this.link_OTA_Help.Name = "link_OTA_Help";
            this.link_OTA_Help.Size = new System.Drawing.Size(17, 12);
            this.link_OTA_Help.TabIndex = 25;
            this.link_OTA_Help.TabStop = true;
            this.link_OTA_Help.Text = "？";
            this.link_OTA_Help.MouseHover += new System.EventHandler(this.link_OTA_Help_MouseHover);
            // 
            // btn_OTA_BrowseSaveFolder
            // 
            this.btn_OTA_BrowseSaveFolder.Location = new System.Drawing.Point(255, 19);
            this.btn_OTA_BrowseSaveFolder.Name = "btn_OTA_BrowseSaveFolder";
            this.btn_OTA_BrowseSaveFolder.Size = new System.Drawing.Size(37, 23);
            this.btn_OTA_BrowseSaveFolder.TabIndex = 24;
            this.btn_OTA_BrowseSaveFolder.Text = "...";
            this.btn_OTA_BrowseSaveFolder.UseVisualStyleBackColor = true;
            this.btn_OTA_BrowseSaveFolder.Click += new System.EventHandler(this.btn_OTA_BrowseSaveFolder_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(456, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 12);
            this.label21.TabIndex = 23;
            this.label21.Text = "OS:";
            // 
            // comboBox_OTA_OS
            // 
            this.comboBox_OTA_OS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_OTA_OS.FormattingEnabled = true;
            this.comboBox_OTA_OS.Items.AddRange(new object[] {
            "4.0",
            "4.1",
            "4.2",
            "4.5",
            "4.6",
            "4.7",
            "5.0"});
            this.comboBox_OTA_OS.Location = new System.Drawing.Point(485, 20);
            this.comboBox_OTA_OS.Name = "comboBox_OTA_OS";
            this.comboBox_OTA_OS.Size = new System.Drawing.Size(64, 20);
            this.comboBox_OTA_OS.TabIndex = 22;
            // 
            // comboBox_OTA_DeviceModel
            // 
            this.comboBox_OTA_DeviceModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox_OTA_DeviceModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_OTA_DeviceModel.DropDownWidth = 150;
            this.comboBox_OTA_DeviceModel.FormattingEnabled = true;
            this.comboBox_OTA_DeviceModel.Location = new System.Drawing.Point(353, 20);
            this.comboBox_OTA_DeviceModel.Name = "comboBox_OTA_DeviceModel";
            this.comboBox_OTA_DeviceModel.Size = new System.Drawing.Size(94, 20);
            this.comboBox_OTA_DeviceModel.Sorted = true;
            this.comboBox_OTA_DeviceModel.TabIndex = 21;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(313, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 12);
            this.label20.TabIndex = 19;
            this.label20.Text = "型号:";
            // 
            // tb_OTA_SavePath
            // 
            this.tb_OTA_SavePath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_OTA_SavePath.Location = new System.Drawing.Point(97, 20);
            this.tb_OTA_SavePath.Name = "tb_OTA_SavePath";
            this.tb_OTA_SavePath.ReadOnly = true;
            this.tb_OTA_SavePath.Size = new System.Drawing.Size(150, 21);
            this.tb_OTA_SavePath.TabIndex = 18;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(22, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 17;
            this.label19.Text = "保存目录：";
            // 
            // label_OTA_CodCount
            // 
            this.label_OTA_CodCount.AutoSize = true;
            this.label_OTA_CodCount.Location = new System.Drawing.Point(448, 87);
            this.label_OTA_CodCount.Name = "label_OTA_CodCount";
            this.label_OTA_CodCount.Size = new System.Drawing.Size(113, 12);
            this.label_OTA_CodCount.TabIndex = 16;
            this.label_OTA_CodCount.Text = "共发现{0}个Cod文件";
            // 
            // label_OTA_MIDletName
            // 
            this.label_OTA_MIDletName.AutoSize = true;
            this.label_OTA_MIDletName.Location = new System.Drawing.Point(93, 87);
            this.label_OTA_MIDletName.Name = "label_OTA_MIDletName";
            this.label_OTA_MIDletName.Size = new System.Drawing.Size(47, 12);
            this.label_OTA_MIDletName.TabIndex = 15;
            this.label_OTA_MIDletName.Text = "UNKNOWN";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 87);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 12);
            this.label18.TabIndex = 14;
            this.label18.Text = "MIDlet-Name:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 12);
            this.label17.TabIndex = 1;
            this.label17.Text = "OTA下载链接：";
            // 
            // btn_OTA_Download
            // 
            this.btn_OTA_Download.Location = new System.Drawing.Point(489, 49);
            this.btn_OTA_Download.Name = "btn_OTA_Download";
            this.btn_OTA_Download.Size = new System.Drawing.Size(75, 23);
            this.btn_OTA_Download.TabIndex = 13;
            this.btn_OTA_Download.Text = "下载";
            this.btn_OTA_Download.UseVisualStyleBackColor = true;
            this.btn_OTA_Download.Click += new System.EventHandler(this.btn_OTA_Download_Click);
            // 
            // tb_OTA_URL
            // 
            this.tb_OTA_URL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tb_OTA_URL.Location = new System.Drawing.Point(97, 50);
            this.tb_OTA_URL.Name = "tb_OTA_URL";
            this.tb_OTA_URL.Size = new System.Drawing.Size(386, 21);
            this.tb_OTA_URL.TabIndex = 0;
            // 
            // tabAbout
            // 
            this.tabAbout.BackColor = System.Drawing.Color.Transparent;
            this.tabAbout.Controls.Add(this.panel3);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(584, 312);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "关于BerryBox";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.labelBuild);
            this.panel3.Controls.Add(this.linkLabelHomeWeb);
            this.panel3.Controls.Add(this.labelBerryBoxTitle);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(578, 223);
            this.panel3.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(256, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "by: Sky";
            // 
            // labelBuild
            // 
            this.labelBuild.AutoSize = true;
            this.labelBuild.Location = new System.Drawing.Point(331, 104);
            this.labelBuild.Name = "labelBuild";
            this.labelBuild.Size = new System.Drawing.Size(83, 12);
            this.labelBuild.TabIndex = 4;
            this.labelBuild.Text = "(build:03030)";
            // 
            // linkLabelHomeWeb
            // 
            this.linkLabelHomeWeb.AutoSize = true;
            this.linkLabelHomeWeb.LinkArea = new System.Windows.Forms.LinkArea(0, 9);
            this.linkLabelHomeWeb.Location = new System.Drawing.Point(238, 151);
            this.linkLabelHomeWeb.Name = "linkLabelHomeWeb";
            this.linkLabelHomeWeb.Size = new System.Drawing.Size(83, 12);
            this.linkLabelHomeWeb.TabIndex = 3;
            this.linkLabelHomeWeb.TabStop = true;
            this.linkLabelHomeWeb.Text = "访问作者 BLOG";
            this.linkLabelHomeWeb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabelHomeWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHomeWeb_LinkClicked);
            // 
            // labelBerryBoxTitle
            // 
            this.labelBerryBoxTitle.AutoSize = true;
            this.labelBerryBoxTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBerryBoxTitle.Location = new System.Drawing.Point(223, 97);
            this.labelBerryBoxTitle.Name = "labelBerryBoxTitle";
            this.labelBerryBoxTitle.Size = new System.Drawing.Size(113, 19);
            this.labelBerryBoxTitle.TabIndex = 1;
            this.labelBerryBoxTitle.Text = "BerryBox 0.1.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(244, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 65);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbCodLoaderLog
            // 
            this.tbCodLoaderLog.BackColor = System.Drawing.SystemColors.Window;
            this.tbCodLoaderLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbCodLoaderLog.Location = new System.Drawing.Point(0, 22);
            this.tbCodLoaderLog.Multiline = true;
            this.tbCodLoaderLog.Name = "tbCodLoaderLog";
            this.tbCodLoaderLog.ReadOnly = true;
            this.tbCodLoaderLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbCodLoaderLog.Size = new System.Drawing.Size(592, 109);
            this.tbCodLoaderLog.TabIndex = 2;
            // 
            // dialogBrowserCodFolder
            // 
            this.dialogBrowserCodFolder.ShowNewFolderButton = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelLeft});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(592, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelLeft
            // 
            this.statusLabelLeft.Name = "statusLabelLeft";
            this.statusLabelLeft.Size = new System.Drawing.Size(68, 17);
            this.statusLabelLeft.Text = "未连接设备";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label_Global_OS);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label_Global_Status);
            this.groupBox5.Controls.Add(this.label_Global_Vendor);
            this.groupBox5.Controls.Add(this.label_Global_DeviceType);
            this.groupBox5.Controls.Add(this.lable_Global_PIN);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.btn_Global_ConnectDevice);
            this.groupBox5.Controls.Add(this.tb_Global_DevicePasswd);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(592, 82);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "设备信息";
            // 
            // label_Global_OS
            // 
            this.label_Global_OS.AutoSize = true;
            this.label_Global_OS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Global_OS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Global_OS.Location = new System.Drawing.Point(211, 62);
            this.label_Global_OS.Name = "label_Global_OS";
            this.label_Global_OS.Size = new System.Drawing.Size(54, 12);
            this.label_Global_OS.TabIndex = 12;
            this.label_Global_OS.Text = "UNKNOWN";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(191, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 12);
            this.label15.TabIndex = 11;
            this.label15.Text = "OS:";
            // 
            // label_Global_Status
            // 
            this.label_Global_Status.AutoSize = true;
            this.label_Global_Status.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Global_Status.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Global_Status.Location = new System.Drawing.Point(79, 62);
            this.label_Global_Status.Name = "label_Global_Status";
            this.label_Global_Status.Size = new System.Drawing.Size(44, 12);
            this.label_Global_Status.TabIndex = 10;
            this.label_Global_Status.Text = "未连接";
            // 
            // label_Global_Vendor
            // 
            this.label_Global_Vendor.AutoSize = true;
            this.label_Global_Vendor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Global_Vendor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Global_Vendor.Location = new System.Drawing.Point(79, 47);
            this.label_Global_Vendor.Name = "label_Global_Vendor";
            this.label_Global_Vendor.Size = new System.Drawing.Size(44, 12);
            this.label_Global_Vendor.TabIndex = 9;
            this.label_Global_Vendor.Text = "未连接";
            // 
            // label_Global_DeviceType
            // 
            this.label_Global_DeviceType.AutoSize = true;
            this.label_Global_DeviceType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Global_DeviceType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_Global_DeviceType.Location = new System.Drawing.Point(79, 32);
            this.label_Global_DeviceType.Name = "label_Global_DeviceType";
            this.label_Global_DeviceType.Size = new System.Drawing.Size(44, 12);
            this.label_Global_DeviceType.TabIndex = 8;
            this.label_Global_DeviceType.Text = "未连接";
            // 
            // lable_Global_PIN
            // 
            this.lable_Global_PIN.AutoSize = true;
            this.lable_Global_PIN.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lable_Global_PIN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lable_Global_PIN.Location = new System.Drawing.Point(79, 17);
            this.lable_Global_PIN.Name = "lable_Global_PIN";
            this.lable_Global_PIN.Size = new System.Drawing.Size(44, 12);
            this.lable_Global_PIN.TabIndex = 7;
            this.lable_Global_PIN.Text = "未连接";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "无线电状态:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(35, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 5;
            this.label12.Text = "Vendor:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "型号:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "设备PIN:";
            // 
            // btn_Global_ConnectDevice
            // 
            this.btn_Global_ConnectDevice.Location = new System.Drawing.Point(370, 12);
            this.btn_Global_ConnectDevice.Name = "btn_Global_ConnectDevice";
            this.btn_Global_ConnectDevice.Size = new System.Drawing.Size(75, 23);
            this.btn_Global_ConnectDevice.TabIndex = 2;
            this.btn_Global_ConnectDevice.Text = "连接设备";
            this.btn_Global_ConnectDevice.UseVisualStyleBackColor = true;
            this.btn_Global_ConnectDevice.Click += new System.EventHandler(this.btn_Global_ConnectDevice_Click);
            // 
            // tb_Global_DevicePasswd
            // 
            this.tb_Global_DevicePasswd.Location = new System.Drawing.Point(251, 14);
            this.tb_Global_DevicePasswd.Name = "tb_Global_DevicePasswd";
            this.tb_Global_DevicePasswd.Size = new System.Drawing.Size(100, 21);
            this.tb_Global_DevicePasswd.TabIndex = 1;
            this.tb_Global_DevicePasswd.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(190, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "设备密码:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "日志：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tbCodLoaderLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 420);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 131);
            this.panel2.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 573);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "MainForm";
            this.Text = "BerryBox";
            this.tabControl1.ResumeLayout(false);
            this.tabCodLoader.ResumeLayout(false);
            this.panel_CodLoader.ResumeLayout(false);
            this.panel_CodLoader.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabJadCreator.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabSysTools.ResumeLayout(false);
            this.panel_SysTools_Right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_SysTools_Screen)).EndInit();
            this.groupBox_SysTools.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabOTADownloader.ResumeLayout(false);
            this.tabOTADownloader.PerformLayout();
            this.groupBox_OTA.ResumeLayout(false);
            this.groupBox_OTA.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabJadCreator;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbCodFileList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowserCodFolder;
        private System.Windows.Forms.TextBox tbCodPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog dialogBrowserCodFolder;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSoftVendor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSoftDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSoftVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSoftName;
        private System.Windows.Forms.Button btnBuildJad;
        private System.Windows.Forms.TabPage tabCodLoader;
        private System.Windows.Forms.TextBox tbCodLoaderLog;
        private System.Windows.Forms.ListView lvCodLoaderFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelLeft;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel_CodLoader;
        private System.Windows.Forms.CheckBox cbForceDelete;
        private System.Windows.Forms.CheckBox cbHideRimCods;
        private System.Windows.Forms.CheckBox cbCheckAll;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Button btnSaveSelected;
        private System.Windows.Forms.Button btnLoadDeviceModules;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnInstallSelected;
        private System.Windows.Forms.Button btnSelectCodFolder;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelBerryBoxTitle;
        private System.Windows.Forms.LinkLabel linkLabelHomeWeb;
        private System.Windows.Forms.Label labelBuild;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_Global_ConnectDevice;
        private System.Windows.Forms.TextBox tb_Global_DevicePasswd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_Global_Vendor;
        private System.Windows.Forms.Label label_Global_DeviceType;
        private System.Windows.Forms.Label lable_Global_PIN;
        private System.Windows.Forms.Label label_Global_Status;
        private System.Windows.Forms.Label label_Global_OS;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabSysTools;
        private System.Windows.Forms.GroupBox groupBox_SysTools;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cb_SysTools_F;
        private System.Windows.Forms.CheckBox cb_SysTools_A;
        private System.Windows.Forms.Button btn_SysTools_Wipe;
        private System.Windows.Forms.Label lbl_SysTools_Wipe;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btn_SysTools_TimeSync;
        private System.Windows.Forms.Button btn_SysTools_WirelessON;
        private System.Windows.Forms.Button btn_SysTools_WirelessOFF;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btn_SysTools_Capture;
        private System.Windows.Forms.Button btn_SysTools_ScreenCaptureBrowser;
        private System.Windows.Forms.TextBox tb_SysTools_ScreenCaptureLocation;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox ddl_SysTools_ImageType;
        private System.Windows.Forms.Panel panel_SysTools_Right;
        private System.Windows.Forms.PictureBox picture_SysTools_Screen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabOTADownloader;
        private System.Windows.Forms.Button btn_OTA_Download;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tb_OTA_URL;
        private System.Windows.Forms.GroupBox groupBox_OTA;
        private System.Windows.Forms.TextBox tb_OTA_CodFiles;
        private System.Windows.Forms.ProgressBar progressBar_OTA;
        private System.Windows.Forms.Label label_OTA_CodCount;
        private System.Windows.Forms.Label label_OTA_MIDletName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tb_OTA_SavePath;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBox_OTA_DeviceModel;
        private System.Windows.Forms.ComboBox comboBox_OTA_OS;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btn_OTA_BrowseSaveFolder;
        private System.Windows.Forms.LinkLabel link_OTA_Help;
    }
}


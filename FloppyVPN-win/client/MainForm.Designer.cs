namespace FloppyVPN
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
			this.windowPanel = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureConnectionStatus = new System.Windows.Forms.PictureBox();
			this.labelConnectionStatus = new System.Windows.Forms.Label();
			this.windowMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttExit = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttStartup = new System.Windows.Forms.ToolStripMenuItem();
			this.buttStartupStatus = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.buttAddToStartup = new System.Windows.Forms.ToolStripMenuItem();
			this.buttRemoveFromStartup = new System.Windows.Forms.ToolStripMenuItem();
			this.buttLanguage = new System.Windows.Forms.ToolStripMenuItem();
			this.buttEN = new System.Windows.Forms.ToolStripMenuItem();
			this.buttRU = new System.Windows.Forms.ToolStripMenuItem();
			this.buttUK = new System.Windows.Forms.ToolStripMenuItem();
			this.buttJA = new System.Windows.Forms.ToolStripMenuItem();
			this.buttSplitTunneling = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttUpdate = new System.Windows.Forms.ToolStripMenuItem();
			this.buttWebsite = new System.Windows.Forms.ToolStripMenuItem();
			this.groupConnection = new System.Windows.Forms.GroupBox();
			this.pictureCountry = new System.Windows.Forms.PictureBox();
			this.boxServer = new System.Windows.Forms.ComboBox();
			this.buttConnectDisconnect = new System.Windows.Forms.Button();
			this.pictureConnectionIllustration = new System.Windows.Forms.PictureBox();
			this.groupAccount = new System.Windows.Forms.GroupBox();
			this.buttLogout = new System.Windows.Forms.Button();
			this.buttRefreshData = new System.Windows.Forms.Button();
			this.buttAddTime = new System.Windows.Forms.Button();
			this.labelAccountStatus = new System.Windows.Forms.Label();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.labelCurrentIpCaption = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelCurrentIp = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.buttRevealIp = new System.Windows.Forms.ToolStripDropDownButton();
			this.stripIPprivate = new System.Windows.Forms.ToolStripMenuItem();
			this.stripIPpublic = new System.Windows.Forms.ToolStripMenuItem();
			this.tabsImages = new System.Windows.Forms.ImageList(this.components);
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.buttShow = new System.Windows.Forms.ToolStripMenuItem();
			this.buttTrayStatus = new System.Windows.Forms.ToolStripMenuItem();
			this.buttTrayConnectDisconnect = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttTrayExit = new System.Windows.Forms.ToolStripMenuItem();
			this.borderPanel = new System.Windows.Forms.Panel();
			this.windowPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureConnectionStatus)).BeginInit();
			this.windowMenu.SuspendLayout();
			this.groupConnection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureCountry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureConnectionIllustration)).BeginInit();
			this.groupAccount.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.trayMenu.SuspendLayout();
			this.borderPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// windowPanel
			// 
			this.windowPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(206)))));
			this.windowPanel.Controls.Add(this.panel1);
			this.windowPanel.Controls.Add(this.windowMenu);
			this.windowPanel.Controls.Add(this.groupConnection);
			this.windowPanel.Controls.Add(this.groupAccount);
			this.windowPanel.Controls.Add(this.statusBar);
			this.windowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.windowPanel.Location = new System.Drawing.Point(0, 0);
			this.windowPanel.Margin = new System.Windows.Forms.Padding(0);
			this.windowPanel.Name = "windowPanel";
			this.windowPanel.Size = new System.Drawing.Size(409, 438);
			this.windowPanel.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.pictureConnectionStatus);
			this.panel1.Controls.Add(this.labelConnectionStatus);
			this.panel1.Location = new System.Drawing.Point(16, 48);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(378, 60);
			this.panel1.TabIndex = 16;
			// 
			// pictureConnectionStatus
			// 
			this.pictureConnectionStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureConnectionStatus.BackgroundImage")));
			this.pictureConnectionStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureConnectionStatus.Location = new System.Drawing.Point(14, 10);
			this.pictureConnectionStatus.Margin = new System.Windows.Forms.Padding(2);
			this.pictureConnectionStatus.Name = "pictureConnectionStatus";
			this.pictureConnectionStatus.Size = new System.Drawing.Size(39, 39);
			this.pictureConnectionStatus.TabIndex = 6;
			this.pictureConnectionStatus.TabStop = false;
			// 
			// labelConnectionStatus
			// 
			this.labelConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelConnectionStatus.Location = new System.Drawing.Point(59, 10);
			this.labelConnectionStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelConnectionStatus.Name = "labelConnectionStatus";
			this.labelConnectionStatus.Size = new System.Drawing.Size(298, 39);
			this.labelConnectionStatus.TabIndex = 5;
			this.labelConnectionStatus.Text = "Not connected";
			this.labelConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// windowMenu
			// 
			this.windowMenu.AutoSize = false;
			this.windowMenu.BackColor = System.Drawing.Color.WhiteSmoke;
			this.windowMenu.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.windowMenu.GripMargin = new System.Windows.Forms.Padding(0);
			this.windowMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.windowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.windowMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.windowMenu.Location = new System.Drawing.Point(0, 0);
			this.windowMenu.Name = "windowMenu";
			this.windowMenu.Padding = new System.Windows.Forms.Padding(2, 2, 0, 5);
			this.windowMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.windowMenu.Size = new System.Drawing.Size(409, 28);
			this.windowMenu.TabIndex = 15;
			this.windowMenu.Text = "windowMenu";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 22);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// buttExit
			// 
			this.buttExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.buttExit.Name = "buttExit";
			this.buttExit.Size = new System.Drawing.Size(217, 26);
			this.buttExit.Text = "Disconnect and exit";
			this.buttExit.Click += new System.EventHandler(this.DisconnectAndQuit);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttStartup,
            this.buttLanguage,
            this.buttSplitTunneling});
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
			this.optionsToolStripMenuItem.Text = "Options";
			// 
			// buttStartup
			// 
			this.buttStartup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.buttStartup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttStartupStatus,
            this.toolStripSeparator2,
            this.buttAddToStartup,
            this.buttRemoveFromStartup});
			this.buttStartup.Name = "buttStartup";
			this.buttStartup.Size = new System.Drawing.Size(192, 26);
			this.buttStartup.Text = "Startup";
			this.buttStartup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttStartup.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			// 
			// buttStartupStatus
			// 
			this.buttStartupStatus.Enabled = false;
			this.buttStartupStatus.Image = ((System.Drawing.Image)(resources.GetObject("buttStartupStatus.Image")));
			this.buttStartupStatus.Name = "buttStartupStatus";
			this.buttStartupStatus.Size = new System.Drawing.Size(306, 26);
			this.buttStartupStatus.Text = "Currently NOT added to Startup";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(303, 6);
			// 
			// buttAddToStartup
			// 
			this.buttAddToStartup.Name = "buttAddToStartup";
			this.buttAddToStartup.Size = new System.Drawing.Size(306, 26);
			this.buttAddToStartup.Text = "Add FloppyVPN to Startup";
			// 
			// buttRemoveFromStartup
			// 
			this.buttRemoveFromStartup.Name = "buttRemoveFromStartup";
			this.buttRemoveFromStartup.Size = new System.Drawing.Size(306, 26);
			this.buttRemoveFromStartup.Text = "Remove FloppyVPN from Startup";
			// 
			// buttLanguage
			// 
			this.buttLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttEN,
            this.buttRU,
            this.buttUK,
            this.buttJA});
			this.buttLanguage.Name = "buttLanguage";
			this.buttLanguage.Size = new System.Drawing.Size(192, 26);
			this.buttLanguage.Text = "Language";
			this.buttLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttLanguage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.buttLanguage.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.buttLanguage_DropDownItemClicked);
			// 
			// buttEN
			// 
			this.buttEN.Name = "buttEN";
			this.buttEN.Size = new System.Drawing.Size(162, 26);
			this.buttEN.Text = "English";
			this.buttEN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttEN.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			// 
			// buttRU
			// 
			this.buttRU.Name = "buttRU";
			this.buttRU.Size = new System.Drawing.Size(162, 26);
			this.buttRU.Text = "Руский";
			this.buttRU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttRU.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			// 
			// buttUK
			// 
			this.buttUK.Name = "buttUK";
			this.buttUK.Size = new System.Drawing.Size(162, 26);
			this.buttUK.Text = "Українська";
			this.buttUK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttUK.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			// 
			// buttJA
			// 
			this.buttJA.Name = "buttJA";
			this.buttJA.Size = new System.Drawing.Size(162, 26);
			this.buttJA.Text = "日本語";
			this.buttJA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttJA.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			// 
			// buttSplitTunneling
			// 
			this.buttSplitTunneling.Name = "buttSplitTunneling";
			this.buttSplitTunneling.Size = new System.Drawing.Size(192, 26);
			this.buttSplitTunneling.Text = "Split tunneling...";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttUpdate,
            this.buttWebsite});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(50, 22);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// buttUpdate
			// 
			this.buttUpdate.Name = "buttUpdate";
			this.buttUpdate.Size = new System.Drawing.Size(217, 26);
			this.buttUpdate.Text = "Check for update...";
			this.buttUpdate.Click += new System.EventHandler(this.buttUpdate_Click);
			// 
			// buttWebsite
			// 
			this.buttWebsite.Name = "buttWebsite";
			this.buttWebsite.Size = new System.Drawing.Size(217, 26);
			this.buttWebsite.Text = "Website...";
			this.buttWebsite.Click += new System.EventHandler(this.buttWebsite_Click);
			// 
			// groupConnection
			// 
			this.groupConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(206)))));
			this.groupConnection.Controls.Add(this.pictureCountry);
			this.groupConnection.Controls.Add(this.boxServer);
			this.groupConnection.Controls.Add(this.buttConnectDisconnect);
			this.groupConnection.Controls.Add(this.pictureConnectionIllustration);
			this.groupConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupConnection.Location = new System.Drawing.Point(16, 130);
			this.groupConnection.Margin = new System.Windows.Forms.Padding(2);
			this.groupConnection.Name = "groupConnection";
			this.groupConnection.Padding = new System.Windows.Forms.Padding(2);
			this.groupConnection.Size = new System.Drawing.Size(378, 124);
			this.groupConnection.TabIndex = 13;
			this.groupConnection.TabStop = false;
			this.groupConnection.Text = "Connection";
			// 
			// pictureCountry
			// 
			this.pictureCountry.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureCountry.BackgroundImage")));
			this.pictureCountry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureCountry.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureCountry.Enabled = false;
			this.pictureCountry.ErrorImage = null;
			this.pictureCountry.InitialImage = null;
			this.pictureCountry.Location = new System.Drawing.Point(115, 88);
			this.pictureCountry.Margin = new System.Windows.Forms.Padding(4);
			this.pictureCountry.Name = "pictureCountry";
			this.pictureCountry.Size = new System.Drawing.Size(25, 25);
			this.pictureCountry.TabIndex = 16;
			this.pictureCountry.TabStop = false;
			// 
			// boxServer
			// 
			this.boxServer.BackColor = System.Drawing.Color.WhiteSmoke;
			this.boxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.boxServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.boxServer.FormattingEnabled = true;
			this.boxServer.Items.AddRange(new object[] {
            "Poland (Kurwaserver)"});
			this.boxServer.Location = new System.Drawing.Point(146, 88);
			this.boxServer.Margin = new System.Windows.Forms.Padding(4);
			this.boxServer.Name = "boxServer";
			this.boxServer.Size = new System.Drawing.Size(204, 24);
			this.boxServer.TabIndex = 15;
			// 
			// buttConnectDisconnect
			// 
			this.buttConnectDisconnect.BackColor = System.Drawing.Color.WhiteSmoke;
			this.buttConnectDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttConnectDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttConnectDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("buttConnectDisconnect.Image")));
			this.buttConnectDisconnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttConnectDisconnect.Location = new System.Drawing.Point(115, 34);
			this.buttConnectDisconnect.Margin = new System.Windows.Forms.Padding(2);
			this.buttConnectDisconnect.Name = "buttConnectDisconnect";
			this.buttConnectDisconnect.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
			this.buttConnectDisconnect.Size = new System.Drawing.Size(236, 48);
			this.buttConnectDisconnect.TabIndex = 14;
			this.buttConnectDisconnect.Text = "&Connect";
			this.buttConnectDisconnect.UseCompatibleTextRendering = true;
			this.buttConnectDisconnect.UseVisualStyleBackColor = false;
			this.buttConnectDisconnect.Click += new System.EventHandler(this.buttConnectDisconnect_Click);
			// 
			// pictureConnectionIllustration
			// 
			this.pictureConnectionIllustration.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureConnectionIllustration.BackgroundImage")));
			this.pictureConnectionIllustration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureConnectionIllustration.Location = new System.Drawing.Point(16, 34);
			this.pictureConnectionIllustration.Margin = new System.Windows.Forms.Padding(2);
			this.pictureConnectionIllustration.Name = "pictureConnectionIllustration";
			this.pictureConnectionIllustration.Size = new System.Drawing.Size(80, 71);
			this.pictureConnectionIllustration.TabIndex = 13;
			this.pictureConnectionIllustration.TabStop = false;
			// 
			// groupAccount
			// 
			this.groupAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(214)))), ((int)(((byte)(206)))));
			this.groupAccount.Controls.Add(this.buttLogout);
			this.groupAccount.Controls.Add(this.buttRefreshData);
			this.groupAccount.Controls.Add(this.buttAddTime);
			this.groupAccount.Controls.Add(this.labelAccountStatus);
			this.groupAccount.Location = new System.Drawing.Point(16, 270);
			this.groupAccount.Margin = new System.Windows.Forms.Padding(2);
			this.groupAccount.Name = "groupAccount";
			this.groupAccount.Padding = new System.Windows.Forms.Padding(2);
			this.groupAccount.Size = new System.Drawing.Size(378, 128);
			this.groupAccount.TabIndex = 14;
			this.groupAccount.TabStop = false;
			this.groupAccount.Text = "Account";
			// 
			// buttLogout
			// 
			this.buttLogout.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttLogout.Location = new System.Drawing.Point(242, 85);
			this.buttLogout.Margin = new System.Windows.Forms.Padding(2);
			this.buttLogout.Name = "buttLogout";
			this.buttLogout.Size = new System.Drawing.Size(109, 26);
			this.buttLogout.TabIndex = 3;
			this.buttLogout.Text = "&Log out";
			this.buttLogout.UseCompatibleTextRendering = true;
			this.buttLogout.UseVisualStyleBackColor = false;
			this.buttLogout.Click += new System.EventHandler(this.buttLoginLogout_Click);
			// 
			// buttRefreshData
			// 
			this.buttRefreshData.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttRefreshData.Location = new System.Drawing.Point(242, 51);
			this.buttRefreshData.Margin = new System.Windows.Forms.Padding(2);
			this.buttRefreshData.Name = "buttRefreshData";
			this.buttRefreshData.Size = new System.Drawing.Size(109, 26);
			this.buttRefreshData.TabIndex = 2;
			this.buttRefreshData.Text = "Refresh";
			this.buttRefreshData.UseVisualStyleBackColor = true;
			this.buttRefreshData.Click += new System.EventHandler(this.buttRefreshData_Click);
			// 
			// buttAddTime
			// 
			this.buttAddTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttAddTime.Location = new System.Drawing.Point(242, 18);
			this.buttAddTime.Margin = new System.Windows.Forms.Padding(2);
			this.buttAddTime.Name = "buttAddTime";
			this.buttAddTime.Size = new System.Drawing.Size(109, 26);
			this.buttAddTime.TabIndex = 1;
			this.buttAddTime.Text = "Add time...";
			this.buttAddTime.UseVisualStyleBackColor = true;
			this.buttAddTime.Click += new System.EventHandler(this.buttAddTime_Click);
			// 
			// labelAccountStatus
			// 
			this.labelAccountStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAccountStatus.Location = new System.Drawing.Point(16, 28);
			this.labelAccountStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelAccountStatus.Name = "labelAccountStatus";
			this.labelAccountStatus.Size = new System.Drawing.Size(208, 75);
			this.labelAccountStatus.TabIndex = 0;
			this.labelAccountStatus.Text = "Login: d5fez******\r\nPaid until: 2024.03.26\r\nDays left: 85";
			this.labelAccountStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelAccountStatus.UseCompatibleTextRendering = true;
			// 
			// statusBar
			// 
			this.statusBar.BackColor = System.Drawing.Color.WhiteSmoke;
			this.statusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelCurrentIpCaption,
            this.labelCurrentIp,
            this.toolStripStatusLabel2,
            this.buttRevealIp});
			this.statusBar.Location = new System.Drawing.Point(0, 414);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(409, 24);
			this.statusBar.TabIndex = 11;
			this.statusBar.Text = "statusStrip1";
			// 
			// labelCurrentIpCaption
			// 
			this.labelCurrentIpCaption.Name = "labelCurrentIpCaption";
			this.labelCurrentIpCaption.Size = new System.Drawing.Size(78, 18);
			this.labelCurrentIpCaption.Text = "Current IP:";
			// 
			// labelCurrentIp
			// 
			this.labelCurrentIp.Name = "labelCurrentIp";
			this.labelCurrentIp.Size = new System.Drawing.Size(156, 18);
			this.labelCurrentIp.Text = "ffff:ffff:ffff:ffff / 127.0.0.1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.Silver;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 18);
			this.toolStripStatusLabel2.Text = "|";
			// 
			// buttRevealIp
			// 
			this.buttRevealIp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.buttRevealIp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripIPprivate,
            this.stripIPpublic});
			this.buttRevealIp.Image = ((System.Drawing.Image)(resources.GetObject("buttRevealIp.Image")));
			this.buttRevealIp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.buttRevealIp.Name = "buttRevealIp";
			this.buttRevealIp.Size = new System.Drawing.Size(84, 22);
			this.buttRevealIp.Text = "Reveal IP";
			// 
			// stripIPprivate
			// 
			this.stripIPprivate.Name = "stripIPprivate";
			this.stripIPprivate.Size = new System.Drawing.Size(181, 26);
			this.stripIPprivate.Text = "public ip here";
			// 
			// stripIPpublic
			// 
			this.stripIPpublic.Name = "stripIPpublic";
			this.stripIPpublic.Size = new System.Drawing.Size(181, 26);
			this.stripIPpublic.Text = "private ip here";
			// 
			// tabsImages
			// 
			this.tabsImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabsImages.ImageStream")));
			this.tabsImages.TransparentColor = System.Drawing.Color.Transparent;
			this.tabsImages.Images.SetKeyName(0, "status.png");
			this.tabsImages.Images.SetKeyName(1, "settings.png");
			this.tabsImages.Images.SetKeyName(2, "help_sheet-1.png");
			// 
			// trayIcon
			// 
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "FloppyVPN: DISCONNECTED";
			this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
			// 
			// trayMenu
			// 
			this.trayMenu.AllowMerge = false;
			this.trayMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.trayMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttShow,
            this.buttTrayStatus,
            this.buttTrayConnectDisconnect,
            this.toolStripSeparator1,
            this.buttTrayExit});
			this.trayMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
			this.trayMenu.Name = "contextMenuStrip1";
			this.trayMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.trayMenu.ShowItemToolTips = false;
			this.trayMenu.Size = new System.Drawing.Size(190, 98);
			this.trayMenu.Text = "FloppyVPN";
			// 
			// buttShow
			// 
			this.buttShow.Name = "buttShow";
			this.buttShow.Size = new System.Drawing.Size(189, 22);
			this.buttShow.Text = "Show window";
			this.buttShow.Click += new System.EventHandler(this.buttShow_Click);
			// 
			// buttTrayStatus
			// 
			this.buttTrayStatus.Enabled = false;
			this.buttTrayStatus.Name = "buttTrayStatus";
			this.buttTrayStatus.Size = new System.Drawing.Size(189, 22);
			this.buttTrayStatus.Text = "Disconnected";
			// 
			// buttTrayConnectDisconnect
			// 
			this.buttTrayConnectDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.buttTrayConnectDisconnect.Name = "buttTrayConnectDisconnect";
			this.buttTrayConnectDisconnect.Size = new System.Drawing.Size(189, 22);
			this.buttTrayConnectDisconnect.Text = "Connect!";
			this.buttTrayConnectDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
			// 
			// buttTrayExit
			// 
			this.buttTrayExit.Name = "buttTrayExit";
			this.buttTrayExit.Size = new System.Drawing.Size(189, 22);
			this.buttTrayExit.Text = "Exit and disconnect";
			this.buttTrayExit.Click += new System.EventHandler(this.boxClose_Click);
			// 
			// borderPanel
			// 
			this.borderPanel.Controls.Add(this.windowPanel);
			this.borderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.borderPanel.Location = new System.Drawing.Point(6, 31);
			this.borderPanel.Margin = new System.Windows.Forms.Padding(0);
			this.borderPanel.Name = "borderPanel";
			this.borderPanel.Size = new System.Drawing.Size(409, 438);
			this.borderPanel.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(421, 475);
			this.Controls.Add(this.borderPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "FloppyVPN";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Controls.SetChildIndex(this.borderPanel, 0);
			this.windowPanel.ResumeLayout(false);
			this.windowPanel.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureConnectionStatus)).EndInit();
			this.windowMenu.ResumeLayout(false);
			this.windowMenu.PerformLayout();
			this.groupConnection.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureCountry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureConnectionIllustration)).EndInit();
			this.groupAccount.ResumeLayout(false);
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.trayMenu.ResumeLayout(false);
			this.borderPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel windowPanel;
		private System.Windows.Forms.ImageList tabsImages;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private System.Windows.Forms.ToolStripMenuItem buttShow;
		private System.Windows.Forms.ToolStripMenuItem buttTrayStatus;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem buttTrayExit;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel labelCurrentIpCaption;
		private System.Windows.Forms.GroupBox groupConnection;
		private System.Windows.Forms.Button buttConnectDisconnect;
		private System.Windows.Forms.PictureBox pictureConnectionIllustration;
		private System.Windows.Forms.Panel borderPanel;
		private System.Windows.Forms.GroupBox groupAccount;
		private System.Windows.Forms.MenuStrip windowMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem buttExit;
		private System.Windows.Forms.ContextMenuStrip trayMenu;
		private System.Windows.Forms.ToolStripMenuItem buttWebsite;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem buttStartup;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureConnectionStatus;
		private System.Windows.Forms.Label labelConnectionStatus;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem buttAddToStartup;
		private System.Windows.Forms.ToolStripMenuItem buttRemoveFromStartup;
		private System.Windows.Forms.ToolStripMenuItem buttStartupStatus;
		private System.Windows.Forms.Button buttLogout;
		private System.Windows.Forms.Button buttRefreshData;
		private System.Windows.Forms.Button buttAddTime;
		private System.Windows.Forms.Label labelAccountStatus;
		private System.Windows.Forms.ToolStripStatusLabel labelCurrentIp;
		private System.Windows.Forms.ToolStripMenuItem buttLanguage;
		private System.Windows.Forms.ToolStripMenuItem buttEN;
		private System.Windows.Forms.ToolStripMenuItem buttRU;
		private System.Windows.Forms.ToolStripMenuItem buttUK;
		private System.Windows.Forms.ToolStripMenuItem buttJA;
		private System.Windows.Forms.ToolStripDropDownButton buttRevealIp;
		private System.Windows.Forms.ToolStripMenuItem buttUpdate;
		private System.Windows.Forms.ToolStripMenuItem buttSplitTunneling;
		private System.Windows.Forms.ComboBox boxServer;
		private System.Windows.Forms.PictureBox pictureCountry;
		private System.Windows.Forms.ToolStripMenuItem stripIPprivate;
		private System.Windows.Forms.ToolStripMenuItem stripIPpublic;
		private System.Windows.Forms.ToolStripMenuItem buttTrayConnectDisconnect;
	}
}


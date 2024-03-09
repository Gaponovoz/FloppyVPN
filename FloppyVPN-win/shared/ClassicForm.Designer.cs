namespace FloppyVPN
{
	partial class ClassicForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassicForm));
			this.contextWindowBox = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.butRestoreWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.buttMinimizeWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.maximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.buttCloseWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.panelBox = new System.Windows.Forms.Panel();
			this.frameRight = new System.Windows.Forms.PictureBox();
			this.frameBottom = new System.Windows.Forms.PictureBox();
			this.frameLeft = new System.Windows.Forms.PictureBox();
			this.windowBar = new System.Windows.Forms.Panel();
			this.labelWindowTitle = new System.Windows.Forms.Label();
			this.picWindowIcon = new System.Windows.Forms.PictureBox();
			this.minimizeBox = new System.Windows.Forms.PictureBox();
			this.maximizeBox = new System.Windows.Forms.PictureBox();
			this.closeBox = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.boxFrameLeft = new System.Windows.Forms.PictureBox();
			this.boxFrameRight = new System.Windows.Forms.PictureBox();
			this.contextWindowBox.SuspendLayout();
			this.panelBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.frameRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.frameBottom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.frameLeft)).BeginInit();
			this.windowBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picWindowIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.minimizeBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maximizeBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.closeBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.boxFrameLeft)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.boxFrameRight)).BeginInit();
			this.SuspendLayout();
			// 
			// contextWindowBox
			// 
			this.contextWindowBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
			this.contextWindowBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.contextWindowBox.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextWindowBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butRestoreWindow,
            this.moveToolStripMenuItem,
            this.buttMinimizeWindow,
            this.maximizeToolStripMenuItem,
            this.toolStripSeparator1,
            this.buttCloseWindow});
			this.contextWindowBox.Name = "contextWindowBox";
			this.contextWindowBox.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.contextWindowBox.Size = new System.Drawing.Size(178, 120);
			// 
			// butRestoreWindow
			// 
			this.butRestoreWindow.Name = "butRestoreWindow";
			this.butRestoreWindow.Size = new System.Drawing.Size(177, 22);
			this.butRestoreWindow.Text = "Restore";
			// 
			// moveToolStripMenuItem
			// 
			this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
			this.moveToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.moveToolStripMenuItem.Text = "Move";
			// 
			// buttMinimizeWindow
			// 
			this.buttMinimizeWindow.Name = "buttMinimizeWindow";
			this.buttMinimizeWindow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F13)));
			this.buttMinimizeWindow.Size = new System.Drawing.Size(177, 22);
			this.buttMinimizeWindow.Text = "Minimize";
			// 
			// maximizeToolStripMenuItem
			// 
			this.maximizeToolStripMenuItem.Enabled = false;
			this.maximizeToolStripMenuItem.Name = "maximizeToolStripMenuItem";
			this.maximizeToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.maximizeToolStripMenuItem.Text = "Maximize";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
			// 
			// buttCloseWindow
			// 
			this.buttCloseWindow.Name = "buttCloseWindow";
			this.buttCloseWindow.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.buttCloseWindow.Size = new System.Drawing.Size(177, 22);
			this.buttCloseWindow.Text = "Close";
			// 
			// panelBox
			// 
			this.panelBox.Controls.Add(this.windowBar);
			this.panelBox.Controls.Add(this.pictureBox1);
			this.panelBox.Controls.Add(this.boxFrameLeft);
			this.panelBox.Controls.Add(this.boxFrameRight);
			this.panelBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelBox.Location = new System.Drawing.Point(0, 0);
			this.panelBox.Name = "panelBox";
			this.panelBox.Size = new System.Drawing.Size(635, 31);
			this.panelBox.TabIndex = 7;
			// 
			// frameRight
			// 
			this.frameRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("frameRight.BackgroundImage")));
			this.frameRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.frameRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.frameRight.Location = new System.Drawing.Point(629, 31);
			this.frameRight.Name = "frameRight";
			this.frameRight.Size = new System.Drawing.Size(6, 414);
			this.frameRight.TabIndex = 10;
			this.frameRight.TabStop = false;
			// 
			// frameBottom
			// 
			this.frameBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("frameBottom.BackgroundImage")));
			this.frameBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.frameBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.frameBottom.Location = new System.Drawing.Point(6, 445);
			this.frameBottom.Name = "frameBottom";
			this.frameBottom.Size = new System.Drawing.Size(629, 6);
			this.frameBottom.TabIndex = 9;
			this.frameBottom.TabStop = false;
			// 
			// frameLeft
			// 
			this.frameLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("frameLeft.BackgroundImage")));
			this.frameLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.frameLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.frameLeft.Location = new System.Drawing.Point(0, 31);
			this.frameLeft.Name = "frameLeft";
			this.frameLeft.Size = new System.Drawing.Size(6, 420);
			this.frameLeft.TabIndex = 8;
			this.frameLeft.TabStop = false;
			// 
			// windowBar
			// 
			this.windowBar.BackgroundImage = global::FloppyVPN.Properties.Resources.bar_active;
			this.windowBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.windowBar.Controls.Add(this.labelWindowTitle);
			this.windowBar.Controls.Add(this.picWindowIcon);
			this.windowBar.Controls.Add(this.minimizeBox);
			this.windowBar.Controls.Add(this.maximizeBox);
			this.windowBar.Controls.Add(this.closeBox);
			this.windowBar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.windowBar.Location = new System.Drawing.Point(6, 6);
			this.windowBar.Name = "windowBar";
			this.windowBar.Padding = new System.Windows.Forms.Padding(2);
			this.windowBar.Size = new System.Drawing.Size(624, 25);
			this.windowBar.TabIndex = 0;
			this.windowBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.windowBox_MouseDown);
			this.windowBar.MouseLeave += new System.EventHandler(this.winowBar_MouseLeave);
			this.windowBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.windowBox_MouseMove);
			this.windowBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.windowBox_MouseUp);
			// 
			// labelWindowTitle
			// 
			this.labelWindowTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelWindowTitle.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelWindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelWindowTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.labelWindowTitle.Location = new System.Drawing.Point(25, 2);
			this.labelWindowTitle.Name = "labelWindowTitle";
			this.labelWindowTitle.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
			this.labelWindowTitle.Size = new System.Drawing.Size(224, 21);
			this.labelWindowTitle.TabIndex = 0;
			this.labelWindowTitle.Text = "FloppyVPN";
			this.labelWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelWindowTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.windowBox_MouseDown);
			this.labelWindowTitle.MouseLeave += new System.EventHandler(this.winowBar_MouseLeave);
			this.labelWindowTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.windowBox_MouseMove);
			this.labelWindowTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.windowBox_MouseUp);
			// 
			// picWindowIcon
			// 
			this.picWindowIcon.BackColor = System.Drawing.Color.Transparent;
			this.picWindowIcon.BackgroundImage = global::FloppyVPN.Properties.Resources.logo;
			this.picWindowIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.picWindowIcon.Dock = System.Windows.Forms.DockStyle.Left;
			this.picWindowIcon.Location = new System.Drawing.Point(2, 2);
			this.picWindowIcon.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
			this.picWindowIcon.Name = "picWindowIcon";
			this.picWindowIcon.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
			this.picWindowIcon.Size = new System.Drawing.Size(23, 21);
			this.picWindowIcon.TabIndex = 4;
			this.picWindowIcon.TabStop = false;
			this.picWindowIcon.Click += new System.EventHandler(this.picWindowIcon_Click);
			this.picWindowIcon.DoubleClick += new System.EventHandler(this.picWindowIcon_DoubleClick);
			// 
			// minimizeBox
			// 
			this.minimizeBox.BackColor = System.Drawing.Color.Transparent;
			this.minimizeBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("minimizeBox.BackgroundImage")));
			this.minimizeBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.minimizeBox.Dock = System.Windows.Forms.DockStyle.Right;
			this.minimizeBox.Location = new System.Drawing.Point(554, 2);
			this.minimizeBox.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
			this.minimizeBox.Name = "minimizeBox";
			this.minimizeBox.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
			this.minimizeBox.Size = new System.Drawing.Size(22, 21);
			this.minimizeBox.TabIndex = 3;
			this.minimizeBox.TabStop = false;
			this.minimizeBox.Click += new System.EventHandler(this.minimizeBox_Click);
			this.minimizeBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.minimizeBox_MouseDown);
			this.minimizeBox.MouseLeave += new System.EventHandler(this.minimizeBox_MouseLeave);
			this.minimizeBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.minimizeBox_MouseUp);
			// 
			// maximizeBox
			// 
			this.maximizeBox.BackColor = System.Drawing.Color.Transparent;
			this.maximizeBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("maximizeBox.BackgroundImage")));
			this.maximizeBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.maximizeBox.Dock = System.Windows.Forms.DockStyle.Right;
			this.maximizeBox.Enabled = false;
			this.maximizeBox.Location = new System.Drawing.Point(576, 2);
			this.maximizeBox.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
			this.maximizeBox.Name = "maximizeBox";
			this.maximizeBox.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
			this.maximizeBox.Size = new System.Drawing.Size(24, 21);
			this.maximizeBox.TabIndex = 2;
			this.maximizeBox.TabStop = false;
			// 
			// closeBox
			// 
			this.closeBox.BackColor = System.Drawing.Color.Transparent;
			this.closeBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeBox.BackgroundImage")));
			this.closeBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.closeBox.Dock = System.Windows.Forms.DockStyle.Right;
			this.closeBox.Location = new System.Drawing.Point(600, 2);
			this.closeBox.Name = "closeBox";
			this.closeBox.Size = new System.Drawing.Size(22, 21);
			this.closeBox.TabIndex = 1;
			this.closeBox.TabStop = false;
			this.closeBox.EnabledChanged += new System.EventHandler(this.closeBox_EnabledChanged);
			this.closeBox.Click += new System.EventHandler(this.closeBox_Click);
			this.closeBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.boxClose_MouseDown);
			this.closeBox.MouseLeave += new System.EventHandler(this.boxClose_MouseLeave);
			this.closeBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.boxClose_MouseUp);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Location = new System.Drawing.Point(6, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(624, 6);
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// boxFrameLeft
			// 
			this.boxFrameLeft.BackColor = System.Drawing.Color.Transparent;
			this.boxFrameLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("boxFrameLeft.BackgroundImage")));
			this.boxFrameLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.boxFrameLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.boxFrameLeft.Location = new System.Drawing.Point(0, 0);
			this.boxFrameLeft.Margin = new System.Windows.Forms.Padding(0);
			this.boxFrameLeft.Name = "boxFrameLeft";
			this.boxFrameLeft.Size = new System.Drawing.Size(6, 31);
			this.boxFrameLeft.TabIndex = 6;
			this.boxFrameLeft.TabStop = false;
			// 
			// boxFrameRight
			// 
			this.boxFrameRight.BackColor = System.Drawing.Color.Transparent;
			this.boxFrameRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("boxFrameRight.BackgroundImage")));
			this.boxFrameRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.boxFrameRight.Dock = System.Windows.Forms.DockStyle.Right;
			this.boxFrameRight.Location = new System.Drawing.Point(630, 0);
			this.boxFrameRight.Margin = new System.Windows.Forms.Padding(0);
			this.boxFrameRight.Name = "boxFrameRight";
			this.boxFrameRight.Size = new System.Drawing.Size(5, 31);
			this.boxFrameRight.TabIndex = 10;
			this.boxFrameRight.TabStop = false;
			// 
			// ClassicForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.ClientSize = new System.Drawing.Size(635, 451);
			this.ControlBox = false;
			this.Controls.Add(this.frameRight);
			this.Controls.Add(this.frameBottom);
			this.Controls.Add(this.frameLeft);
			this.Controls.Add(this.panelBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ClassicForm";
			this.Text = "ClassicForm";
			this.Activated += new System.EventHandler(this.ClassicForm_Activated);
			this.Deactivate += new System.EventHandler(this.ClassicForm_Deactivate);
			this.contextWindowBox.ResumeLayout(false);
			this.panelBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.frameRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.frameBottom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.frameLeft)).EndInit();
			this.windowBar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picWindowIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.minimizeBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maximizeBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.closeBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.boxFrameLeft)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.boxFrameRight)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ContextMenuStrip contextWindowBox;
		private System.Windows.Forms.ToolStripMenuItem butRestoreWindow;
		private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem buttMinimizeWindow;
		private System.Windows.Forms.ToolStripMenuItem maximizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem buttCloseWindow;
		private System.Windows.Forms.Panel panelBox;
		private System.Windows.Forms.Panel windowBar;
		private System.Windows.Forms.Label labelWindowTitle;
		private System.Windows.Forms.PictureBox picWindowIcon;
		private System.Windows.Forms.PictureBox minimizeBox;
		private System.Windows.Forms.PictureBox maximizeBox;
		private System.Windows.Forms.PictureBox closeBox;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox boxFrameLeft;
		private System.Windows.Forms.PictureBox boxFrameRight;
		private System.Windows.Forms.PictureBox frameLeft;
		private System.Windows.Forms.PictureBox frameBottom;
		private System.Windows.Forms.PictureBox frameRight;
	}
}
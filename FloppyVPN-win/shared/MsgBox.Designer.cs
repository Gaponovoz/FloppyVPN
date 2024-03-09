namespace FloppyVPN
{
	partial class MsgBox
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
			this.windowPanel = new System.Windows.Forms.Panel();
			this.buttCancel = new System.Windows.Forms.Button();
			this.buttRetry = new System.Windows.Forms.Button();
			this.buttNo = new System.Windows.Forms.Button();
			this.buttYes = new System.Windows.Forms.Button();
			this.picMsgIcon = new System.Windows.Forms.PictureBox();
			this.labelMessage = new System.Windows.Forms.Label();
			this.buttOK = new System.Windows.Forms.Button();
			this.windowPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picMsgIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// windowPanel
			// 
			this.windowPanel.BackColor = System.Drawing.Color.WhiteSmoke;
			this.windowPanel.Controls.Add(this.buttCancel);
			this.windowPanel.Controls.Add(this.buttRetry);
			this.windowPanel.Controls.Add(this.buttNo);
			this.windowPanel.Controls.Add(this.buttYes);
			this.windowPanel.Controls.Add(this.picMsgIcon);
			this.windowPanel.Controls.Add(this.labelMessage);
			this.windowPanel.Controls.Add(this.buttOK);
			this.windowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.windowPanel.Location = new System.Drawing.Point(6, 31);
			this.windowPanel.Margin = new System.Windows.Forms.Padding(0);
			this.windowPanel.Name = "windowPanel";
			this.windowPanel.Padding = new System.Windows.Forms.Padding(4);
			this.windowPanel.Size = new System.Drawing.Size(417, 167);
			this.windowPanel.TabIndex = 1;
			// 
			// buttCancel
			// 
			this.buttCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttCancel.Location = new System.Drawing.Point(279, 126);
			this.buttCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttCancel.Name = "buttCancel";
			this.buttCancel.Size = new System.Drawing.Size(105, 34);
			this.buttCancel.TabIndex = 7;
			this.buttCancel.Text = "Cancel";
			this.buttCancel.UseVisualStyleBackColor = true;
			this.buttCancel.Visible = false;
			this.buttCancel.Click += new System.EventHandler(this.buttCancel_Click);
			// 
			// buttRetry
			// 
			this.buttRetry.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttRetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttRetry.Location = new System.Drawing.Point(168, 126);
			this.buttRetry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttRetry.Name = "buttRetry";
			this.buttRetry.Size = new System.Drawing.Size(105, 34);
			this.buttRetry.TabIndex = 6;
			this.buttRetry.Text = "Retry";
			this.buttRetry.UseVisualStyleBackColor = true;
			this.buttRetry.Visible = false;
			this.buttRetry.Click += new System.EventHandler(this.buttRetry_Click);
			// 
			// buttNo
			// 
			this.buttNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttNo.Location = new System.Drawing.Point(279, 126);
			this.buttNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttNo.Name = "buttNo";
			this.buttNo.Size = new System.Drawing.Size(105, 34);
			this.buttNo.TabIndex = 5;
			this.buttNo.Text = "No";
			this.buttNo.UseVisualStyleBackColor = true;
			this.buttNo.Visible = false;
			this.buttNo.Click += new System.EventHandler(this.buttNo_Click);
			// 
			// buttYes
			// 
			this.buttYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttYes.Location = new System.Drawing.Point(168, 126);
			this.buttYes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttYes.Name = "buttYes";
			this.buttYes.Size = new System.Drawing.Size(105, 34);
			this.buttYes.TabIndex = 4;
			this.buttYes.Text = "Yes";
			this.buttYes.UseVisualStyleBackColor = true;
			this.buttYes.Visible = false;
			this.buttYes.Click += new System.EventHandler(this.buttYes_Click);
			// 
			// picMsgIcon
			// 
			this.picMsgIcon.BackgroundImage = global::FloppyVPN.Properties.Resources.msg_information_0;
			this.picMsgIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picMsgIcon.Location = new System.Drawing.Point(21, 50);
			this.picMsgIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.picMsgIcon.Name = "picMsgIcon";
			this.picMsgIcon.Size = new System.Drawing.Size(55, 52);
			this.picMsgIcon.TabIndex = 3;
			this.picMsgIcon.TabStop = false;
			// 
			// labelMessage
			// 
			this.labelMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMessage.Location = new System.Drawing.Point(97, 50);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(287, 65);
			this.labelMessage.TabIndex = 2;
			this.labelMessage.Text = "labelMessage";
			this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// buttOK
			// 
			this.buttOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttOK.Location = new System.Drawing.Point(144, 126);
			this.buttOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttOK.Name = "buttOK";
			this.buttOK.Size = new System.Drawing.Size(105, 34);
			this.buttOK.TabIndex = 1;
			this.buttOK.Text = "OK";
			this.buttOK.UseVisualStyleBackColor = true;
			this.buttOK.Visible = false;
			this.buttOK.Click += new System.EventHandler(this.buttOK_Click);
			// 
			// MsgBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 204);
			this.Controls.Add(this.windowPanel);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MsgBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MsgBox";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MsgBox_FormClosing);
			this.Controls.SetChildIndex(this.windowPanel, 0);
			this.windowPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picMsgIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel windowPanel;
		private System.Windows.Forms.Button buttOK;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.Button buttNo;
		private System.Windows.Forms.Button buttYes;
		private System.Windows.Forms.PictureBox picMsgIcon;
		private System.Windows.Forms.Button buttCancel;
		private System.Windows.Forms.Button buttRetry;
	}
}
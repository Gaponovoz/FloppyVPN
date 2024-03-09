using FloppyVPN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloppyVPN
{
	public partial class MainForm : ClassicForm
	{
		public MainForm(bool connectAfterLaunch)
		{
			Application.ThreadException += new ThreadExceptionEventHandler(Shared.Exception);

			//try logging in silently from saved data. if not  -prompt user for login
			Account.LogIn();
			Task.Delay(100).GetAwaiter().GetResult();
			if (!Account.loggedIn)
				LogIn();

			InitializeComponent();
			ApplyLocalizedTexts();

			if (connectAfterLaunch)
			{
				Trayify(true);
				Connect();
			}
		}

		void Trayify(bool hideIsTrue_showIsFalse)
		{
			if (hideIsTrue_showIsFalse)
			{
				this.Hide();
				trayIcon.Visible = true;
				this.ShowInTaskbar = false;
			}
			else
			{
				this.Show();
				trayIcon.Visible = false;
				this.ShowInTaskbar = true;
			}
		}

		private void ApplyLocalizedTexts()
		{

			if (Vpn.connected)
				labelConnectionStatus.Text = Loc.statusConnected;
			else
				labelConnectionStatus.Text = Loc.statusNotConnected;

			buttRefreshData_Click();

			if (File.Exists(PathsAndLinks.startupShortcutPath))
				buttStartupStatus.Text = Loc.startupStatusAdded;
			else
				buttStartupStatus.Text = Loc.startupStatusNotAdded;

			fileToolStripMenuItem.Text = Loc.fileMenu;
			optionsToolStripMenuItem.Text = Loc.optionsMenu;
			helpToolStripMenuItem.Text = Loc.helpMenu;
			buttWebsite.Text = Loc.websiteButton;
			buttExit.Text = Loc.exitButton;
			groupConnection.Text = Loc.connectionGroup;
			groupAccount.Text = Loc.accountGroup;
			buttAddTime.Text = Loc.addTimeButton;
			buttStartup.Text = Loc.startupButton;
			buttLanguage.Text = Loc.languageButton;
			buttRefreshData.Text = Loc.refreshbutton;
			labelCurrentIpCaption.Text = Loc.currentIP;
			buttAddToStartup.Text = Loc.addToStartup;
			buttRemoveFromStartup.Text = Loc.removeFromStartup;
			buttUpdate.Text = Loc.updateButton;
			buttLogout.Text = Loc.logoutButton;
			buttRevealIp.Text = Loc.revealIP;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult dialogResult = DialogResult.Yes;

			if (Vpn.connected)
				dialogResult = new MsgBox("Really close VPN?", "a captiooon? wtf?", MessageBoxIcon.Question, MessageBoxButtons.YesNo).ShowDialog();

			if (dialogResult == DialogResult.Yes)
			{
				DisconnectAndQuit();
			}
			else
			{
				e.Cancel = true;
			}
		}

		private void boxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		void DisconnectAndQuit(object sender = null, EventArgs e = null)
		{
			try
			{
				trayIcon.Visible = false;
				Disconnect();
			}
			catch
			{
			}

			Environment.Exit(0);
		}

		private void buttShow_Click(object sender, EventArgs e)
		{

		}

		private void trayIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				trayMenu.Show(Cursor.Position);
			}
			else if (e.Button == MouseButtons.Left)
			{
				Show();
				ShowInTaskbar = true;
				trayIcon.Visible = false;
				new SoundPlayer(Resources.chimes).Play();
			}
		}

		private void buttConnectDisconnect_Click(object sender, EventArgs e)
		{
			if (Vpn.connected)
				Disconnect();
			else
				Connect();

			buttRefreshData_Click();
		}

		private void Connect()
		{
			try
			{
				Vpn.Connect();
				Vpn.connected = true;
				buttConnectDisconnect.Text = Loc.disconnect;
				buttConnectDisconnect.Image = Resources.connected;
				labelConnectionStatus.Text = Loc.statusConnected;
				pictureConnectionStatus.BackgroundImage = Resources.connected;
				pictureConnectionIllustration.BackgroundImage = Resources.connection;

				buttTrayConnectDisconnect.Text = Loc.disconnect;
			}
			catch (Exception ex)
			{
				new MsgBox(ex.Message, "FloppyVPN", MessageBoxIcon.Error, MessageBoxButtons.RetryCancel).ShowDialog();
			}
		}

		private void Disconnect()
		{
			Vpn.Disconnect();
			Vpn.connected = false;
			buttConnectDisconnect.Text = Loc.connect;
			buttConnectDisconnect.Image = Resources.disconnected;
			labelConnectionStatus.Text = Loc.statusNotConnected;
			pictureConnectionStatus.BackgroundImage = Resources.disconnected;
			pictureConnectionIllustration.BackgroundImage = Resources.no_connection;

			buttTrayConnectDisconnect.Text = Loc.connect;
		}

		private void buttLanguage_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem == buttEN)
				Loc.lang = "en";
			else if (e.ClickedItem == buttRU)
				Loc.lang = "ru";
			else if (e.ClickedItem == buttUK)
				Loc.lang = "uk";
			else if (e.ClickedItem == buttJA)
				Loc.lang = "ja";

			IniFile.SetValue("lang", Loc.lang);

			Loc.Alize();
			ApplyLocalizedTexts();
		}

		private void LogIn()
		{
			try
			{
				this.Hide();
				this.ShowInTaskbar = false;
			}
			catch
			{
			}

			DialogResult logined = new LoginForm().ShowDialog();
			if (logined == DialogResult.Yes)
			{
				// buttRefreshData_Click();
			}
			else
			{
				DisconnectAndQuit();
			}

			try
			{

			}
			catch
			{
			}
		}

		private void LogOut()
		{
			Disconnect();
			Account.LogOut();
			Task.Delay(1000);
			LogIn();
		}

		private void buttLoginLogout_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = new MsgBox(Loc.logoutPrompt, "FloppyVPN", MessageBoxIcon.Question, MessageBoxButtons.YesNo).ShowDialog();
			if (dialogResult == DialogResult.Yes)
				LogOut();
		}

		private void buttUpdate_Click(object sender, EventArgs e)
		{

		}

		private void buttWebsite_Click(object sender, EventArgs e)
		{

		}

		private void buttRefreshData_Click(object sender = null, EventArgs e = null)
		{
			labelAccountStatus.Text = $"Login: {Account.maskedlogin}\nPaid till: {Account.paidtill}\nDays left: {Account.daysleft}";

			labelCurrentIp.Text = "";
			stripIPpublic.Text = Loc.publicIP + "";
			stripIPprivate.Text = Loc.privateIP + "";
		}

		private void buttAddTime_Click(object sender, EventArgs e)
		{
			Shared.LaunchWebsite(PathsAndLinks.masterServerURL + "/login/" + Account.login);
		}
	}
}
using FloppyVPN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloppyVPN
{
	public partial class LoginForm : ClassicForm
	{
		public LoginForm()
		{
			InitializeComponent();
			LocalizeInterface();
			this.DialogResult = DialogResult.No;

			string cachedlogin = IniFile.GetValue("login") ?? "";
			if (cachedlogin != "")
			{
				txtLogin.Text = cachedlogin;
				buttLogin.PerformClick();
			}
		}

		private void LocalizeInterface()
		{
			fileToolStripMenuItem.Text = Loc.fileMenu;
			buttCloseLoginForm.Text = Loc.close;
			buttRegister.Text = Loc.register;
			labelLoginEntering.Text = Loc.loginCaption;
			buttLogin.Text = Loc.loginButton;
			groupLogin.Text = Loc.loginGroup;
		}

		private void buttRegister_Click(object sender, EventArgs e)
		{
			Shared.LaunchWebsite($"{PathsAndLinks.masterServerURL}/register");
		}

		private void buttLoginLogout_Click(object sender, EventArgs e)
		{
			bool successFullyLoggedIn = Account.LogIn(txtLogin.Text);
			if (successFullyLoggedIn)
			{
				this.DialogResult = DialogResult.Yes;
				this.Close();
			}
			else
			{
				this.DialogResult = DialogResult.Yes;
				new MsgBox(Loc.unableToLogInText, Loc.unableToLoginCaption, MessageBoxIcon.Error).ShowDialog();
			}
		}

		private void boxClose_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

using FloppyVPN.Properties;
using System.Drawing;
using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloppyVPN
{
	public partial class MsgBox : ClassicForm
	{
		bool userCanCloseMsgBox = true;

		public MsgBox(string message, string caption = "FloppyVPN", MessageBoxIcon msgicon = MessageBoxIcon.Information, MessageBoxButtons msgbuttons = MessageBoxButtons.OK)
		{
			InitializeComponent();
			Task.Delay(100).GetAwaiter().GetResult();


			//set up texts:
			labelMessage.Text = message;
			SetWindowTitle(caption);


			//set up icon:
			if (msgicon == MessageBoxIcon.Error)
				picMsgIcon.BackgroundImage = Resources.msg_warning_0;
			else if (msgicon == MessageBoxIcon.Question)
				picMsgIcon.BackgroundImage = Resources.msg_question_0;
			else //"Information"
				picMsgIcon.Image = Resources.msg_information_0;


			//set up buttons:
			if (msgbuttons == MessageBoxButtons.YesNo)
			{
				this.DialogResult = DialogResult.No;
				buttYes.Visible = true;
				buttNo.Visible = true;
				buttYes.Focus();
			}
			else if (msgbuttons == MessageBoxButtons.RetryCancel)
			{
				this.DialogResult = DialogResult.Cancel;
				// DisableCloseBox();
				buttRetry.Visible = true;
				buttCancel.Visible = true;
				buttRetry.Focus();
			}
			else //"OK"
			{
				buttOK.Visible = true;
				buttOK.Focus();
			}

			this.Text = caption;

			HideMaximizeBox();
		}

		private void boxClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void LocalizeInterface()
		{

		}

		private void MsgBox_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			if (userCanCloseMsgBox)
			{
				e.Cancel = false;
			}
			else
			{
				new SoundPlayer(Resources.chimes).Play();
			}
		}

		private void buttYes_Click(object sender, EventArgs e)
		{
			userCanCloseMsgBox = true;
			this.DialogResult = DialogResult.Yes;
			Close();
		}

		private void buttNo_Click(object sender, EventArgs e)
		{
			userCanCloseMsgBox = true;
			this.DialogResult = DialogResult.No;
			Close();
		}

		private void buttOK_Click(object sender, EventArgs e)
		{
			userCanCloseMsgBox = true;
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void buttRetry_Click(object sender, EventArgs e)
		{
			userCanCloseMsgBox = true;
			this.DialogResult = DialogResult.Retry;
			Close();
		}

		private void buttCancel_Click(object sender, EventArgs e)
		{
			userCanCloseMsgBox = true;
			this.DialogResult = DialogResult.Cancel;
			Close();
		}


	}
}

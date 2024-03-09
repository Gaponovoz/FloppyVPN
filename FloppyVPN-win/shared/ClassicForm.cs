using FloppyVPN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloppyVPN
{
	public partial class ClassicForm : Form
	{
		public ClassicForm()
		{
			InitializeComponent();
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		private const int WM_NCLBUTTONDOWN = 0xA1;
		private const int HT_CAPTION = 0x2;
		private const string V = "";
		private bool isDragging = false;
		private Point lastCursor;
		private Point lastForm;

		public void SetWindowTitle(string newTitle)
		{
			labelWindowTitle.Text = newTitle;
		}

		public void DisableCloseBox()
		{
			closeBox.Enabled = false;
		}

		public void EnableCloseBox()
		{
			closeBox.Enabled = true;
		}

		public void HideMinimizeBox()
		{
			minimizeBox.Visible = false;
		}

		public void HideMaximizeBox()
		{
			maximizeBox.Visible = false;
		}

		private void windowBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}
		private void windowBox_MouseMove(object sender, MouseEventArgs e)
		{
			if (isDragging)
			{
				Point difference = Point.Subtract(Cursor.Position, new Size(lastCursor));
				this.Location = Point.Add(lastForm, new Size(difference));
			}
		}
		private void windowBox_MouseUp(object sender, MouseEventArgs e)
		{
			isDragging = false;
		}
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ClassStyle |= 0x20000; // CS_DROPSHADOW
				return cp;
			}
		}
		private void boxClose_MouseDown(object sender, MouseEventArgs e)
		{
			closeBox.BackgroundImage = Resources.close_down;
		}
		private void boxClose_MouseLeave(object sender, EventArgs e)
		{
			closeBox.BackgroundImage = Resources.close_normal;
		}
		private void boxClose_MouseUp(object sender, MouseEventArgs e)
		{
			closeBox.BackgroundImage = Resources.close_normal;
		}

		private void minimizeBox_MouseDown(object sender, MouseEventArgs e)
		{
			minimizeBox.BackgroundImage = Resources.minimize_down;
		}

		private void minimizeBox_MouseLeave(object sender, EventArgs e)
		{
			minimizeBox.BackgroundImage = Resources.minimize_normal;
		}

		private void minimizeBox_MouseUp(object sender, MouseEventArgs e)
		{
			minimizeBox.BackgroundImage = Resources.minimize_normal;
		}

		private void closeBox_Click(object sender, EventArgs e)
		{
			closeBox.BackgroundImage = Resources.close_down;
			this.Close();
		}

		private void minimizeBox_Click(object sender, EventArgs e)
		{
			minimizeBox.BackgroundImage = Resources.minimize_down;
			this.WindowState = FormWindowState.Minimized;
			minimizeBox.BackgroundImage = Resources.minimize_normal;
		}

		private void winowBar_MouseLeave(object sender, EventArgs e)
		{
			this.isDragging = false;
		}

		private void picWindowIcon_DoubleClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void picWindowIcon_Click(object sender, EventArgs e)
		{
			contextWindowBox.Show(this.Location + new Size(2, 8 + picWindowIcon.Height));
		}

		private void ClassicForm_Deactivate(object sender, EventArgs e)
		{
			windowBar.BackgroundImage = Resources.bar_inactive;
		}

		private void ClassicForm_Activated(object sender, EventArgs e)
		{
			windowBar.BackgroundImage = Resources.bar_active;
		}

		private void closeBox_EnabledChanged(object sender, EventArgs e)
		{
			if (closeBox.Enabled)
				closeBox.BackgroundImage = Resources.close_normal;
			else
				closeBox.BackgroundImage = Resources.close_disabled;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloppyVPN
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			//use custom exception handler:
			Application.ThreadException += new ThreadExceptionEventHandler(Shared.Exception);

			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new UninstallForm());
		}
	}
}

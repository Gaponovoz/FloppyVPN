﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net.Http;
using FloppyVPN.Properties;

namespace FloppyVPN
{
	public partial class InstallForm : ClassicForm
	{
		int currentPage = 1;

		public InstallForm()
		{
			InitializeComponent();
		}

		void Form1_Load(object sender, EventArgs e)
		{
			Text = Loc.window_title();
			this.SetWindowTitle(Loc.window_title());
			greetingLabel.Text = Loc.greeting_main();
			greetingSub.Text = Loc.greeting_sub();
			buttonBack.Text = Loc.back();
			buttonCancel.Text = Loc.cancel();
			buttonNext.Text = Loc.next();
			centertext2.Text = Loc.press_next_to_choose_folser();
			checkboxDesktopShortcut.Text = Loc.create_desktop_shortcut();
			checkboxMenuShortcut.Text = Loc.create_menu_shortcut();
			launchcheckbox.Text = Loc.launch_program_box();
			uppersettingoption_SetLink();
		}

		void uppersettingoption_SetLink()
		{

		}

		void LoadPage(int pageNumberToLoad)
		{
			Task.Delay(228).GetAwaiter().GetResult();

			if (pageNumberToLoad == 1) //greetings
			{
				panelUp.Visible = false;
				buttonBack.Visible = false;
				pictureBox1.Visible = true;
				installlocationtext.Visible = false;
				buttonbrowse.Visible = false;
				miniicon.Visible = false;
				greetingLabel.Visible = true;
				greetingSub.Visible = true;
				centertext1.Visible = false;
				centertext2.Visible = false;
			}
			else if (pageNumberToLoad == 2) //folder choosement
			{
				panelUp.Visible = true;
				buttonBack.Visible = true;
				pictureBox1.Visible = false;
				installlocationtext.Text = Program.installfolder;
				installlocationtext.Visible = true;
				buttonbrowse.Visible = true;
				miniicon.Image = Resources.folder_pencil;
				miniicon.Visible = true;
				greetingLabel.Visible = false;
				greetingSub.Visible = false;
				centertext1.Visible = true;
				centertext2.Visible = true;
				centertext1.Text = Loc.program_will_be_installed_to1();
				uppertext1.Text = Loc.uppertext1_1();
				uppertext2.Text = Loc.uppertext2_1();
				Program.installfolder = installlocationtext.Text;
				checkboxDesktopShortcut.Visible = false;
				checkboxMenuShortcut.Visible = false;
			}
			else if (pageNumberToLoad == 3) //additional tasks
			{
				installlocationtext.Visible = false;
				buttonbrowse.Visible = false;
				checkboxDesktopShortcut.Visible = true;
				checkboxMenuShortcut.Visible = true;
				centertext1.Visible = false;
				centertext2.Visible = false;
				centertext3.Visible = true;
				centertext3.Text = Loc.additional_tasks();
				miniicon.Visible = false;
				uppertext1.Text = Loc.uppertext1_3();
				uppertext2.Text = Loc.uppertext2_3();
				buttonNext.Text = Loc.next();
			}
			else if (pageNumberToLoad == 4) //digest and confirmation
			{
				checkboxDesktopShortcut.Visible = false;
				checkboxMenuShortcut.Visible = false;
				buttonNext.Text = Loc.install();
				buttonBack.Enabled = false;
				digestrichbox.Text = Loc.ready_digest();
				centertext2.Visible = false;
				uppertext1.Text = Loc.uppertext1_4();
				uppertext2.Text = Loc.uppertext2_4();
				digestrichbox.Visible = true;
			}
			else if (pageNumberToLoad == 5) //process
			{
				Install();
				buttonCancel.Enabled = false;
				buttonNext.Enabled = false;
				progressBar1.Visible = true;
				digestrichbox.Visible = false;
				uppertext1.Text = Loc.uppertext1_6();
				uppertext2.Text = Loc.uppertext2_6();
				progressBar1.Visible = true;
			}
			else if (pageNumberToLoad == 6) //finish
			{
				greetingLabel.Text = Loc.goodbye_main();
				greetingSub.Text = Loc.goodbye_sub();
				greetingLabel.Visible = true;
				greetingSub.Visible = true;
				buttonNext.Enabled = true;
				progressBar1.Visible = false;
				buttonNext.Click += buttonCancel_Click;
				panelUp.Visible = false;
				pictureBox1.Visible = true;
				buttonBack.Visible = false;
				buttonCancel.Visible = false;
				buttonNext.Text = Loc.finish();
				launchcheckbox.Visible = true;
			}
			else
			{
				return;
			}

			currentPage = pageNumberToLoad;
		}

		void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;

			if (currentPage >= 6)
			{
				if (launchcheckbox.Checked == true)
				{
					var launchafterinstallation = new Process
					{
						StartInfo =
						{
							FileName = Program.pathtoinstalledexe,
							WorkingDirectory = Program.installfolder
						}
					};
					try
					{
						launchafterinstallation.Start();
					}
					catch (Exception)
					{
					}
				}
			}
			else
			{
				DialogResult dialogresult = new MsgBox(Loc.quit_dialog(), Loc.window_title(), MessageBoxIcon.Question, MessageBoxButtons.YesNo).ShowDialog();
				if (dialogresult != DialogResult.Yes)
					return;
			}
			Environment.Exit(0);
		}

		void buttonBack_Click(object sender, EventArgs e)
		{
			LoadPage(currentPage - 1);
		}

		void buttonNext_Click(object sender, EventArgs e)
		{
			LoadPage(currentPage + 1);
		}

		void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		void buttonbrowse_Click(object sender, EventArgs e)
		{
			if (currentPage == 2)
			{
				using (var dialog = new FolderBrowserDialog())
				{
					DialogResult result = dialog.ShowDialog();
					if (result == DialogResult.OK)
					{
						Program.installfolder = Path.Combine(dialog.SelectedPath, "FloppyVPN");
					}
				}
				installlocationtext.Text = Program.installfolder;
			}
			else
			{

			}
		}

		async void Install()
		{
			//first, clear old files:
			try
			{
				DirectoryInfo di = new DirectoryInfo(Program.installfolder);
				foreach (FileInfo file in di.GetFiles())
				{
					try { file.Delete(); } catch { }
				}
				foreach (DirectoryInfo dir in di.GetDirectories())
				{
					try { dir.Delete(true); } catch { }
				}

				try { File.Delete(Program.tempfile); } catch { }
			}
			catch
			{
			}
			await Task.Delay(500);

			Directory.CreateDirectory(Program.installfolder);

			progressBar1.Value = 20;

			Program.pathtoinstalledexe = Path.Combine(Program.installfolder, "FloppyVPN Client.exe");

			//download the archive containing the latest version files:
			progressBar1.Value = 40;
			uppersettingoption.Text = Loc.installing2();
			await Task.Run(() =>
			{
				retry:
				try
				{
					using (var client = new HttpClient() { Timeout = TimeSpan.FromMinutes(20) } )
					{
						using (var response = client.GetAsync(Program.linkToDistro).Result)
						{
							using (var fileStream = new FileStream(Program.tempfile, FileMode.Create))
							{
								response.EnsureSuccessStatusCode();
								var contentStream = response.Content.ReadAsStreamAsync().Result;
								contentStream.CopyTo(fileStream);
							}
						}
					}
				}
				catch
				{
					DialogResult dialogResult = MessageBox.Show(Loc.no_internet_error(), Loc.window_title(), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					if (dialogResult == DialogResult.Yes)
					{
						Task.Delay(1500).GetAwaiter().GetResult();
						goto retry;
					}
					else
					{
						Environment.Exit(0);
					}
				}
			});


			//unpack the program archive into the temp folder:
			progressBar1.Value = 70;
			uppersettingoption.Text = Loc.installing3();
			await Task.Run(() =>
			{
				try
				{
					ZipFile.ExtractToDirectory(Program.tempfile, Program.installfolder);
				}
				catch (Exception ex)
				{
					new MsgBox("Failed to unpack the archive: " + ex.Message, Loc.window_title()).ShowDialog();
				}
			});


			progressBar1.Value = 92;
			await Task.Run(() =>
			{
				//write registry install info:
				string uninstallPath = Path.Combine(Program.installfolder, "uninstall.exe");
				try
				{
					using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall", true))
					{
						using (RegistryKey subkey = key.CreateSubKey(Program.programname))
						{
							subkey.SetValue("UninstallString", uninstallPath);
							subkey.SetValue("DisplayName", Program.programname);
							subkey.SetValue("Publisher", Program.publishername);
						}
					}
				}
				catch
				{
				}

				// Desktop shortcut creation:
				if (checkboxDesktopShortcut.Checked)
				{
					try
					{
						ShortcutMaker.Create(Program.pathtoinstalledexe, PathsAndLinks.desktopShortcutPath, Loc.shortcut_description());
					}
					catch (Exception ex)
					{
					}
				}

				// Start shortcut creation:
				if (checkboxMenuShortcut.Checked)
				{
					try
					{
						ShortcutMaker.Create(Program.pathtoinstalledexe, PathsAndLinks.menuShortcutPath, Loc.shortcut_description());
					}
					catch (Exception ex)
					{
					}
				}


				//clear temp files:
				try { File.Delete(Program.tempfile); } catch { }
			});

			LoadPage(currentPage + 1);
		}

	}

}

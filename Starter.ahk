#SingleInstance ignore
#NoTrayIcon

	If FileExist(A_AppData "\OpenVPN\bin\openvpn.exe") || FileExist(ProgramFiles "\OpenVPN\bin\openvpn.exe") || FileExist(A_ProgramFiles "\OpenVPN\bin\openvpn.exe") || FileExist("C:\Program FIles (x86)\OpenVPN\bin\openvpn.exe") || FileExist("C:\Program FIles\OpenVPN\bin\openvpn.exe")
	{
		Goto, Zalupa
	}
	else
	{
		UrlDownloadToFile, https://github.com/Gaponovoz/FloppyVPN/releases/latest/download/OpenVPNDriver.bin, OpenVPNDriver.exe
		Sleep 100
		RunWait, OpenVPNDriver.exe
		Sleep 100
		Goto, Zalupa
	}


Zalupa:
Sleep 70
FileCreateDir, %A_AppDataCommon%\Temp
FileCopy, floppyvpn.ovpn, %A_AppDataCommon%\Temp\floppyvpn.ovpn, 1
Run, Connect.exe
ExitApp
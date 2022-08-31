#NoTrayIcon
#SingleInstance ignore

UrlDownloadToFile, https://github.com/Gaponovoz/FloppyVPN/releases/latest/download/FloppyVPN.exe, FloppyVPN.exe
Sleep 100
FileMove, FloppyVPN.exe, %A_Startup%, 1

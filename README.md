# FloppyVPN
### The full-strack and cross-platform VPN company software. 100% open source.

## Download
 Please use the official website to register, download and use FloppyVPN - http://floppy.jp.net. If you want to compile it yourself or learn more about the project - continue reading.

## Stack
- Servers: C# (ASP.NET Core 6)
- Website: C#; HTML, CSS, JS (ASP.NET Core 6 MVC)
- Database: MySQL
- Windows App & Installer: C# (WinForms)
- Android App: 

## Compiling


## Project logic

Wireguard protocol and related software is taken as the basis of FloppyVPN. It is simple, fast and safe. All the apps use it.

VPN servers use 80 and 443 ports (instead of, say, standard Wireguard 51820) to serve VPN because in some companies and other restricted networks you simply could not connect to a web resource on any port except 80 and 443. Also, connections to these ports look a bit more legit.

Servers (master one and VPN ones) use an authorization key (called "master_key") to communicate with each other via API. Without a same key on both servers no communication is possible. The key is an alphanumeric string of any length (recommended length - from 16 to 64), is also used to perform administrative actions.

User's login actually costists of two parts – “public” and “private”. All the symbols before ‘x‘ (letter X in the middle of the login) are considered as a public part, and the sybmols after are private. You can only authorize devices and use VPN knowing full login while you can still top up the balance without knowing the private part.

Provisioning of configs (unique connection strings) on severs are on behalf of the orchestrator server; The reason of such logic lies in instability of VPN servers - they may be deleted unexpectedly.

Expanding a new VPN server on a new linux machine is easy. During install, just some certain parameters should be entered in the config file and the server is ready to accept new clients and create new configs.


## Deploying
How to fully deploy the app.

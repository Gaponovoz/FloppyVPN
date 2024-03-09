namespace FloppyVPN
{
    internal static class Program
    {
        static void Main()
        {
			//single instance:
			Mutex mutex = new(true, "floppyvpn_vpn_L2Neli82o5I8P1hsqVtOHoq67htydhythtdeyj8AuWYE", out bool result);
			if (!result)
			{
				Console.WriteLine("The same server is already running so it won't start again.");
				Environment.Exit(0);
			}
			GC.KeepAlive(mutex);




			new Thread(() => Listener.Start()).Start();
        }
    }
}
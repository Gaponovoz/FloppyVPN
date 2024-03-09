namespace FloppyVPN
{
    internal static class Program
    {
        static void Main()
        {




            new Thread(() => Listener.Start()).Start();
        }
    }
}
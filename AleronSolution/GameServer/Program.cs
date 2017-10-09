using System;

namespace BrutalHack.Aleron.GameServer
{
    internal static class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Standalone Gameserver!");
            GameServerApplication gameServerApplication = new GameServerApplication();
            while (true)
            {
                gameServerApplication.Update(0.3f);
                System.Threading.Thread.Sleep(30);
            }
        }
    }
}
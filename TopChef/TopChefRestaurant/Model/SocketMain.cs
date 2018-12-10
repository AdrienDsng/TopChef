using System;
using Server.Networking;

namespace Model
{
    public static class SocketMain
    {
        public static ServerSocket ServerSocket = new ServerSocket();

        private static void Main()
        {
            ServerSocket.Bind(6556);
            ServerSocket.Listen(500);
            ServerSocket.Accept();

            while (true)
                Console.ReadLine();
        }
    }
}

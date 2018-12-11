using System;
using System.Net.Sockets;

namespace TopChefRestaurant.Model
{
    public static class PacketHandler
    {
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            var packetLenght = BitConverter.ToInt16(packet, 0);
            var packetType = BitConverter.ToInt16(packet, 2);

            Console.WriteLine("packet received! Length: {0}  | type {1} ", packet.Length);
        }
    }
}

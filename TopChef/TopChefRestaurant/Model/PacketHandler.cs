using System;

namespace Model
{
    public static class PacketHandler
    {
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            ushort packetLenght = BitConverter.ToInt16(packet, 0);
            ushort packetType = BitConverter.ToInt16(packet, 2);

            Console.WriteLine("packet received! Length: {0}  | type {1} ", packet.Length);
        }
    }
}

using System;
using System.Net;
using System.Net.Sockets;

namespace Model
{
    public class ClientSocket
    {
        private Socket _socket;
        private byte[] _buffer;

        public ClientSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Connect(string ipAddress, int port)
        {
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectCallBack, null);
            _socket.EndConnect(result);
        }
        private void ConnectCallBack(IAsyncResult result)
        {
            Console.WriteLine("Connect to restaurant");
            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallBack, null);

            #region Initial Packet

            byte[] packet = new byte[4];
            byte[] packetLength = BitConverter.GetBytes((ushort)packet.Length);
            byte[] packetType = BitConverter.GetBytes((ushort)1000);
            Array.Copy(packetLength, packet, 2);
            Array.Copy(packetType, 0, packet, 2, 2);
            _socket.Send(packet);

            #endregion
        }
        private void ReceivedCallBack(IAsyncResult result)
        {
            int bufLength = _socket.EndReceive(result);
            byte[] packet = new byte[bufLength];
            Array.Copy(_buffer, packet, packet.Length);

            //handle packet

            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallBack, null);
        }
    }
} 
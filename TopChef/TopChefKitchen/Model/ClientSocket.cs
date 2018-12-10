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
            Console.WriteLine("Connext to restaurant");
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallBack, null);
        }
        private void ReceivedCallBack(IAsyncResult result);
    }
}
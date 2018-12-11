using System;
using System.Net;
using System.Net.Sockets;

namespace TopChefRestaurant.Model

{
    public class ServerSocket
    {
        private Socket _socket;
        private byte[] _buffer = new byte[1024];

        public ServerSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Bind(int port)
        { //IPadress equals localhost
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
        }
        public void Listen(int backlog)
        {   //Maximum socket
            _socket.Listen(500);
        }
        public void Accept()
        {
            _socket.BeginAccept(AcceptedCallBack, null);
        }
        private void AcceptedCallBack(IAsyncResult result)
        {
           Socket clientSocket = _socket.EndAccept(result);
           _buffer = new byte[1024];
           clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallBack, clientSocket);
           Accept();     
        }

        private void ReceivedCallBack(IAsyncResult result)
        {
            Socket clientSocket = result.AsyncState as Socket;
            SocketError SE;
            int bufferSize = clientSocket.EndReceive(result, out SE);
            if (SE != SocketError.Success);
            byte[] packet = new byte[bufferSize];
            Array.Copy(_buffer, packet, packet.Length);

            //handle the packet

            PacketHandler.Handle(packet, clientSocket);

            _buffer = new byte[1024];
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallBack, clientSocket);
        }
    } 
}




/*public class Socket
{
	private static Socket(string IP, int Port)
	{
        byte[] mgs = Encoding.UTF8.GetBytes("Test");

        //Data buffer for incoming data
        byte[] received = new byte[1024];
        //all connexion allowed
        permission = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "", SocketPermission.AllPorts);

        //add local endpoint 
        //host running application
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ipAdress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress, 11000);

        //Create socket
        Socket listener = new Socket(ipAdress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        //Bind socket to the local endpoint
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            //beggining connections
            while (true)
            {
                Console.WriteLine("En attente de connexion...");
                //while no response app break
                Socket handler = listener.Accept();
                data = null;
            }

            hanlder.Shutdown(SocketShutdown.Both);
            handler.Close();

        } catch (Exception e)

        {
            Console.WriteLine(e.ToString)();
        }

        Console.WriteLine("\nAppuyé sur entrer pour continuer...");
        Console.Read();
	}
 
}*/

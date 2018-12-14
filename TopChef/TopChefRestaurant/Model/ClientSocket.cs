using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Common
{
    public static class Communicator
    {
        private static ManualResetEvent ready = new ManualResetEvent(false);

        private static ManualResetEvent locker = new ManualResetEvent(true);

        private static Socket listen = null;

        private static Socket socket = null;

        public static void Start(int port)
        {
            listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            listen.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), port));

            listen.Listen(256);

            new Thread(() =>
            {
                for (;;)
                {
                    try
                    {
                        Socket temp = listen.Accept();
                        
                        if (socket == null)
                        {
                            socket = temp;
                        }

                        break;
                    }
                    catch (Exception)
                    {
                        if (socket != null)
                        {
                            break;
                        }
                    }
                }

                Connected();

            }).Start();
        }

        public static bool Connect(string address, int port)
        {
            try
            {
                if (socket != null)
                {
                    return false;
                }

                Socket temp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                temp.Connect(new IPEndPoint(IPAddress.Parse(address), port));
                
                if (socket != null)
                {
                    return false;
                }

                socket = temp;

                Connected();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void Connected()
        {
            listen.Close();

            ready.Set();
        }

        public static void Ready()
        {
            ready.WaitOne();
        }

        public static void SendMessage(string message)
        {
            SendBinary(Encoding.ASCII.GetBytes(message));
        }

        public static string ReceiveMessage()
        {
            Byte[] message = ReceiveBinary();

            return Encoding.ASCII.GetString(message, 0, message.Length);
        }

        public static bool SendObject(Serialized serialized)
        {
            try
            {
                SendMessage(serialized.Name + "|" + serialized.Data);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Serialized ReceiveObject()
        {
            try
            {
                string[] tokens = ReceiveMessage().Split(new char[]{'|'}, 2);

                if (tokens.Length != 2)
                {
                    return null;
                }

                return new Serialized(tokens[0], tokens[1]);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static void SendBinary(Byte[] message)
        {
            lock (socket)
            {
                Byte[] header = Encoding.ASCII.GetBytes(message.Length.ToString() + "|");

                Byte[] total = new Byte[message.Length + header.Length];

                header.CopyTo(total, 0);
                message.CopyTo(total, header.Length);

                socket.Send(total, total.Length, SocketFlags.None);
            }
        }

        private static Byte[] ReceiveBinary()
        {
            lock (socket)
            {
                int size = ReceiveSize();

                Byte[] buffer = new Byte[256];

                List<Byte> message = new List<Byte>();

                int i = 0;

                do
                {
                    Byte[] temp = new Byte[socket.Receive(buffer, buffer.Length, SocketFlags.None)];

                    Array.Copy(buffer, temp, temp.Length);

                    message.AddRange(new List<Byte>(temp));

                    i += temp.Length;
                }
                while (i < size);

                return message.ToArray();
            }
        }

        private static int ReceiveSize()
        {
            Byte[] digit = new Byte[1];

            string content = "";

            do
            {
                Communicator.socket.Receive(digit, 1, SocketFlags.None);

                char character = Convert.ToChar(digit[0]);

                if (character == '|')
                {
                    break;
                }

                content += character;
            }
            while (true);

            int.TryParse(content, out int size);

            return size;
        }

        //Byte[] content = Encoding.ASCII.GetBytes(message);

        //message += Encoding.ASCII.GetString(section, 0, length);
    }
}

/*using System;
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

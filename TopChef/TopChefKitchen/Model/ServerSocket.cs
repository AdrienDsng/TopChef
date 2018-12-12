using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ServerSocket
{

    // Incoming data from the client.  
    public static string data = null;

    public static void StartListening()
    {
        // Data buffer for incoming data.  
        byte[] bytes = new Byte[1024];

        // Establish the local endpoint for the socket.  
        // Dns.GetHostName returns the name of the   
        // host running the application.  
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        // Create a TCP/IP socket.  
        Socket listener = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

        // Bind the socket to the local endpoint and   
        // listen for incoming connections.  
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            // Start listening for connections.  
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                // Program is suspended while waiting for an incoming connection.  
                Socket handler = listener.Accept();
                data = null;

                // An incoming connection needs to be processed.  
                while (true)
                {
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                // Show the data on the console.  
                Console.WriteLine("Text received : {0}", data);

                // Echo the data back to the client.  
                byte[] msg = Encoding.ASCII.GetBytes(data);

                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();

    }

    public static int Main(String[] args)
    {
        StartListening();
        return 0;
    }
}



/*using System;
using System.Net;
using System.Net.Sockets;

namespace TopChefKitchen.Model
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
}*/

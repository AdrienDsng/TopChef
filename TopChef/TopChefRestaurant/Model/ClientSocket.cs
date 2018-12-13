using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ClientSocket
{

    public static void StartClient()
    {
        // Data buffer for incoming data.  
        byte[] bytes = new byte[1024];

        // Connect to a remote device.  
        try
        {
            // Establish the remote endpoint for the socket.  
            // This example uses port 11000 on the local computer.  
            //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP  socket.  
            Socket sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.  
            try
            {
                sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}",
                    sender.RemoteEndPoint.ToString());

                // Encode the data string into a byte array.  
                byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                // Send the data through the socket.  
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device.  
                int bytesRec = sender.Receive(bytes);
                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));

                // Release the socket.  
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Object>(jsonString );
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}/*using System;
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

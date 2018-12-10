using System;
using System.Net;
using System.Net.Sockets;


namespace Model

{
    public class ServerSocket
    {
        private Socket _socket;

        public ServerSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Bind(int port)
        { //IPadress equals localhost
            _socket.Bind(new IPEndPoint(IPAddress.Any, port));
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

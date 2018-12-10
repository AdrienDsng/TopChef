using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Socket
{
	private static Socket(string IP, int Port)
	{
        byte[] mgs = Encoding.UTF8.GetBytes("Test");

        //Data bufer for incoming data
        byte[] received = new byte[1024];
        //all connexion allowed
        permission = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "", SocketPermission.AllPorts);

        //add local endpoint 
        //host running application
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ipAdress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress, 11000);

        
    
	}
}

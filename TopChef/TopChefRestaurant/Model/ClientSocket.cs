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
        byte[] received = new byte[1024];


        //all connexion allowed
        permission = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "", SocketPermission.AllPorts);
        
    
	}
}

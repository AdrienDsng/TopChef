using Model.ClientSocket;

namespace Model
{
    class SocketMainClient
    { 
        private static ClientSocket ClientSocket= new ClientSocket();
        static void Main(string[] args)
        {
            ClientSocket.Connect("127.0.0.1");
        }
    }
}
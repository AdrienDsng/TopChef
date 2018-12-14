using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
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
                for (; ; )
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

        public static bool SendObject(object serializable)
        {
            try
            {
                var sw = new StringWriter();

                var s = new XmlSerializer(serializable.GetType());

                s.Serialize(sw, serializable);

                SendMessage(sw.ToString());

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static T ReceiveObject<T>() where T : class
        {
            try
            {
                byte[] array = Encoding.ASCII.GetBytes(ReceiveMessage());

                MemoryStream stream = new MemoryStream(array);

                var sr = new StreamReader(stream);

                var s = new XmlSerializer(typeof(T));

                return s.Deserialize(sr) as T;
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

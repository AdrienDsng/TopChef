using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model
{
    class Socket
    {
        private string lp;
        private int port;
        private byte[] received;

        public string Lp { get => lp; set => lp = value; }
        public int Port { get => port; set => port = value; }
        public byte[] Received { get => received; set => received = value; }

        public void Send()
        {

        }

        public void Receive()
        {

        }
    }
}

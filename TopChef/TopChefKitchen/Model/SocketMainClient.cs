﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopChefKitchen.Model.ClientSocket;

namespace TopChefKitchen.Model
{
    class SocketMainClient
    { 
        private static ClientSocket ClientSocket= new ClientSocket();
        static void Main(string[] args)
        {
            ClientSocket.Connect("127.0.0.1", 6556);

            while (true) { }
                Console.Readline();
        }
    }
}
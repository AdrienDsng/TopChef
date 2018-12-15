using Common;
using System.Collections.Generic;
using System.Threading;
using TopChefKitchen.Model.Material;

namespace TopChefKitchen.Controller
{
    public class SocketController
    {
        private List<string> Orders { get; set; }
        private Dish PendingDirtyDish { get; set; }

        public SocketController()
        {
            Communicator.Start(5555);
            (new Thread(CommunicationReceiver)).Start();

            Communicator.Connect("127.0.0.1", 4444);
            Communicator.Ready();
        }

        private void CommunicationReceiver()
        {
            var obj = Communicator.ReceiveObject();
            switch (obj.Name)
            {
                case "Order":
                    Orders = Serialized.Deserialize<List<string>>(obj);
                    break;
                case "Dish":
                    PendingDirtyDish = Serialized.Deserialize<Dish>(obj);
                    break;
            }
        }
    }

}
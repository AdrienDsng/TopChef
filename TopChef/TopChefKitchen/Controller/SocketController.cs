using Common;
using System.Collections.Generic;
using System.Threading;
using TopChefKitchen.Model;
using TopChefKitchen.Model.Material;


namespace TopChefKitchen.Controller
{
    public class SocketController
    {
        private List<Order> availableRecipes;
        private List<Order> orders { get; set; }
        private List<Order> availableOrders { get; set; }
        private Dish pendingDirtyDish { get; set; }

        internal List<Order> AvailableRecipes
        {
            get
            {
                return availableRecipes;
            }

            set
            {
                availableRecipes = value;
            }
        }

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
                case "List<Order>":
                    orders = Serialized.Deserialize<List<Order>>(obj);
                    break;
                case "Dish":
                    pendingDirtyDish = Serialized.Deserialize<Dish>(obj);
                    break;
            }
        }

        private void CommunicationSender()
        {
            Communicator.SendObject(Serialized.Serialize(AvailableRecipes));
        }


    }

}
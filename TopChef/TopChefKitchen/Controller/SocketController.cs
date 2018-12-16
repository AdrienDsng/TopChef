using Common;
using System;
using System.Collections.Generic;
using System.Threading;
using TopChefKitchen.Model;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.Person;

namespace TopChefKitchen.Controller
{
    public class SocketController
    {
        private List<Order> availableRecipes;
        private List<Order> Orders { get; set; }
        private List<Order> AvailableOrders { get; set; }
        private Dish PendingDirtyDish { get; set; }
        private KitchenChief KitchenChief { get; set; }
        private DishWasherDiver DishWasherDiver { get; set; }
        private DishWasher DishWasher { get; set; }

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

        public SocketController(PersonController personController, MachineController machineController)
        {
            this.DishWasherDiver = personController.DishWasherDiver;
            this.KitchenChief = personController.KitchenChief;
            this.DishWasher = machineController.DishWasher;
            
            Communicator.Start(5555);
            (new Thread(CommunicationReceiver)).Start();

            Communicator.Connect("127.0.0.1", 4444);
            Communicator.Ready();

            
        }

        private void CommunicationReceiver()
        {
            while (true)
            {           
                var obj = Communicator.ReceiveObject();
                switch (obj.Name)
                {
                    case "List<Order>":
                        Orders = Serialized.Deserialize<List<Order>>(obj);
                        GiveOrders(Orders);
                        break;
                    case "Dish":
                        PendingDirtyDish = Serialized.Deserialize<Dish>(obj);
                        GiveDishes(PendingDirtyDish);
                        break;
                }
            }
        }

        private void GiveDishes(Dish pendingDirtyDish)
        {           
            DishWasherDiver.PutDishInDishWasher(PendingDirtyDish, DishWasher);
        }

        private void GiveOrders(List<Order> orders)
        {

            //KitchenChief.GiveRecipeToCook();
        }

        public void MainLoop()
        {
            CommunicationReceiver();
        }

        private void CommunicationSender()
        {
            Communicator.SendObject(Serialized.Serialize(AvailableRecipes));
        }

    }

}
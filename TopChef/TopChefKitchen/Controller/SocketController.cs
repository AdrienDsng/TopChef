using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using TopChefKitchen.Model;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.Person;

namespace TopChefKitchen.Controller
{
    public class SocketController
    {
        private List<Order> AvailableRecipes { get; set; }
        private List<Order> Orders { get; set; }
        private List<Order> AvailableOrders { get; set; }
        private Dish PendingDirtyDish { get; set; }
        private KitchenChief KitchenChief { get; set; }
        private DishWasherDiver DishWasherDiver { get; set; }
        private List<Cook> Cooks { get; set; }
        private DishWasher DishWasher { get; set; }
        private WashMachine WashMachine { get; set; }
        private Stock Stock { get; set; }
        private TableNapkin PendingTableNapkin { get;  set; }
        private PersonController PersonController { get; set; }
        private int i = 0;

        public SocketController(PersonController personController, MachineController machineController)
        {
            AvailableRecipes = new List<Order>();
            Cooks = new List<Cook>();
            Orders = new List<Order>();
            AvailableOrders = new List<Order>();
            this.PersonController = personController;
            this.DishWasherDiver = personController.DishWasherDiver;
            this.KitchenChief = personController.KitchenChief;
            this.DishWasher = machineController.DishWasher;
            this.WashMachine = machineController.WashMachine;
            this.Stock = personController.Stock;
            Cooks.Add(personController.Cook1);
            Cooks.Add(personController.Cook2);
            Debug.WriteLine("TRY TO CONNECT");
            Communicator.Start(4444);
            (new Thread(CommunicationReceiver)).Start();

            Communicator.Ready();
            Debug.WriteLine("RDY !");
        }

        private void CommunicationReceiver()
        {
            while (true)
            {           
                var obj = Communicator.ReceiveObject();
                if (obj != null)
                {              
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
                    case "TableNapkin":
                        PendingTableNapkin = Serialized.Deserialize<TableNapkin>(obj);
                        GiveTableNapkin(PendingTableNapkin);
                        break;
                    default:
                        break;

                }
                }
            }
        }

        private void GiveTableNapkin(TableNapkin pendingTableNapkin)
        {
            DishWasherDiver.PutFabricInWashMachine(pendingTableNapkin, WashMachine);
        }

        private void GiveDishes(Dish pendingDirtyDish)
        {           
            DishWasherDiver.PutDishInDishWasher(PendingDirtyDish, DishWasher);
        }

        private void GiveOrders(List<Order> orders)
        {
            foreach (var value in orders)
            {
                KitchenChief.PendingOrders.Add(value);
            }
            if (i == 0)
            {
                InitializeCooks();
                i++;
            }                     
        }

        private void InitializeCooks()
        {

            KitchenChief.GiveRecipeToCook(Cooks[0],Stock);
            KitchenChief.GiveRecipeToCook(Cooks[1],Stock);
            
        }

        private void CommunicationSender()
        {
            Communicator.SendObject(Serialized.Serialize(AvailableRecipes));
            Communicator.SendObject(Serialized.Serialize(PersonController.GiveToSocketController()));
        }

        public void MainLoop()
        {
            CommunicationReceiver();
        }
    }

}
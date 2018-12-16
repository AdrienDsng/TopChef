using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Common;
using TopChefRestaurant.Model;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Material;

namespace TopChefRestaurant.Controller
{
    public class RecipeController
    {
        public AvailableRecipes AvailableRecipe = new AvailableRecipes();
        private PersonController _personController;
        private TableController _tableController;
        private Dictionary<Table, List<Order>> _tableOrders = new Dictionary<Table, List<Order>>();
        
        public RecipeController(PersonController personController)
        {
            this._personController = personController;

            Communicator.Start(5555);
            (new Thread(KitchenCommunicationReceiver)).Start();

            Debug.WriteLine("Connected");
            Communicator.Ready();
            Debug.WriteLine("RDY !");
        }

        public void SetTableController(TableController tableController)
        {
            _tableController = tableController;
        }

        private void KitchenCommunicationReceiver()
        {
            while (true)
            {
                var obj = Communicator.ReceiveObject();
                if (obj == null)
                {
                    Thread.Sleep(Sleeper.Instance.Period);
                    continue;
                }
                switch (obj.Name)
                {
                    case "AvailableRecipes":
                        AvailableRecipe = Serialized.Deserialize<AvailableRecipes>(obj);
                        break;
                    case "Order":
                        Order order = Serialized.Deserialize<Order>(obj);
                        Table table = _tableController.GetTableByName(order.TableName);
                        
                        _tableOrders[table].Add(order);
                        if (_tableOrders[table].Count == table.Orders.Count)
                        {
                            _tableOrders.Remove(table);
                            OrdersReceived(table);
                        }
                        break;
                }
            }
        }

        public void SendOrders(Table table)
        {
            _tableOrders.Add(table, new List<Order>());
            Communicator.SendObject(Serialized.Serialize(table.Orders));
        }

        public void OrdersReceived(Table table)
        {
            _personController.AddAction(new ServeTable(table));
        }
    }
}
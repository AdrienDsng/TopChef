using System.Collections.Generic;
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

        public RecipeController(PersonController personController)
        {
            this._personController = personController;

            Communicator.Start(5555);
            (new Thread(KitchenCommunicationReceiver)).Start();
            
            Communicator.Connect("127.0.0.1", 4444);
            Communicator.Ready();
        }

        public void SetTableController(TableController tableController)
        {
            _tableController = tableController;
        }

        private void KitchenCommunicationReceiver()
        {
            var obj = Communicator.ReceiveObject();
            switch (obj.Name)
            {
                case "AvailableRecipes":
                    AvailableRecipe = Serialized.Deserialize<AvailableRecipes>(obj);
                    break;
                case "List<Order>":
                    List<Order> orders = Serialized.Deserialize<List<Order>>(obj);
                    OrdersReceived(_tableController.GetTableByName(orders[0].tableName));
                    break;
            }
        }

        public void SendOrders(List<Order> orders)
        {
            Communicator.SendObject(Serialized.Serialize(orders));
        }

        public void OrdersReceived(Table table)
        {
            _personController.AddAction(new ServeTable(table));
        }
    }
}
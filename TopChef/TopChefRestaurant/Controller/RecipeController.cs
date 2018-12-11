using System.Collections.Generic;
using TopChefRestaurant.Model;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Material;

namespace TopChefRestaurant.Controller
{
    public class RecipeController
    {
        public List<Recipe> AvailableRecipe = new List<Recipe>();
        private PersonController _personController;
        
        public RecipeController(PersonController personController)
        {
            this._personController = personController;
        }

        public void SendOrders(Table table)
        {
            OrdersReceived(table);//TODO wait for kitchen
        }

        public void OrdersReceived(Table table)
        {
            _personController.AddAction(new ServeTable(table));
        }
    }
}
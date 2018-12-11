using System;
using Newtonsoft.Json.Linq;
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class TakeCommands : Action, IAction
    {
        private RecipeController _recipeController;
        public Table Table;
        
        public TakeCommands(Table table, RecipeController recipeController) : base(60)
        {
            this.Table = table;
            this._recipeController = recipeController;
        }
        public override void Realize()
        {
            Random random = new Random();

            for (var i = 0; i < Table.Client.Number; i++)//TODO update this to check recipe availability in real time & select full menu
            {
                Table.Orders.Add(_recipeController.AvailableRecipe[random.Next(_recipeController.AvailableRecipe.Count)]);
            }

            _recipeController.SendOrders(Table);
            LogController.Log(new Event(this));
        }

        public bool CanRealize(object person)
        {
            return person is RowChief;
        }
    }
}
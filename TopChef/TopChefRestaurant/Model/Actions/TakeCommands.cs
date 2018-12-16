using System;
using Newtonsoft.Json.Linq;
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

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
            this.Position = new Position(Table.Position.X + 1, Table.Position.Y);
        }
        public override void Realize()
        {
            Random random = new Random();

            for (var i = 0; i < Table.Client.Number; i++)
            {
                Table.Orders.Add(_recipeController.AvailableRecipe.entries[random.Next(_recipeController.AvailableRecipe.entries.Count)]);
                Table.Orders.Add(_recipeController.AvailableRecipe.plats[random.Next(_recipeController.AvailableRecipe.plats.Count)]);
                Table.Orders.Add(_recipeController.AvailableRecipe.desserts[random.Next(_recipeController.AvailableRecipe.desserts.Count)]);
            }

            _recipeController.SendOrders(Table.Orders);
            LogController.Log(new Event(this));
        }

        public bool CanRealize(object person)
        {
            return person is RowChief;
        }

        public Position Position { get; set; }
    }
}
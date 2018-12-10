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
        private Table Table;
        public TakeCommands(Table table, RecipeController recipeController) : base(60)
        {
            this.Table = table;
            this._recipeController = recipeController;
        }
        public override void Realize()
        {
            Random random = new Random();

            for (var i = 0; i < Table.Client.Number; i++)
            {
                Table.Orders.Add(_recipeController.AvailableRecipe[random.Next(_recipeController.AvailableRecipe.Count)]);
            }
        }

        public bool CanRealize(object person)
        {
            return person is RowChief;
        }
    }
}
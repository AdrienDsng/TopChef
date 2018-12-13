using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.Person;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Person
{

    class KitchenChief : Person, IObserver
    {
        public static Semaphore semaphore = new Semaphore(0, 1);
        private Recipe.Recipe recipe;
        public KitchenChief( Position position, int time) : base( position, time)
        {
            Name = "KitchenChief";
            IsAlive = true;
            IsStatic = false;           
            Arrive();            
        }

        public void GetCommand(List<string> commands, Stock stock)
        {
            foreach (string command in commands)
            {
                if(stock.CheckIfResourceAvailable(command))
                {
                    recipe = stock.SelectRecipe(command);
                }
            }
        }
        public void GiveRecipeToCook(Cook cook)
        {
            cook.Recipe = recipe;
        }

        public Dictionary<string, int> CheckStock(Stock stock, string name)
        {
            Dictionary<string, int> recipes = stock.GetRecipeNameWithTypes();

            foreach(KeyValuePair<string, int> recipe in recipes)
            {
                if (!stock.CheckIfResourceAvailable(recipe.Key))
                {
                    recipes.Remove(recipe.Key);
                }
            }

            return recipes;
        }
        
        public void PutIngredientInTheFridge(Tool.Tool tool, Machine machine)
        {
            throw new NotImplementedException();
        }

        public void TakeTool(String name, Position position)
        {
            Move(position);
            ToolFactory.GetInstance(name, position);
        }

        
        public void Update(String name)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Controller;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.Person;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Person
{

    public class KitchenChief : Person, IObserverChief
    {
        private List<Order> Orders;
        public static Semaphore semaphore = new Semaphore(0, 1);
        private Recipe.Recipe recipe;

        public KitchenChief( Position position, int time) : base( position, time)
        {
            Name = "KitchenChief";
            IsAlive = true;
            IsStatic = false;           
            Arrive();            
        }

        public void GetCommand(List<Order> commands, Stock stock)
        {
            foreach (var command in commands)
            {
                if(stock.CheckIfResourceAvailable(command.Name))
                {
                    recipe = stock.SelectRecipe(command.Name);
                }
            }

            Orders = CheckStock(commands, stock);
        }

        public void GiveRecipeToCook(Cook cook)
        {
            cook.Recipe = recipe;
            cook.ActualStep = recipe.Steps[0];
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

        public void Update(String state, Cook cook)
        {
            if(state == "Standby")
            {
                GiveRecipeToCook(cook);
            }
        }

        public List<Order> CheckStock(List<Order> commands, Stock stock)
        {
            foreach(Order command in commands)
            {
                if (!stock.CheckIfResourceAvailable(command.Name)){
                    commands.Remove(command);
                }
            }
            return commands;
        }

        public List<Order> SendBackAvailableRecipes()
        {
            return Orders;
        }
    }
}

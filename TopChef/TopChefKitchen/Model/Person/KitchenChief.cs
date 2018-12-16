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
        private List<Order> Orders { get; set; }
        public List<Order> PendingOrders { get; set; }
        public static Semaphore semaphore = new Semaphore(0, 1);
        private Recipe.Recipe Recipe { get; set; }
        private Recipe.Recipe Cookrecipe { get; set; }
        public Order ReturnRecipe { get; set; }

        public KitchenChief( Position position, int time) : base( position, time)
        {
            Orders = new List<Order>();
            PendingOrders = new List<Order>();
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
                    Recipe = stock.SelectRecipe(command.Name);
                }
            }

            Orders = CheckStock(commands, stock);
        }

        public void GiveRecipeToCook(Cook cook, Stock stock)
        {
            if (stock.CheckIfResourceAvailable(Orders[0].Name))
            {
                Cookrecipe = stock.SelectRecipe(Orders[0].Name);
            }
            cook.Recipe = Cookrecipe;
            Orders.RemoveAt(0);
            cook.ActualStep = Recipe.Steps[0];
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

        public void Update(String state, Cook cook, Stock stock)
        {
            if(state == "Standby")
            {
                GiveRecipeToCook(cook, stock);
            }

            ReturnRecipe = new Order();
            ReturnRecipe.Name = cook.Recipe.Name;
            ReturnRecipe.Type = cook.Recipe.Type;


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

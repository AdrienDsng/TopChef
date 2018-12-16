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
    /// <summary>
    /// KitchenChief used to instanciate object
    /// </summary>
    public class KitchenChief : Person, IObserverChief
    {
        /// <summary>
        /// setting up attributes
        /// </summary>
        private List<Order> Orders { get; set; }
        public List<Order> PendingOrders { get; set; }
        public static Semaphore semaphore = new Semaphore(0, 1);
        private Recipe.Recipe Recipe { get; set; }
        private Recipe.Recipe Cookrecipe { get; set; }
        public Order ReturnRecipe { get; set; }

        /// <summary>
        /// setup constructor
        /// </summary>
        /// <param name="position"></param>
        /// <param name="time"></param>
        public KitchenChief( Position position, int time) : base( position, time)
        {
            Orders = new List<Order>();
            PendingOrders = new List<Order>();
            Name = "KitchenChief";
            IsAlive = true;
            IsStatic = false;           
            Arrive();            
        }

        /// <summary>
        /// iterates all commands and checks if resources are available for theses commands
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="stock"></param>
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

        /// <summary>
        /// takes an order from the list and gives it to cook by attribute
        /// </summary>
        /// <param name="cook"></param>
        /// <param name="stock"></param>
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
        
        /// <summary>
        /// cf cook
        /// </summary>
        /// <param name="tool"></param>
        /// <param name="machine"></param>
        public void PutIngredientInTheFridge(Tool.Tool tool, Machine machine)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// cf cook
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public void TakeTool(String name, Position position)
        {
            Move(position);
            ToolFactory.GetInstance(name, position);
        }

        /// <summary>
        /// is updated when cook finishes a recipe
        /// returns a new recipe to the cook
        /// </summary>
        /// <param name="state"></param>
        /// <param name="cook"></param>
        /// <param name="stock"></param>
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

        /// <summary>
        /// checks the hole stock to see if any order has to be erased
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
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

        /// <summary>
        /// returns back all available orders
        /// </summary>
        /// <returns></returns>
        public List<Order> SendBackAvailableRecipes()
        {
            return Orders;
        }

       
    }
}

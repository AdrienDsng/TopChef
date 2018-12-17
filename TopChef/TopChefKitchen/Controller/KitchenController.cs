using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model;
using TopChefKitchen.Model.Recipe;

namespace TopChefKitchen.Controller
{
    class KitchenController
    {        
        private MachineController MachineController { get; set; }
        public SocketController SocketController { get; set; }
        private ToolController ToolController { get; set; }
        private PersonController PersonController { get; set; }
        private Stock Stock { get; set; }
       
        
        public KitchenController()
        {      
            this.Stock = new Stock();
            this.MachineController = new MachineController();          
            this.PersonController = new PersonController(Stock, MachineController);
           
            //this.SocketController = new SocketController(PersonController, MachineController);
            //new Thread(new ThreadStart(SocketController.MainLoop));

        }

        public void Loop()
        {
            int i= 0;
            while (true)
            {                              
                MachineController.MainLoop();
                PersonController.MainLoop(MachineController, SocketController);               
            }
            
        }
        public void TestMehtod()
        {

            Recipe recipe = new Recipe();
            recipe.Name = "test";
            recipe.Type = 1;
            Step step = new Step();
            step.Id = 1;
            step.Resource_Needed = "CookingFire";
            step.Nb_step = 1;
            step.Wait_Time = 20;
            Step step2 = new Step();
            step.Id = 2;
            step.Resource_Needed = "CookingKnife";
            step.Nb_step = 2;
            step.Wait_Time = 30;
            recipe.Steps.Add(step);
            recipe.Steps.Add(step2);
            PersonController.KitchenChief.Cookrecipe = recipe;
            PersonController.KitchenChief.Recipe = recipe;
            PersonController.KitchenChief.GiveRecipeToCook(PersonController.Cook1, Stock);
            PersonController.Cook1.MakeRecipe(MachineController.Machines);


        }
    }
}

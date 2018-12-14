using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefRestaurant.Model;
using TopChefRestaurant.View;

namespace TopChefRestaurant.Controller
{
    class RestaurantController
    {
        private Sleeper sleeper = Sleeper.Instance;
        private PersonController PersonController;
        private TableController TableController;
        private ClientController ClientController;
        private RecipeController RecipeController;
        private bool ShouldLoop = true;
        
        public RestaurantController()
        {
            this.PersonController = new PersonController();
            this.RecipeController = new RecipeController(PersonController);
            this.TableController = new TableController(PersonController, RecipeController);
            this.ClientController = new ClientController(PersonController, TableController);
            
            RecipeController.SetTableController(TableController);
        }

        public void Loop()
        {
            while (ShouldLoop)
            {
                if (!sleeper.IsPaused)
                {
                    ClientController.MainLoop();
                    TableController.MainLoop();
                    PersonController.MainLoop();

                    sleeper.TimeElapsed += 1000;
                }

                Thread.Sleep(sleeper.Period);
            }
        }

        public void StopLoop()
        {
            this.ShouldLoop = false;
        }
    }
}

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
        private RestaurantView RestaurantView;
        private bool ShouldLoop = true;
        
        public RestaurantController(RestaurantView view)
        {
            this.RestaurantView = view;
            this.PersonController = new PersonController(RestaurantView);
            this.RecipeController = new RecipeController(PersonController);
            this.TableController = new TableController(RestaurantView, PersonController, RecipeController);
            this.ClientController = new ClientController(RestaurantView, PersonController, TableController);
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

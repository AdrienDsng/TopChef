using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefRestaurant.Model;

namespace TopChefRestaurant.Controller
{
    class RestaurantController
    {
        private Sleeper sleeper = new Sleeper();
        private PersonController PersonController;
        private TableController TableController;
        private ClientController ClientController;
        
        public RestaurantController(RestaurantModel model)
        {
            this.PersonController = new PersonController();
            this.TableController = new TableController(PersonController);
            this.ClientController = new ClientController(PersonController, TableController);
        }

        public void Loop()
        {
            while (true)
            {
                if (!sleeper.IsPaused)
                {
                    ClientController.MainLoop();
                    TableController.MainLoop();
                    PersonController.MainLoop();
                }

                Thread.Sleep(sleeper.Period);
            }
        }
    }
}

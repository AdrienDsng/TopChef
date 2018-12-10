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
        private PersonController PersonController = new PersonController();
        private TableController TableController = new TableController();
        
        public RestaurantController(RestaurantModel model)
        {
            
        }

        public void Loop()
        {
            while (true)
            {
                if (!sleeper.IsPaused)
                {
                    PersonController.MainLoop();
                    TableController.MainLoop();
                }

                Thread.Sleep(sleeper.Period);
            }
        }
    }
}

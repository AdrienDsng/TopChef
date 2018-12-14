using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model;

namespace TopChefKitchen.Controller
{
    class KitchenController
    {        
        private MachineController MachineController { get; set; }
        public SocketController SocketController { get; set; }
        private ToolController ToolController { get; set; }
        private PersonController PersonController { get; set; }
        private StockController StockController { get; set; }
        //private KitchenView RestaurantView{ get; set; }
        
        public KitchenController()
        {
            this.StockController = new StockController();
            this.MachineController = new MachineController();
            this.SocketController = new SocketController();
            this.PersonController = new PersonController(StockController, MachineController);         
        }

        public void Loop()
        {
            StockController.MainLoop();
            MachineController.MainLoop(PersonController);
            PersonController.MainLoop();
        }
    }
}

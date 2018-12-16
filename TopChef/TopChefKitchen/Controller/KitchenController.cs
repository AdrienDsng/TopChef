using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Stock Stock { get; set; }
       
        
        public KitchenController()
        {      
            
            this.MachineController = new MachineController();            
            this.PersonController = new PersonController(Stock, MachineController);
            this.SocketController = new SocketController(PersonController, MachineController);
            new Thread(new ThreadStart(SocketController.MainLoop));
        }

        public void Loop()
        {
            int i= 0;
            while (true)
            {                              
                MachineController.MainLoop();
                PersonController.MainLoop(MachineController);               
            }
            
        }
    }
}

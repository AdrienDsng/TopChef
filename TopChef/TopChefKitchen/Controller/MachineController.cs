using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Controller
{
    class MachineController
    {
        private List<Machine> Machines { get; set; }

        public MachineController()
        {
            Machines.Add(new Fridge(new Position(10, 10))); 
            Machines.Add(new DishWasher(new Position(10, 9)));
            Machines.Add(new Oven(new Position(10, 8)));
            Machines.Add(new Tap(new Position(10, 7)));
            Machines.Add(new Mixer(new Position(10, 6)));
            Machines.Add(new WashMachine(new Position(10, 5)));
            Machines.Add(new CookingTable(new Position(20, 20)));
            Machines.Add(new CookingTable(new Position(19, 20)));
            Machines.Add(new CookingTable(new Position(18, 20)));
            Machines.Add(new CookingTable(new Position(20, 19)));
            Machines.Add(new CookingTable(new Position(20, 18)));
            Machines.Add(new CookingTable(new Position(18, 18)));
            Machines.Add(new CookingTable(new Position(19, 18)));
            Machines.Add(new CookingTable(new Position(18, 19)));
            Machines.Add(new CookingTable(new Position(25, 25)));
            Machines.Add(new CookingTable(new Position(26, 25)));
            Machines.Add(new CookingTable(new Position(27, 25)));
            Machines.Add(new CookingTable(new Position(25, 26)));
            Machines.Add(new CookingTable(new Position(25, 27)));
            Machines.Add(new CookingTable(new Position(27, 27)));
            Machines.Add(new CookingTable(new Position(26, 27)));
            Machines.Add(new CookingTable(new Position(27, 26)));
            Machines.Add(new Bar(new Position(10, 10)));
        }
        public void MachineExecution()
        {
            foreach (var value in Machines)
            {
                if(value.State == "IsWorking")
                {                   
                    new Thread(new ThreadStart(value.IsWorking));                        
                }
            }
        }

        internal void MainLoop()
        {
            MachineExecution();
        }
    }
}

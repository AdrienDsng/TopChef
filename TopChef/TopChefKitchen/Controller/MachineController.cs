using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Controller
{
    public class MachineController
    {
        public List<Machine> Machines { get; set; }
        private Fridge Fridge { get; set; }
        public Tap Tap { get; set; }
        public DishWasher DishWasher { get; set; }
        public WashMachine WashMachine { get; set; }
        public MachineController()
        {
            Fridge = new Fridge(new Position(10, 10));
            Machines.Add(Fridge);
            DishWasher = new DishWasher(new Position(10, 9));
            Machines.Add(DishWasher);
            Machines.Add(new Oven(new Position(10, 8)));
            Tap = new Tap(new Position(10, 7));
            Machines.Add(Tap);
            Machines.Add(new Mixer(new Position(10, 6)));
            WashMachine = new WashMachine(new Position(10, 5));
            Machines.Add(WashMachine);
            Machines.Add(new CookingFire(new Position(10, 4)));
            Machines.Add(new CookingFire(new Position(10, 3)));
            Machines.Add(new CookingFire(new Position(10, 2)));
            Machines.Add(new CookingFire(new Position(10, 1)));
            Machines.Add(new CookingFire(new Position(10, 0)));
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
                if(value.State == "WaitToStart")
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

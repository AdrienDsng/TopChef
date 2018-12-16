using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.Person;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Controller
{
    public class PersonController
    {
        private List<Person> Persons { get; set; }
        private List<Machine> Machines { get; set; }
        private Stock Stock { get; set; }
        public KitchenChief KitchenChief { get; set; }
        public DishWasherDiver DishWasherDiver { get; set; }
        public Cook Cook1 { get; set; }
        public Cook Cook2 { get; set; }
        public Apprentice Apprentice { get; set; }

        public PersonController(Stock Stock, MachineController machineController)
        {
            this.Stock = Stock;
            KitchenChief = new KitchenChief(new Position(5, 5), 10000);
            Persons.Add(KitchenChief);
            DishWasherDiver = new DishWasherDiver(new Position(5, 5), 10000, machineController.Tap);
            Persons.Add(DishWasherDiver);
            Cook1 = new Cook(new Position(5, 5), 10000);
            Cook2 = new Cook(new Position(5, 5), 10000);
            Persons.Add(Cook1);
            Persons.Add(Cook2);
            Apprentice = new Apprentice(new Position(5, 5), 10000);
            Persons.Add(Apprentice);

            AddObserversOnMachines(machineController);
            AddObserversOnPerson();
        }

        public void AddObserversOnMachines(MachineController machineController)
        {
            foreach (var value in machineController.Machines)
            {
                switch (value.Name)
                {
                    case "DishWasher":
                        value.AddObserver(DishWasherDiver);
                        break;
                    case "WashMachine":
                        value.AddObserver(DishWasherDiver);
                        break;                   
                    default:
                        value.AddObserver(Cook1);
                        value.AddObserver(Cook2);
                        break;

                }
            }
        }

        public void AddObserversOnPerson()
        {
            Cook1.AddObserver(KitchenChief);
            Cook2.AddObserver(KitchenChief);
            Apprentice.AddObserver(Cook1);
            Apprentice.AddObserver(Cook2);
        }

        void ExecuteDishWasher()
        {
            Thread.Sleep(60);
            foreach (var value in Machines)
            {
                if (value.Name == "DishWasher")
                {
                    DishWasherDiver.PowerOn(value);
                }
            }
        }
        
        public void GiveToSocketController()
        {

        }

        internal void MainLoop(MachineController machineController)
        {
            this.Machines = machineController.Machines;
            ExecuteDishWasher();
        }
    }
}

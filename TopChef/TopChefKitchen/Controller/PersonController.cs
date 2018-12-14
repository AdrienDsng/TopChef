using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model;
using TopChefKitchen.Model.Person;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Controller
{
    class PersonController
    {
        private List<Person> Persons { get; set; }
        private Stock Stock { get; set; }
        public KitchenChief KitchenChief { get; set; }
        public DishWasherDiver DishWasherDiver { get; set; }
        public Cook Cook1 { get; set; }
        public Cook Cook2 { get; set; }
        public Apprentice Apprentice { get; set; }

        public PersonController(StockController stockController, MachineController machineController)
        {
            Stock = stockController.Stock;
            KitchenChief = new KitchenChief(new Position(5, 5), 10000);
            Persons.Add(KitchenChief);
            DishWasherDiver = new DishWasherDiver(new Position(5, 5), 10000);
            Persons.Add(DishWasherDiver);
            Cook1 = new Cook(new Position(5, 5), 10000);
            Cook2 = new Cook(new Position(5, 5), 10000);
            Persons.Add(Cook1);
            Persons.Add(Cook2);
            Apprentice = new Apprentice(new Position(5, 5), 10000);
            Persons.Add(Apprentice);
        }

        public void PersonAction()
        {
            foreach (var value in Persons)
            {
                  
            }
        }
        internal void MainLoop()
        {
            throw new NotImplementedException();
        }
    }
}

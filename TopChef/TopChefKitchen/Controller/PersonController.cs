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

        public PersonController(StockController stockController, MachineController machineController)
        {
            Stock = stockController.Stock; 
            Persons.Add(new KitchenChief(new Position(5,5), 10000));
            Persons.Add(new DishWasherDiver(new Position(5, 5), 10000));
            Persons.Add(new Cook(new Position(5, 5), 10000));
            Persons.Add(new Cook(new Position(5, 5), 10000));
            Persons.Add(new Apprentice(new Position(5, 5), 10000));
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

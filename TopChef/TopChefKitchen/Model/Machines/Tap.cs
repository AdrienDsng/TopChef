using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Machines
{
    class Tap : Machine
    {
        
        public List<Dish> Dishes { get; set; }
        public static Semaphore semaphore = new Semaphore(0, 1);

        public Tap(Position position) : base(position)
        {
            this.Name = "Tap";
            this.IsStatic = false;
            this.Capacity = 1;
            this.WorkingTime = 0;
        }

        public void AddItem(Dish dish)
        {
            Dishes.Add(dish);
        }

        public void RemoveItem(Dish dish)
        {
            Dishes.Remove(dish);
        }
       
    }
}

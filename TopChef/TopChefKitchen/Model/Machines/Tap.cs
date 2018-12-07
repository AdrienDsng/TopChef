using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Machines
{
    class Tap : Machine
    {
        
        public List<Dishes> Dishes { get; set; }

        public Tap(Position position) : base()
        {
            this.Position = position;
            this.Name = "Tap";
            this.IsStatic = false;
            this.Capacity = 1;
            this.WorkingTime = 0;
        }

        public void addItem(Dishes dish)
        {
            Dishes.Add(dish);
        }

        public void removeItem(Dishes dish)
        {
            Dishes.Remove(dish);
        }
    }
}

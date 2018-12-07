using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Machines
{
    class DishWasher : Machine
    {

        public List<Dishes> Dishes { get; set ; }
        public int maxCuttelry = 24;
        public int maxGlass = 24;
        public int maxPlate = 24;
        public int waitTime = 10;

        public DishWasher(Position position) : base()
        {
            this.Position = position;
            this.Name = "DishWasher";
            this.IsStatic = false;
            this.Capacity = 72;
            this.WorkingTime = 10;
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

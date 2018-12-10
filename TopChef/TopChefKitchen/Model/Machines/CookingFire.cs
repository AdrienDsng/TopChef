using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Tool;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Machines
{
    class CookingFire : Machine
    {
        public List<ITool> Preparation { get; set; }
        public static Semaphore semaphore = new Semaphore(0, 5);

       
        public CookingFire(Position position) : base(position)
        {
            this.Name = "CookingFire";
            this.IsStatic = false;
            this.Capacity = 10;
            this.Preparation = new List<ITool>();
        }

        public void addItem(ITool tool)
        {
            Preparation.Add(tool);
        }

        public void removeItem(ITool tool)
        {
            Preparation.Remove(tool);
        }
        
    }
}

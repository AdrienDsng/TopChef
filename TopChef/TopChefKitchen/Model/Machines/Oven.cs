using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Machines
{
    class Oven : Machine
    {
        public List<ITool> Preparation { get; set; }
        public static Semaphore semaphore = new Semaphore(0, 1);


        public Oven(Position position) : base(position)
        {
            this.Name = "Oven";
            this.IsStatic = false;
            this.Capacity = 1;
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

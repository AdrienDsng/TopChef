using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Recipe;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Machines
{
    class Fridge : Machine
    {
        public List<ITool> Tools { get; set; }
        public static Semaphore semaphore = new Semaphore(0,1);

        public Fridge(position.Position position) : base(position)
        {            
            this.IsStatic = false;
            this.Capacity = 10;
            this.Tools = new List<ITool>();
        }

        public void AddItem(ITool tool)
        {
            Tools.Add(tool);
        }

        public void RemoveItem(ITool tool)
        {
            Tools.Remove(tool);
        }

    }
}

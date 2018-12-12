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
    class CookingTable : Machine
    {
        public List<ITool> Tools { get; set; }
        public bool IsDirty { get; set; }

        public static Semaphore semaphore = new Semaphore(0, 15);


        public CookingTable(Position position) : base(position)
        {
            this.IsDirty = false;
            this.Name = "CookingFire";
            this.IsStatic = false;
            this.Capacity = 1;
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

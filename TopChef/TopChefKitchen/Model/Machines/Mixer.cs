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
    public class Mixer : Machine
    {
        public List<ITool> Tools { get; set; }
        public bool IsDirty { get; set; }

        public static Semaphore semaphore = new Semaphore(0, 1);


        public Mixer(Position position) : base(position)
        {

            this.IsDirty = false;
            this.Name = "Oven";
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
        new public void ReadyToStart(Tool.Tool tool)
        {
            this.Tools.Add(tool);
            this.State = "WaitToStart";
        }
    }
}

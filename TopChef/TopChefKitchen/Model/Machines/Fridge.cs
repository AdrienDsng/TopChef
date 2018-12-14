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
        public List<Tool.Tool> Tools { get; set; }
        public List<int> WaitTime { get; set; }
        public static Semaphore semaphore = new Semaphore(0,1);
        public int i = 0;

        public Fridge(position.Position position) : base(position)
        {             
            this.IsStatic = false;
            this.Capacity = 10;
            this.Tools = new List<Tool.Tool>();
        }

        public void AddItem(Tool.Tool tool)
        {
            Tools.Add(tool);
        }

        public void RemoveItem(Tool.Tool tool)
        {
            Tools.Remove(tool);
        }

        public void ReadyToStart(Tool.Tool ToolUsed, int time)
        {
            AddItem(ToolUsed);
            WaitTime.Add(time);
            ToolUsed.State = "ReadyToWait";
        }

        new void IsWorking()
        {
            foreach (var value in Tools)
            {
                if (value.State == "ReadyToWait")
                {
                    void Sleep(){
                        Thread.Sleep(WaitTime[i]);
                    }

                    new Thread(new ThreadStart(Sleep));
                    value.State = "Standby";
                }               
                i++;
            }
        }


    }
}

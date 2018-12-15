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
    //<summary>
    //Class Fridge : class to represent the fridge in the kitchen
    //<summary>
    class Fridge : Machine
    {
        //<summary>
        //List with all tools
        //<summary>
        public List<Tool.Tool> Tools { get; set; }
        //<summary>
        //List with all Times for each tool to stay in the fridge
        //<summary>
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

        //<summary>
        //Method to make machine ready to start
        //<summary>
        public void ReadyToStart(Tool.Tool ToolUsed, int time)
        {
            AddItem(ToolUsed);
            WaitTime.Add(time);
            ToolUsed.State = "ReadyToWait";
        }

        //<summary>
        //Method to make machine Start 
        //<summary>
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

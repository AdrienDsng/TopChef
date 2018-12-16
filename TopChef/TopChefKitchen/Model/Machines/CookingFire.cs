using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Tool;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Interface;

namespace TopChefKitchen.Model.Machines
{

    //<summary>
    //Class CookingFire : class to represent Cooking fire in the kitchen
    //<summary>
    public class CookingFire : Machine , IWashable
    {
        //<summary>
        //List with all tools
        //<summary>
        public List<ITool> Tools { get; set; }
        public bool IsDirty { get ; set ; }

        //<summary>
        //Semaphore implemented
        //<summary>
        public static Semaphore semaphore = new Semaphore(0, 5);

       
        public CookingFire(Position position) : base(position)
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

        //<summary>
        //Method to make machine ready to start
        //<summary>
        new public void ReadyToStart(Tool.Tool tool)
        {
            this.Tools.Add(tool);
            this.State = "WaitToStart";
        }
    }
}

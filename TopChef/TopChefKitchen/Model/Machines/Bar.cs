using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Recipe;

namespace TopChefKitchen.Model.Machines
{
    class Bar : Machine
    {
        public List<Preparation> Tools { get; set; }
        public bool IsDirty { get; set; }

        public static Semaphore semaphore = new Semaphore(0, 1);


        public Bar(Position position) : base(position)
        {
            this.IsDirty = false;
            this.Name = "Bar";
            this.IsStatic = false;
            this.Capacity = 10;
            this.Tools = new List<Preparation>();
        }

        public void AddItem(Preparation preparation)
        {
            Tools.Add(preparation);
        }

        public void RemoveItem(Preparation preparation)
        {
            Tools.Remove(preparation);
        }
    }
}

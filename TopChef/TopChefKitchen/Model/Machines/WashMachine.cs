using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Machines
{
    class WashMachine : Machine
    {
        public List<Fabric> Fabrics { get; set; }
        public static Semaphore semaphore = new Semaphore(0, 1);

        public WashMachine(Position position) : base(position)
        {
            this.Name = "WashMachine";
            this.IsStatic = false;
            this.Capacity = 100000000;
            this.WorkingTime = 10;
        }

        public void addItem(Fabric fabric)
        {
            Fabrics.Add(fabric);
        }

        public void removeItem(Fabric fabric)
        {
            Fabrics.Remove(fabric);
        }

        public void check()
        {
            if(Fabrics.Count() > 10)
            {
                this.State = "Working";
            }
        }

    }
}

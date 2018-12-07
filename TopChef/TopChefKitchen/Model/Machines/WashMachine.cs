using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Machines
{
    class WashMachine : Machine
    {
        public List<Fabrics> Fabrics { get; set; }
       

        public WashMachine(Position position) : base()
        {
            this.Position = position;
            this.Name = "WashMachine";
            this.IsStatic = false;
            this.Capacity = 10;
            this.WorkingTime = 10;
        }

        public void addItem(Fabrics fabric)
        {
            Fabrics.Add(fabric);
        }

        public void removeItem(Fabrics fabric)
        {
            Fabrics.Remove(fabric);
        }

    }
}

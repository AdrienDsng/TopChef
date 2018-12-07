using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Material;

namespace TopChefKitchen.Model.Machines
{
    class WashMachine
    {
        public List<Fabrics> Fabrics { get; set; }

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

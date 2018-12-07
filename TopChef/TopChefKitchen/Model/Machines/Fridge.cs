using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Recipe;

namespace TopChefKitchen.Model.Machines
{
    class Fridge : Machine
    {

        public List<Preparation> Preparation { get; set; }

        public Fridge(position.Position position, string name) : base()
        {
            this.Position = position;
            this.Name = "Fridge";
            this.IsStatic = false;
            this.Capacity = 10;                       
        }

        public void addItem(Preparation preparation)
        {
            Preparation.Add(preparation);
        }

        new public void removeItem(Preparation preparation)
        {
            Preparation.Remove(preparation);
        }

    }
}

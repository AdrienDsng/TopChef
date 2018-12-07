using projettopchef.Kitchen.Model.Interface;
using projettopchef.Kitchen.Model.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projettopchef.Kitchen.Model.Machines
{
    class Fridge : Machine
    {
       

        public Fridge(position.Position position) : base()
        {
            this.Position = position;
            this.Name = "Fridge";
            this.IsStatic = false;
            this.Capacity = 10;
            
            
        }

        public List<Preparation> Preparation { get; set ; }

        public void addItem(INamed name, int waitTime)
        {
            throw new NotImplementedException();
        }

        new public void removeItem(INamed name)
        {
            throw new NotImplementedException();
        }

    }
}

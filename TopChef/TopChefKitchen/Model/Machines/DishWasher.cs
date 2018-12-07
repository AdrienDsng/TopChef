using projettopchef.Kitchen.Model.Interface;
using projettopchef.Kitchen.Model.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projettopchef.Kitchen.Model.Machines
{
    class DishWasher : Machine
    {

        public List<Dishes> Dishes { get; set ; }

        new public void addItem(INamed name)
        {
            throw new NotImplementedException();
        }

        new public void removeItem(INamed name)
        {
            throw new NotImplementedException();
        }
    }
}

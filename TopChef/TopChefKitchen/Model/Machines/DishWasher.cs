using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Machines
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

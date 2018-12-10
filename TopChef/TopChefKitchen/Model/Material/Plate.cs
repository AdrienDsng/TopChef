using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class Plate : Dish
    {
        public Plate(position.Position position)
        {
            Position = position;
            Quantity = 150;
            Size = "Small";
            Name = "Plate";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

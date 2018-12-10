using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class DessertPlate : Dish
    {
        public DessertPlate(position.Position position)
        {
            Position = position;
            Quantity = 150;
            Size = "Small";
            Name = "DessertPlate";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

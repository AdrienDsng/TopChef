using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class CurvyPlate : Dish
    {
        public CurvyPlate(position.Position position)
        {
            Position = position;
            Quantity = 30;
            Size = "Small";
            Name = "CurvyPlate";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

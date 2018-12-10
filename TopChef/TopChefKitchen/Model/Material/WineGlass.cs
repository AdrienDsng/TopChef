using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class WineGlass : Glass
    {
        public WineGlass(position.Position position) :base(position)
        {
            Position = position;
            Quantity = 150;
            Size = "Small";
            Name = "WineGlass";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

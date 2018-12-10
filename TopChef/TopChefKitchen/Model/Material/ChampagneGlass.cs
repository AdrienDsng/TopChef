using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class ChampagneGlass : Glass
    {
        public ChampagneGlass(position.Position position) : base(position)
        {
            Position = position;
            Quantity = 150;
            Size = "Small";
            Name = "ChampagneGlass";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

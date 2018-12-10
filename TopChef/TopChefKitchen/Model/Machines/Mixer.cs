using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    class Mixer : Tool
    {
        public Mixer(position.Position position)
        {
            Position = position;
            Quantity = 1;
            Size = "Small";
            Name = "Mixer";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }
    }
}

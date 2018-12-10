using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    class Pan : Tool
    {
        public Pan(position.Position position)
        {
            Position = position;
            Quantity = 10;
            Size = "Small";
            Name = "Pan";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }
    }
}

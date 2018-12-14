using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    class PressureCooker : Tool
    {
        public PressureCooker(position.Position position) : base(position)
        {
            Position = position;
            Quantity = 2;
            Size = "Small";
            Name = "PressureCooker";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }
    }
}

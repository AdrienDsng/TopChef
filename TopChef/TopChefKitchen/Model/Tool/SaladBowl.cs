using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    public class SaladBowl : Tool
    {
        public SaladBowl(position.Position position) : base(position)
        {
            Position = position;
            Quantity = 5;
            Size = "Small";
            Name = "SaladBowl";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }
    }
}

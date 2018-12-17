using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    public class Juicer : Tool
    {
        public Juicer(position.Position position) : base(position)
        {
            Position = position;
            Quantity = 1;
            Size = "Small";
            Name = "Juicer";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }
    }
}

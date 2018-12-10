using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    class Juicer : Tool
    {
        public Juicer(position.Position position)
        {
            Position = position;
            Quantity = 1;
            Size = "2";
            Name = "Juicer";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }
    }
}

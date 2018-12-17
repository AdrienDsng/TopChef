using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    public class Sieve : Tool
    {
        public Sieve(position.Position position) : base(position)
        {
            Position = position;
            Quantity = 1;
            Size = "Small";
            Name = "Sieve";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }
    }
}

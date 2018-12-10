using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class BigSpoon : Cuttlery
    {
        public BigSpoon(position.Position position)
        {
            Position = position;
            Quantity = 150;
            Size = "Small";
            Name = "BigSpoon";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    class CookingFire : Tool
    {
        public CookingFire(position.Position position)
        {
            Position = position;
            Quantity = 5;
            Size = "Big"; 
            Name = "CookingFire";
            State = "Standby";
            IsStatic = true;
            IsDirty = false;

    }
}
}

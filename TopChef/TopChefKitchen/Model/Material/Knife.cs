using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class Knife : Cuttlery
    {
        public Knife(position.Position position)
        {
            Position = position;
            Quantity = 150;
            Size = "Small";
            Name = "Knife";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

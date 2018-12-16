using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    public class CookingKnife : Tool
    {
        public CookingKnife(position.Position position) : base(position)
        {
            Position = position;
            Quantity = 5;
            Size = "Small";
            Name = "CookingKnife";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }
    }
}

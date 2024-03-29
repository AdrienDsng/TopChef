﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    public class Stove : Tool
    {
        public Stove(position.Position position) : base(position)
        {
            Position = position;
            Quantity = 10;
            Size = "Small";
            Name = "Stove";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class TableCloth : Fabric
    {
        public static Semaphore semaphore = new Semaphore(0, 40);
        public TableCloth(position.Position position)
        {
            Position = position;
            Quantity = 40;
            Size = "Big";
            Name = "TableCloth";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

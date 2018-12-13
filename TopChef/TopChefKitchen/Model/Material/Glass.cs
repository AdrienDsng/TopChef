using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class Glass : Dish
    {
        public static Semaphore semaphore = new Semaphore(0, 150);
        public Glass(position.Position position)
        {
            Position = position;
            Quantity = 150;
            Size = "Small";
            Name = "Glass";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

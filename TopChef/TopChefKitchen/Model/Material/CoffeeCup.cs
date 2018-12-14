using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class CoffeeCup : Dish
    {
        public static Semaphore semaphore = new Semaphore(0, 150);

        public CoffeeCup(position.Position position)
        {
            Position = position;
            Quantity = 50;
            Size = "Small";
            Name = "CoffeeCup";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

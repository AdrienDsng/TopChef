using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class ChampagneGlass : Dish
    {
        public static Semaphore semaphore = new Semaphore(0, 150);
        public ChampagneGlass(position.Position position) 
        {
            Position = position;
            Quantity = 150;
            Size = "Small";
            Name = "ChampagneGlass";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

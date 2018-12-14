using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class LittleSpoon : Cuttlery
    {
        public static Semaphore semaphore = new Semaphore(0, 150);
        public LittleSpoon(position.Position position)
        {
            Position = position;
            Quantity = 150;
            Size = "Small";
            Name = "LittleSpoon";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

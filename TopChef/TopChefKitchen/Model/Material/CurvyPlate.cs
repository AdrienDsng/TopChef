using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class CurvyPlate : Dish
    {
        public static Semaphore semaphore = new Semaphore(0, 30);

        public CurvyPlate(position.Position position)
        {
            Position = position;
            Quantity = 30;
            Size = "Small";
            Name = "CurvyPlate";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;

        }
    }
}

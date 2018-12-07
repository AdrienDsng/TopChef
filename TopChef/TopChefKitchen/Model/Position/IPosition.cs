using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.position
{
    interface IDisplayable
    {
        int X { get; set; }
        int Y { get; set; }
        void move(Position position);
    }
}

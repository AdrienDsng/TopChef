
using projettopchef.Kitchen.Model.position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projettopchef.Kitchen.Model.position
{
    class Position : IPosition
    {

        public int X { get ; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void move(Position position)
        {
            this.X = position.X;
            this.Y = position.Y;
        }
    }
}

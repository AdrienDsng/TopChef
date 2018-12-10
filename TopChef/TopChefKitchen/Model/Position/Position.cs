﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.position
{
    class Position 
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

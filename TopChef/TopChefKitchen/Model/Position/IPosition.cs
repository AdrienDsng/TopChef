﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.position
{
    public interface IPosition
    {
        Position Position { get; set; }
        void Move(Position position);
    }
}

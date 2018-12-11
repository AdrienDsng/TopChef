﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Person
{
    interface IPerson
    {
        int WorkingTime { get; set; }
        bool IsAlive { get; set; }
        Tool.Tool tool { get; set; }

        void Arrive();
        void Leave();
    }
}

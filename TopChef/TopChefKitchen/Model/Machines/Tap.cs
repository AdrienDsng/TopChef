﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Material;

namespace TopChefKitchen.Model.Machines
{
    class Tap : Machine
    {
        public List<Dishes> Dishes { get; set; }

        public void addItem(Dishes dish)
        {
            Dishes.Add(dish);
        }

        public void removeItem(Dishes dish)
        {
            Dishes.Remove(dish);
        }
    }
}

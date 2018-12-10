﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Tool;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Interface;

namespace TopChefKitchen.Model.Machines
{
    class CookingFire : Machine , IWashable
    {
        public List<ITool> Tools { get; set; }
        public bool IsDirty { get ; set ; }

        public static Semaphore semaphore = new Semaphore(0, 5);

       
        public CookingFire(Position position) : base(position)
        {
            this.IsDirty = false;
            this.Name = "CookingFire";
            this.IsStatic = false;
            this.Capacity = 1;
            this.Tools = new List<ITool>();
        }

        public void addItem(ITool tool)
        {
            Tools.Add(tool);
        }

        public void removeItem(ITool tool)
        {
            Tools.Remove(tool);
        }      
    }
}

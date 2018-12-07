﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projettopchef.Kitchen.Model.Interface;
using projettopchef.Kitchen.Model.position;

namespace projettopchef.Kitchen.Model.Machines
{
    class Machine : IMachine, IState, IStatic, INamed
    {
   
        public int Capacity { get ; set; }
        public int WaitTime { get ; set ; }
        public bool IsStatic { get; set; }
        public string State { get ; set; }
        public string Name { get ; set ; }
        internal List<INamed> Items { get ; set ; }
        internal Position Position { get ; set; }

        public Machine(Position position, string name)
        {
            this.Position = position;
        }

        public Machine()
        {

        }

        public void addItem(INamed name)
        {
            Items.Add(name);
        }

        public void off()
        {
            this.State = "off";
        }

        public void on()
        {
            this.State = "standby";
        }

        public void removeItem(INamed name)
        {
            Items.Remove(name);
        }
    }
}
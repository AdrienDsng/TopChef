﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Machines
{
    class Machine : IMachine, IState, IStatic, INamed, IPosition, IObservable
    {
         
        public int Capacity { get ; set; }
        public int WorkingTime { get ; set ; }
        public bool IsStatic { get; set; }
        public string State { get ; set; }
        public string Name { get ; set ; }
        public Position Position { get ; set; }
        public List<IObserverChief> Observers { get ; set ; }

        public Machine(Position position, string name)
        {
            this.Observers = new List<IObserverChief>();
            this.Position = position;
            this.Capacity = 1;
            this.WorkingTime = 5;
            this.IsStatic = false;
            this.Name = "Machine";
            On();
        }

        public Machine(Position position)
        {
            Position = position;
            On();
        }

        public void Off()
        {
            this.State = "Off";
        }

        public void On()
        {
            this.State = "Standby";
        }

        public void ReadyToStart(Tool.Tool tool)
        {
            this.State = "WaitToStart";
        }

        public void IsWorking()
        {
            this.State = "IsWorking";
            Thread.Sleep(WorkingTime);
            this.State = "Standby";

        }

        public void Move(Position position)
        {
            Position = position;
        }

        public void AddObserver(IObserverChief observer)
        {
            Observers.Add(observer);
        }

        public void DelObserver(IObserverChief observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
           
        }       
    }
}

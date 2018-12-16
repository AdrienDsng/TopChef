using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Controller;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Machines
{
    public class Machine : IMachine, IState, IStatic, INamed, IPosition, IObservableByCook, IObservableByDiver
    {
         
        public int Capacity { get ; set; }
        public int WorkingTime { get ; set ; }
        public bool IsStatic { get; set; }
        public string State { get ; set; }
        public string Name { get ; set ; }
        public Position Position { get ; set; }
        public List<IObserverCook> Observers { get ; set ; }

        public Machine(Position position, string name)
        {
            this.Observers = new List<IObserverCook>();
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
            LogController.Log(this.Name+this.State);
            Thread.Sleep(WorkingTime);
            this.State = "Standby";
            LogController.Log(this.Name + this.State);
            Notify();

        }

        public void Move(Position position)
        {
            Position = position;
        }

        public void AddObserver(IObserverCook observer)
        {
            Observers.Add(observer);
        }

        public void DelObserver(IObserverCook observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
           foreach (var value in Observers)
            {
                value.Update(this.State, this);
            }
        }

        public void AddObserver(IObserverDiver observer)
        {
            throw new NotImplementedException();
        }

        public void DelObserver(IObserverDiver observer)
        {
            throw new NotImplementedException();
        }
    }
}

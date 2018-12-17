using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Machines
{
    public class WashMachine : Machine , IObservableByDiver
    {
        public List<Fabric> Fabrics { get; set; }
        public static Semaphore semaphore = new Semaphore(0, 1);
        new public List<IObserverDiver> Observers { get; set; }

        public WashMachine(Position position) : base(position)
        {
            Fabrics = new List<Fabric>();
            this.Name = "WashMachine";
            this.IsStatic = false;
            this.Capacity = 100000000;
            this.WorkingTime = 10;
        }

        public void AddItem(Fabric fabric)
        {
            Fabrics.Add(fabric);
        }

        public void RemoveItem(Fabric fabric)
        {
            Fabrics.Remove(fabric);
        }

        public void Check()
        {
            if(Fabrics.Count() > 10)
            {
                this.State = "Working";
            }
        }
        new public void AddObserver(IObserverDiver observer)
        {
            Observers.Add(observer);
        }

        new public void DelObserver(IObserverDiver observer)
        {
            Observers.Remove(observer);
        }

        new void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.UpdateMW(this);
            }
        }

    }
}

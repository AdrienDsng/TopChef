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
    //<summary>
    //Class DishWasher : class to represent DishWasher in the kitchen
    //<summary>
    public class DishWasher : Machine, IObservableByDiver
    {
        //<summary>
        //List with all dish
        //<summary>
        public List<IDish> Dishes { get; set ; }
        new public List<IObserverDiver> Observers { get; set; }
        public static Semaphore semaphore = new Semaphore(0, 1);
        public int maxCuttelry = 24;
        public int maxGlass = 24;
        public int maxPlate = 24;
        public int waitTime = 10;

        public DishWasher(Position position) : base(position)
        {
            Dishes = new List<IDish>();
            Observers = new List<IObserverDiver>();
            this.Name = "DishWasher";
            this.IsStatic = false;
            this.Capacity = 72;
            this.WorkingTime = 8;
        }

        public void AddItem(IDish dish)
        {
            Dishes.Add(dish);
        }

        public void RemoveItem(IDish dish)
        {
            Dishes.Remove(dish);
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
                observer.UpdateMD(this);
            }
        }
    }
}

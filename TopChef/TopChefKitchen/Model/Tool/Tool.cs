using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Recipe;

namespace TopChefKitchen.Model.Tool
{
    class Tool : ITool, INamed , IStatic, IState, IWashable , IObservable
    {
        public int Quantity { get ; set ; }
        public string Size { get ; set ; }
        public Position Position { get ; set ; }
        public bool IsStatic { get ; set ; }
        public string Name { get ; set ; }
        public string State { get ; set ; }
        public bool IsDirty { get ; set ; }
        public Preparation Preparation { get ; set ; }
        public List<IObserverChief> Observers { get ; set ; }

        public Tool(string name ,position.Position position)
        {
            Name = name;
            Position = position;
            Quantity = 1;
            Size = "Small";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }
        public Tool( position.Position position)
        {
            Name = "Fork";
            Position = position;
            Quantity = 1;
            Size = "Small";
            State = "Standby";
            IsStatic = false;
            IsDirty = false;
        }

        public void AddObserver(IObserverChief observer)
        {
            Observers.Add(observer);
        }

        public void DelObserver(IObserverChief observer)
        {
            Observers.Remove(observer);
        }

        public void GetPreparation(Preparation preparation)
        {
            this.Preparation = preparation;
        }

        public void Move(Position position)
        {
            Position = position;
        }

        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update(State);
            }
        }
    }
}

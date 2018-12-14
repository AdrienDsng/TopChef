using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Interface
{
    interface IObservable
    {
        List<IObserverChief> Observers { get; set; }
        void AddObserver(IObserverChief observer);
        void DelObserver(IObserverChief observer);        
        void Notify();
    }
}

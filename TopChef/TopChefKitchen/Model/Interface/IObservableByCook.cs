using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Interface
{
    interface IObservableByCook
    {
        void AddObserver(IObserverCook observer);
        void DelObserver(IObserverCook observer);
        void Notify();
    }
}

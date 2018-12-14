using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Interface
{
    interface IObservable
    {
        
        void AddObserver(IObserver observer);
        void DelObserver(IObserver observer);
        void Notify();
    }
}

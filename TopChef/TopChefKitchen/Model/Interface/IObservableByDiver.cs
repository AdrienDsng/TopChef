using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Interface
{
    public interface IObservableByDiver
    {
        void AddObserver(IObserverDiver observer);
        void DelObserver(IObserverDiver observer);
        void Notify();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Person;

namespace TopChefKitchen.Model.Interface
{
    //<summary>
    //Interface to Observe Obervable Class for the KitchenChief
    //<summary>
    public interface IObserverChief 
    {
        void Update(string state, Cook cook, Stock stock);
    }
}

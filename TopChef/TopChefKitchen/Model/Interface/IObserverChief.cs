using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Person;

namespace TopChefKitchen.Model.Interface
{
    interface IObserverChief 
    {
        void Update(string state, Cook cook);
    }
}

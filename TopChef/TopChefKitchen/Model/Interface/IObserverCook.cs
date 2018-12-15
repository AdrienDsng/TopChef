using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Machines;

namespace TopChefKitchen.Model.Interface
{
    //<summary>
    //Interface to Observe Obervable Class for the Cook
    //<summary>
    interface IObserverCook
    {
       void Update(string state, Machine machine);       
    }
}

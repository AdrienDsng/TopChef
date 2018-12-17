using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Machines;

namespace TopChefKitchen.Model.Interface
{
    //<summary>
    //Interface to Observe Obervable Class for the DishWasherDiver
    //<summary>
    public interface IObserverDiver 
    {
        void Update(string state, Tool.Tool tool);
        void UpdateMW(WashMachine machine);
        void UpdateMD(DishWasher machine);
    }
}

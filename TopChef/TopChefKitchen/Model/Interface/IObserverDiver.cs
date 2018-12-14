using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Machines;

namespace TopChefKitchen.Model.Interface
{
    interface IObserverDiver
    {
        void Update(string state, Tool.Tool tool, Tap tap);
    }
}

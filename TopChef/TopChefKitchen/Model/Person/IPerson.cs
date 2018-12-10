using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Personn
{
    interface IPerson
    {
        int WorkingTime { get; set; }
        bool IsAlive { get; set; }

        void Arrive();
        void Leave();
    }
}

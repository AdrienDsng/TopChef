using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projettopchef.Kitchen.Model.Personn
{
    interface IPersonn
    {
        int WorkingTime { get; set; }
        bool IsAlive { get; set; }

        void Arrive();
        void Leave();
    }
}

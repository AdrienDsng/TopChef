using projettopchef.Kitchen.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projettopchef.Kitchen.Model.Machines
{
    interface IMachine
    {
        int Capacity { get; set; }
        int WaitTime { get; set; }

        void on();
        void off();
        void addItem(INamed name);
        void removeItem(INamed name);
    }
}

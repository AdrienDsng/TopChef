using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;

namespace TopChefKitchen.Model.Machines
{
    interface IMachine
    {
        int Capacity { get; set; }
        int WorkingTime { get; set; }

        void on();
        void off();
        void addItem(INamed name);
        void removeItem(INamed name);
    }
}

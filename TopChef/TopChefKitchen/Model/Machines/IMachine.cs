using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;

namespace TopChefKitchen.Model.Machines
{
    public interface IMachine
    {
        int Capacity { get; set; }
        int WorkingTime { get; set; }

        void On();
        void Off();
        void IsWorking();
        void ReadyToStart(Tool.Tool tool);

    }
}

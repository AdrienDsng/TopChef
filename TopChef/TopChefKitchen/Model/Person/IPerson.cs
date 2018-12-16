using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Person
{
    /// <summary>
    /// interface for all person object adding worktime IsAlive and tool attributes
    /// </summary>
    public interface IPerson
    {
        int WorkingTime { get; set; }
        bool IsAlive { get; set; }
        Tool.Tool Tool { get; set; }

        void Arrive();
        void Leave();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Machines
{
    class Machine : IMachine, IState, IStatic, INamed, IPosition
    {
   
        public int Capacity { get ; set; }
        public int WorkingTime { get ; set ; }
        public bool IsStatic { get; set; }
        public string State { get ; set; }
        public string Name { get ; set ; }
        public Position Position { get ; set; }

        public Machine(Position position, string name)
        {
            this.Position = position;
            this.Capacity = 1;
            this.WorkingTime = 5;
            this.IsStatic = false;
            this.Name = "Machine";
            on();
        }

        public Machine(Position position)
        {
            Position = position;
            on();
        }

        public void off()
        {
            this.State = "off";
        }

        public void on()
        {
            this.State = "standby";
        }

        public void isWorking()
        {
            this.State = "IsWorking";
        }

        public void move(Position position)
        {
            throw new NotImplementedException();
        }
    }
}

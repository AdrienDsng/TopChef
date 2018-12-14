using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Person
{
    class Person : IPerson , INamed, IPosition,IState, IStatic
    {
        public int WorkingTime { get ; set ; }
        public bool IsAlive { get ; set ; }
        public bool IsStatic { get; set; }
        public string Name { get ; set ; }
        public string State { get; set; }
        public Position Position { get ; set ; }
        public Tool.Tool Tool { get ; set ; }

        public Person(String name, Position position, int time)
        {
            WorkingTime = time;        
            IsAlive = true;
            IsStatic = false;
            Name = name;
            Arrive();
            Move(position);
            Position = position;
        }
        public Person( Position position, int time)
        {
            WorkingTime = time;
            IsAlive = true;
            IsStatic = false;
            Name = "person";
            Arrive();
            Move(position);
            Position = position;
        }


        public void Arrive()
        {
            State = "Standby";
        }

        public void Leave()
        {
            State = "Gone";
        }

        public void Move(Position position)
        {
            Position = position;
        }
    }
}

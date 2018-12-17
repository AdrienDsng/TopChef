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
    public class Person : IPerson , INamed, IPosition,IState, IStatic
    {
        /// <summary>
        /// setting attributes
        /// </summary>
        public int WorkingTime { get ; set ; }
        public bool IsAlive { get ; set ; }
        public bool IsStatic { get; set; }
        public string Name { get ; set ; }
        public string State { get; set; }
        public Position Position { get ; set ; }
        public Tool.Tool Tool { get ; set ; }

        /// <summary>
        /// constructor setup
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        /// <param name="time"></param>
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

        /// <summary>
        /// changes state of person
        /// </summary>
        public void Arrive()
        {
            State = "Standby";
        }

        /// <summary>
        /// changes state of person
        /// </summary>
        public void Leave()
        {
            State = "Gone";
        }

        /// <summary>
        /// takes position and uses it to change person x and y attributes
        /// </summary>
        /// <param name="position"></param>
        public void Move(Position position)
        {
            Position = position;
        }
    }
}

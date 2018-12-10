using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Personn
{
    class DishWasherDiver : Person
    {
        public DishWasherDiver(string name, Position position, int time) : base(name, position, time)
        {
            IsAlive = true;
            IsStatic = false;
            Arrive();
        }
        public void WashDishes()
        {

        }
        public void takeTool(String name, Position position)
        {
            move(position);
            ToolFactory.GetInstance(name, position);
        }
    }
}

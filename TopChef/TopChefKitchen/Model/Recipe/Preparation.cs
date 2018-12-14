using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Recipe
{
    class Preparation : Recipe, IState, IPosition
    {
        public string State { get ; set ; }
        public Position Position { get ; set; }

        public Preparation(string state)
        {
            this.State = state;
        }

        public void Move(Position position)
        {
            this.Position = position;
        }
    }
}

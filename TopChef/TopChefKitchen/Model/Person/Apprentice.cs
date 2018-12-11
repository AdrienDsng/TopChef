using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Person
{
    class Apprentice : Person
    {
        public Apprentice(string name, Position position, int time) : base(name, position, time)
        {
            IsAlive = true;
            IsStatic = false;
            Arrive();
        }

        public void takeTool(String name, Position position)
        {
            move(new Position(position.X+1,position.Y));
            ToolFactory.GetInstance(name, position);
        }
        public void CutIngredient(Tool.Tool tool)
        {
            throw new NotImplementedException();
        }
        public void PeelIngredient(Tool.Tool tool)
        {
            throw new NotImplementedException();
        }
    }
}

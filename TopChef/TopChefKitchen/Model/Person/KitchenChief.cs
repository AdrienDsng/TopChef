using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.Person;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Personn
{

    class KitchenChief : Person, ICook
    {
        public KitchenChief(string name, Position position, int time) : base(name, position, time)
        {
            IsAlive = true;
            IsStatic = false;           
            Arrive();            
        }

        public void CookIngredient(Tool.Tool tool)
        {
            throw new NotImplementedException();
        }

        public void CookIngredientWithFire(Tool.Tool tool, Machine machine)
        {
            throw new NotImplementedException();
        }

        public void CutIngredient(Tool.Tool tool)
        {
            throw new NotImplementedException();
        }

        public void PeelIngredient(Tool.Tool tool)
        {
            throw new NotImplementedException();
        }

        public void putIngredientInTheFridge(Tool.Tool tool, Machine machine)
        {
            throw new NotImplementedException();
        }

        public void takeTool(String name, Position position)
        {
            move(position);
            ToolFactory.GetInstance(name, position);
        }
    }
}

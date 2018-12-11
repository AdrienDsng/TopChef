using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Person
{
    class Cook : Person
    {
        public Cook(string name, Position position, int time) : base(name, position, time)
        {
            IsAlive = true;
            IsStatic = false;
            Arrive();
        }

        public void CookIngredient(Tool.Tool tool)
        {
            tool.IsDirty = true;
            tool.Preparation.State = "On progress";           
        }

        public void CookIngredientWithFire(Tool.Tool tool, CookingFire machine)
        {
            machine.IsDirty = true;
        }

        public void CutIngredient(Tool.Tool tool)
        {
            tool.IsDirty = true;
        }

        public void PeelIngredient(Tool.Tool tool)
        {
            tool.IsDirty = true;
        }

        public void putIngredientInTheFridge(Tool.Tool tool, Fridge machine)
        {           
            machine.addItem(tool);
            tool.IsDirty = true;
        }

        public void takeTool(String name, Position position)
        {
            move(position);
            ToolFactory.GetInstance(name, position);
        }
    }
}

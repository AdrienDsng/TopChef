using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Person
{
    interface ICook
    {
        void CutIngredient(Tool.Tool tool);
        void PeelIngredient(Tool.Tool tool);
        void CookIngredientWithFire(Tool.Tool tool, Machines.Machine machine);
        void putIngredientInTheFridge(Tool.Tool tool, Machines.Machine machine);
        void CookIngredient(Tool.Tool tool);
        void takeTool(String name);
    }
}

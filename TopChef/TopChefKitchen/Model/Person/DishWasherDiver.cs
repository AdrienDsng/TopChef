using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Personn
{
    class DishWasherDiver : Person
    {
        public DishWasherDiver(string name, Position position, int time) : base(name, position, time)
        {
            IsAlive = true;
            IsStatic = false;
            Arrive();
            move(new Position(10, 10));
        }
        public void WashDishes(ITool tool,Tap tap)
        {
            move(new Position(tap.Position.X + 1, tap.Position.Y));
            takeTimeForwash(tool);
            
        }

        private void takeTimeForwash(ITool tool)
        {
            if (tool.Size == "Big")
            {
                tool.IsDirty = false;
            }
            else
            {
                tool.IsDirty = false;
            }
        }

        public void PutDishInDishWasher(IDish dish, DishWasher machine)
        {
            move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.addItem(dish);
        }
        public void PutFabricInWashMachine(Fabric fabric, WashMachine machine)
        {
            move(new Position(machine.Position.X+1,machine.Position.Y));
            machine.addItem(fabric);
        }

        public void takeTool(String name, Position position)
        {
            move(new Position(position.X + 1, position.Y));
            ToolFactory.GetInstance(name, position);
        }
    }
}

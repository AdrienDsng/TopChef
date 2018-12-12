using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Person
{
    class DishWasherDiver : Person
    {
        public DishWasherDiver(string name, Position position, int time) : base(name, position, time)
        {
            IsAlive = true;
            IsStatic = false;
            Arrive();
            Move(new Position(10, 10));
        }
        public void WashDishes(ITool tool,Tap tap)
        {
            Move(new Position(tap.Position.X + 1, tap.Position.Y));
            TakeTimeForwash(tool);
            
        }

        private void TakeTimeForwash(ITool tool)
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
            Move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.addItem(dish);
        }
        public void PutFabricInWashMachine(Fabric fabric, WashMachine machine)
        {
            Move(new Position(machine.Position.X+1,machine.Position.Y));
            machine.addItem(fabric);
        }
        public void DisposeDishWasher(DishWasher machine)
        {
            Move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.Dishes.Clear();
        }
        public void DisposeWashingMachine(WashMachine machine)
        {
            Move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.Fabrics.Clear();
        }

        public void TakeTool(String name, Position position)
        {
            Move(new Position(position.X + 1, position.Y));
            ToolFactory.GetInstance(name, position);
        }
    }
}

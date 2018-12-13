using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.Material;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Person
{
    class DishWasherDiver : Person, IObserver
    {
        public static Semaphore semaphore = new Semaphore(0, 1);
        public DishWasherDiver( Position position, int time) : base( position, time)
        {
            Name = "DishWasherDiver";
            IsAlive = true;
            IsStatic = false;
            Arrive();
            Move(new Position(10, 10));
        }
        public void WashDishes(ITool tool,Tap tap)
        {
            this.State = "IsWorking";
            Move(new Position(tap.Position.X + 1, tap.Position.Y));
            TakeTimeForwash(tool);
            this.State = "Standby";

        }

        private void TakeTimeForwash(ITool tool)
        {
            if (tool.Size == "Big")
            {
                this.State = "IsWorking";
                Thread.Sleep(60);
                tool.IsDirty = false;
                this.State = "Standby";
            }
            else
            {
                this.State = "IsWorking";
                Thread.Sleep(30);
                tool.IsDirty = false;
                this.State = "Standby";
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
            this.State = "IsWorking";
            Move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.Dishes.Clear();
            Thread.Sleep(60);
            this.State = "Standby";
        }
        public void DisposeWashingMachine(WashMachine machine)
        {
            this.State = "IsWorking";
            Move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.Fabrics.Clear();
            Thread.Sleep(60);
            this.State = "Standby";
        }

        public void TakeTool(String name, Position position)
        {
            Move(new Position(position.X + 1, position.Y));
            ToolFactory.GetInstance(name, position);

        }

        public void Update(string name)
        {
            throw new NotImplementedException();
        }
    }
}

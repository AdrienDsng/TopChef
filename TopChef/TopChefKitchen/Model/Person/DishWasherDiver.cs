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
    /// <summary>
    /// Dishwasher Class
    /// </summary>
    public class DishWasherDiver : Person, IObserverDiver
    {
        public static Semaphore semaphore = new Semaphore(0, 1);
        public Tap Tap { get; set; }

        public DishWasherDiver( Position position, int time, Tap tap) : base( position, time)
        {
            Tap = tap;
            Name = "DishWasherDiver";
            IsAlive = true;
            IsStatic = false;
            Arrive();
            Move(new Position(10, 10));
        }
        /// <summary>
        /// moves to tap and uses it
        /// </summary>
        /// <param name="tool"></param>
        public void WashDishes(ITool tool)
        {
            this.State = "IsWorking";
            Move(new Position(Tap.Position.X + 1, Tap.Position.Y));
            TakeTimeForwash(tool);
            this.State = "Standby";

        }
        /// <summary>
        /// spleeps the time needed to wash dishes
        /// </summary>
        /// <param name="tool"></param>
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
        /// <summary>
        /// moves to tap and adds dish to dishwasher
        /// </summary>
        /// <param name="dish"></param>
        /// <param name="machine"></param>
        public void PutDishInDishWasher(IDish dish, DishWasher machine)
        {
            Move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.AddItem(dish);
        }

        /// <summary>
        /// moves to tap and adds fabric to dishwasher
        /// </summary>
        /// <param name="fabric"></param>
        /// <param name="machine"></param>
        public void PutFabricInWashMachine(Fabric fabric, WashMachine machine)
        {
            Move(new Position(machine.Position.X+1,machine.Position.Y));
            machine.AddItem(fabric);
        }

        /// <summary>
        /// empties dishwasher
        /// </summary>
        /// <param name="machine"></param>
        public void DisposeDishWasher(DishWasher machine)
        {
            this.State = "IsWorking";
            Move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.Dishes.Clear();
            Thread.Sleep(60);
            this.State = "Standby";
        }

        /// <summary>
        /// takes machine and empties it from fabrics
        /// </summary>
        /// <param name="machine"></param>
        public void DisposeWashingMachine(WashMachine machine)
        {
            this.State = "IsWorking";
            Move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.Fabrics.Clear();
            Thread.Sleep(60);
            this.State = "Standby";
        }

        /// <summary>
        /// cf cook
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public void TakeTool(String name, Position position)
        {
            Move(new Position(position.X + 1, position.Y));
            Tool = ToolFactory.GetInstance(name, position);

        }

        /// <summary>
        /// changes state of dishwhaser to ready
        /// </summary>
        /// <param name="machine"></param>
        public void PowerOn(Machine machine)
        {
            machine.State = "ReadyToStart";
        }

        /// <summary>
        /// updates tool state
        /// </summary>
        /// <param name="state"></param>
        /// <param name="tool"></param>
        public void Update(string state, Tool.Tool tool)
        {
            if (tool.IsDirty)
            {
                WashDishes(tool);
            }
        }

        /// <summary>
        /// changes fabric washing mahine state
        /// </summary>
        /// <param name="machine"></param>
        public void UpdateMW(WashMachine machine)
        {
            if (machine.State == "Standby" && this.State == "Standby")
            {               
                        DisposeWashingMachine(machine);             
            }
        }

        /// <summary>
        /// changes dish washing machine state
        /// </summary>
        /// <param name="machine"></param>
        public void UpdateMD(DishWasher machine)
        {
            if (machine.State == "Standby" && this.State == "Standby")
            {
                DisposeDishWasher(machine);
            }
        }
    }
}

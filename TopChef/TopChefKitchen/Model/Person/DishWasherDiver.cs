﻿using System;
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
    class DishWasherDiver : Person, IObserverDiver
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
        public void WashDishes(ITool tool)
        {
            this.State = "IsWorking";
            Move(new Position(Tap.Position.X + 1, Tap.Position.Y));
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
            machine.AddItem(dish);
        }
        public void PutFabricInWashMachine(Fabric fabric, WashMachine machine)
        {
            Move(new Position(machine.Position.X+1,machine.Position.Y));
            machine.AddItem(fabric);
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
            Tool = ToolFactory.GetInstance(name, position);

        }

        public void PowerOn(Machine machine)
        {
            machine.State = "IsWorking";
        }

        public void Update(string state, Tool.Tool tool)
        {
            if (tool.IsDirty)
            {
                WashDishes(tool);
            }
        }
    }
}

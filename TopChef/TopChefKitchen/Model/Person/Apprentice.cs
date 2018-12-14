using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Recipe;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Person
{
    class Apprentice : Person, IObservable
    {
        public static Semaphore semaphore = new Semaphore(0, 1);
        public Step Step { get; set; }
        public string ResourceNeeded { get; set; }
        public string MachineNeeded { get;  set; }
        public string ToolNeeded { get;  set; }
        public Machine MachineUsed { get;  set; }
        public Tool.Tool ToolUsed { get;  set; }

        public Apprentice( Position position, int time) : base( position, time)
        {
            Name = "Apprentice";
            IsAlive = true;
            IsStatic = false;
            Arrive();
        }

        public void CheckIfNeedToolOrMachine()
        {
            switch (Step.Resource_Needed)
            {
                case "Fridge":
                    this.MachineNeeded = "Fridge";
                    this.ToolNeeded = null;
                    break;
                case "Mixer":
                    this.MachineNeeded = "Mixer";
                    this.ToolNeeded = null;
                    break;
                case "CookingFire":
                    this.MachineNeeded = "CookingFire";
                    this.ToolNeeded = null;
                    break;
                case "Oven":
                    this.MachineNeeded = "Oven";
                    this.ToolNeeded = null;
                    break;
                case "CookingKnife":
                    this.ToolNeeded = "Cookingknife";
                    this.MachineNeeded = null;
                    break;

                case "Juicer":
                    this.ToolNeeded = "Juicer";
                    this.MachineNeeded = null;
                    break;

                case "Funnel":
                    this.ToolNeeded = "Funnel";
                    this.MachineNeeded = null;
                    break;

                case "Pan":
                    this.ToolNeeded = "Pan";
                    this.MachineNeeded = null;
                    break;

                case "PressureCooker":
                    this.ToolNeeded = "PressureCooker";
                    this.MachineNeeded = null;
                    break;

                case "SaladBowl":
                    this.ToolNeeded = "SaladBowl";
                    this.MachineNeeded = null;
                    break;

                case "Sieve":
                    this.ToolNeeded = "Sieve";
                    this.MachineNeeded = null;
                    break;

                case "Stove":
                    this.ToolNeeded = "Stove";
                    this.MachineNeeded = null;
                    break;

                case "WoodenSpoon":
                    this.ToolNeeded = "WoodenSpoon";
                    this.MachineNeeded = null;
                    break;


                default:
                    new Tool.Tool(Step.Resource_Needed, new Position(5, 5));
                    break;
            }
        }

        public void TakeTool(String name, Position position)
        {
            this.State = "TakingT";
            Move(new Position(position.X+1,position.Y));
            ToolUsed = ToolFactory.GetInstance(name, position);
            this.State = "Standby";
        }

        public void DoStep(List<Machine> machines, Tool.Tool tool)
        {
            foreach (var value in machines)
            {
                if (value.Name == MachineNeeded)
                {
                    MachineUsed = value;
                }
            }
            if (ToolNeeded == null)
            {
                UseMachine(MachineUsed, new Position(MachineUsed.Position.X, MachineUsed.Position.Y));
            }
            else if (MachineNeeded == null)
            {
                TakeTool(tool.Name, new Position(tool.Position.X, tool.Position.Y + 1));
            }
        }

        private void UseMachine(Machine machine, Position position)
        {
            this.State = "IsWorking";
            Move(new Position(machine.Position.X, machine.Position.Y + 1));
            machine.ReadyToStart(ToolUsed);
            this.State = "Standby";
        }

        public void AddObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void DelObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}

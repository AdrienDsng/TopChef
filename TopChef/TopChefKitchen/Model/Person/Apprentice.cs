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
    /// <summary>
    /// Cook interface used to instancitate up to 2 apprentices
    /// </summary>
    public class Apprentice : Person, IObservableByCook
    {
        /// <summary>
        /// set up all attributes
        /// </summary>
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

        /// <summary>
        /// checks dependid of it's needs if a machine is needed
        /// </summary>
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

        /// <summary>
        /// by passing a tool the apprentice can be rlated to the tool
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public void TakeTool(String name, Position position)
        {
            this.State = "TakingT";
            Move(new Position(position.X+1,position.Y));
            ToolUsed = ToolFactory.GetInstance(name, position);
            this.State = "Standby";
        }

        /// <summary>
        /// uses a machine or a tool to bring the recipe on step +1 and
        /// set the recipe on the new step
        /// </summary>
        /// <param name="machines"></param>
        /// <param name="tool"></param>
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

        /// <summary>
        /// move the apprentice to the machine location and sets its state to Standby
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="position"></param>
        private void UseMachine(Machine machine, Position position)
        {
            this.State = "IsWorking";
            Move(new Position(machine.Position.X, machine.Position.Y + 1));
            machine.ReadyToStart(ToolUsed);
            this.State = "Standby";
        }
        /// <summary>
        /// adds a new observer
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver(IObserverCook observer)
        {
            
        }

        /// <summary>
        /// deletes the previous added obserber
        /// </summary>
        /// <param name="observer"></param>
        public void DelObserver(IObserverCook observer)
        {
            
        }
        /// <summary>
        /// method used to notify the observer that a taks is finished
        /// </summary>
        public void Notify()
        {
            throw new NotImplementedException();
        }
    }
}

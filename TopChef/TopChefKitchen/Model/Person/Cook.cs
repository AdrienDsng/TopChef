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
    class Cook : Person, IObservable
    {
        public static Semaphore semaphore = new Semaphore(0, 2);

        public List<IObserver> Observers { get ; set ; }
        public Recipe.Recipe Recipe { get; set; }
        public Step ActualStep { get; set; }
        private String MachineNeeded { get; set; }
        private String ToolNeeded { get; set; }
        private int ActualNbStep { get; set; }
        private Tool.Tool ToolUsed { get; set; }
        private Machine MachineUsed { get; set; }

        public Cook( Position position, int time) : base( position, time)
        {
            
            Name = "Cook";
            IsAlive = true;
            IsStatic = false;
            ActualNbStep = 0;
            ToolUsed = new Tool.Tool(new Position(50,50));
            Arrive();
        }

        public void CheckIfNeedToolOrMachine()
        {
            switch (ActualStep.Resource_Needed)
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
                    new Tool.Tool(ActualStep.Resource_Needed, new Position(5, 5));
                    break;
            }
        }

        public void MakeRecipe(List<Machine> machines)
        {
            
            foreach (var value in Recipe.Steps)
            {               
                CheckIfNeedToolOrMachine();
                DoStep(machines, ToolFactory.GetInstance(ActualStep.Resource_Needed, new Position(50, 50)));
                NextStep();
            }
        }

        public void DoStep(List<Machine> machines , Tool.Tool tool)
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
                foreach (var value in machines)
                {
                    if (value.Name == "CookingTable" && value.State == "Standby")
                    {
                        MachineUsed = value;
                    }

                }
                TakeTool(tool.Name, new Position(tool.Position.X, tool.Position.Y+1));
                UseMachine(MachineUsed, new Position(MachineUsed.Position.X, MachineUsed.Position.Y));
            }
        }

        private void UseMachine(Machine machine, Position position)
        {
            this.State = "IsWorking";
            Move(new Position(machine.Position.X, machine.Position.Y+1));
            machine.ReadyToStart(ToolUsed);
            this.State = "Standby";
        }

        public void GiveStepToApprentice(Apprentice apprentice)
        {
            apprentice.Step = ActualStep;           
            apprentice.ResourceNeeded = ActualStep.Resource_Needed;            
            NextStep();
        }

        public void NextStep()
        {
            ActualNbStep++;
            ActualStep = Recipe.Steps[ActualNbStep];
        }
              
        public void TakeTool(String name, Position position)
        {
            this.State = "IsWorking";
            Move(new Position(position.X + 1, position.Y));
            Tool = ToolFactory.GetInstance(name, position);
            this.State = "Standby";
        }
       
        public void AddObserver(IObserver observer)
        {
            Observers.Add(observer);
        }

        public void DelObserver(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update(State);
            }
            
        }
    }
}

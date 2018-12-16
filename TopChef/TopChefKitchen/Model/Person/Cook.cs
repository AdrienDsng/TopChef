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
    public class Cook : Person, IObservableByChief, IObserverCook
    {
        /// <summary>
        /// Class used to instanciate up to 2 cooks
        /// </summary>
        public static Semaphore semaphore = new Semaphore(0, 2);

        /// <summary>
        /// setting up the attributes
        /// </summary>
        public List<IObserverChief> Observers { get ; set ; }
        public Recipe.Recipe Recipe { get; set; }
        public Step ActualStep { get; set; }
        private String MachineNeeded { get; set; }
        private String ToolNeeded { get; set; }
        private int ActualNbStep { get; set; }
        private Tool.Tool ToolUsed { get; set; }
        private Machine MachineUsed { get; set; }
        private Stock Stock { get; set; }

       
        /// <summary>
        /// constructor of cook
        /// </summary>
        /// <param name="position"></param>
        /// <param name="time"></param>
        public Cook( Position position, int time) : base( position, time)
        {
            Observers = new List<IObserverChief>();
            Name = "Cook";
            IsAlive = true;
            IsStatic = false;
            ActualNbStep = 0;
            ToolUsed = new Tool.Tool(new Position(50,50));
            Arrive();
        }

        /// <summary>
        /// checks dependid of it's needs if a machine is needed
        /// </summary>
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

        /// <summary>
        /// iterates into each step and uses tool or machine to pass to step +1
        /// </summary>
        /// <param name="machines"></param>
        public void MakeRecipe(List<Machine> machines)
        {
            
            foreach (var value in Recipe.Steps)
            {               
                CheckIfNeedToolOrMachine();
                DoStep(machines, ToolFactory.GetInstance(ActualStep.Resource_Needed, new Position(50, 50)));

                NextStep();
            }
            
            Notify();
            
        }

        /// <summary>
        /// passes to step +1 with tool or machine
        /// </summary>
        /// <param name="machines"></param>
        /// <param name="tool"></param>
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

        /// <summary>
        /// set own state on working and goes to the machine to use it
        /// </summary>
        /// <param name="machine"></param>
        /// <param name="position"></param>
        private void UseMachine(Machine machine, Position position)
        {
            this.State = "IsWorking";
            Move(new Position(machine.Position.X, machine.Position.Y+1));
            machine.ReadyToStart(ToolUsed);
            this.State = "Standby";
        }

        /// <summary>
        /// state to working and moves the cook to the fridg
        /// sets the fridge using time to the time allowed for the fridge
        /// </summary>
        /// <param name="fridge"></param>
        private void PutInFridge(Fridge fridge)
        {
            this.State = "IsWorking";
            Move(new Position(fridge.Position.X, fridge.Position.Y + 1));
            ToolUsed.State = "IsWorking";
            fridge.ReadyToStart(ToolUsed,ActualStep.Wait_Time);
            this.State = "Standby";
        }

        /// <summary>
        /// delegates one step to the apprentice person
        /// </summary>
        /// <param name="apprentice"></param>
        public void GiveStepToApprentice(Apprentice apprentice)
        {
            apprentice.Step = ActualStep;           
            apprentice.ResourceNeeded = ActualStep.Resource_Needed;            
            NextStep();
        }
        
        /// <summary>
        /// passes to step +1
        /// </summary>
        public void NextStep()
        {
            ActualNbStep++;
            ActualStep = Recipe.Steps[ActualNbStep];
        }
        
        /// <summary>
        /// bond a tool to a cook for it to complete a step
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public void TakeTool(String name, Position position)
        {
            this.State = "IsWorking";
            Move(new Position(position.X + 1, position.Y));
            Tool = ToolFactory.GetInstance(name, position);
            this.State = "Standby";
        }
        
        /// <summary>
        /// notify the observer that a recipe is finished
        /// </summary>
        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update("Standby",this, Stock);
            }
            
        }

        /// <summary>
        /// adds an observer
        /// </summary>
        /// <param name="observer"></param>
        public void AddObserver(IObserverChief observer)
        {
            Observers.Add(observer);
        }

        /// <summary>
        /// deletes an observer
        /// </summary>
        /// <param name="observer"></param>
        public void DelObserver(IObserverChief observer)
        {
            Observers.Remove(observer);
        }

        /// <summary>
        /// is updated by apprentice that a given step is finished
        /// </summary>
        /// <param name="state"></param>
        /// <param name="machine"></param>
        public void Update(string state, Machine machine)
        {         
                if (machine.State == "Standby" && this.State == "Standby")
                {
                MachineUsed.State = "Standby";
                }                   
        }
    }
}

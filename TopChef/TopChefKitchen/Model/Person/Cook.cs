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

        public Cook( Position position, int time) : base( position, time)
        {
            Name = "Cook";
            IsAlive = true;
            IsStatic = false;
            Arrive();
        }

        public void CookIngredient(Tool.Tool tool, Step step, Position position)
        {
            this.State = "IsWorking";
            Move(new Position(position.X + 1, position.Y));
            tool.IsDirty = true;
            tool.Preparation.State = "IsWorking";
            Thread.Sleep(step.Wait_Time);
            this.State = "Standby";
        }

        public void CookIngredientWithFire(Tool.Tool tool, CookingFire machine, Step step)
        {
            this.State = "IsWorking";
            Move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.IsDirty = true;
            Thread.Sleep(step.Wait_Time);
            this.State = "Standby";
        }

        public void PutIngredientInTheFridge(Tool.Tool tool, Fridge machine)
        {
            this.State = "IsWorking";
            Move(new Position(machine.Position.X + 1, machine.Position.Y));
            machine.AddItem(tool);
            tool.IsDirty = true;
            this.State = "Standby";
        }

        public void TakeTool(String name, Position position)
        {
            this.State = "IsWorking";
            Move(new Position(position.X + 1, position.Y));
            ToolFactory.GetInstance(name, position);
            this.State = "Standby";
        }

        public void CutIngredient(Tool.Tool tool, CookingTable table, Step step)
        {
            this.State = "IsWorking";
            Move(new Position(table.Position.X + 1, table.Position.Y));
            tool.IsDirty = true;
            Thread.Sleep(step.Wait_Time);
            this.State = "Standby";
        }

        public void PeelIngredient(Tool.Tool tool, CookingTable table, Step step)
        {
            this.State = "IsWorking";
            Move(new Position(table.Position.X + 1, table.Position.Y));
            tool.IsDirty = true;
            Thread.Sleep(step.Wait_Time);
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

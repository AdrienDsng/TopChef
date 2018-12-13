using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Machines;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen.Model.Person
{
    class Cook : Person, IObservable
    {
        public static Semaphore semaphore = new Semaphore(0, 2);

        public List<IObserver> Observers { get ; set ; }

        public Cook(string name, Position position, int time) : base(name, position, time)
        {
            IsAlive = true;
            IsStatic = false;
            Arrive();
        }

        public void CookIngredient(Tool.Tool tool)
        {
            tool.IsDirty = true;
            tool.Preparation.State = "On progress";           
        }

        public void CookIngredientWithFire(Tool.Tool tool, CookingFire machine)
        {
            machine.IsDirty = true;
        }



        public void PutIngredientInTheFridge(Tool.Tool tool, Fridge machine)
        {           
            machine.addItem(tool);
            tool.IsDirty = true;
        }

        public void TakeTool(String name, Position position)
        {
            Move(new Position(position.X + 1, position.Y));
            ToolFactory.GetInstance(name, position);
        }
        public void CutIngredient(Tool.Tool tool, CookingTable table)
        {
            Move(new Position(table.Position.X + 1, table.Position.Y));
            tool.IsDirty = true;
        }
        public void PeelIngredient(Tool.Tool tool, CookingTable table)
        {
            Move(new Position(table.Position.X + 1, table.Position.Y));
            tool.IsDirty = true;
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

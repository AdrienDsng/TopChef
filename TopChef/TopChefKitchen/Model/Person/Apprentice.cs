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
    class Apprentice : Person, IObserver
    {
        public static Semaphore semaphore = new Semaphore(0, 1);

        public Apprentice( Position position, int time) : base( position, time)
        {
            Name = "Apprentice";
            IsAlive = true;
            IsStatic = false;
            Arrive();
        }

        public void TakeTool(String name, Position position)
        {
            this.State = "IsWorking";
            Move(new Position(position.X+1,position.Y));
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

        public void Update(string name)
        {
            throw new NotImplementedException();
        }
    }
}

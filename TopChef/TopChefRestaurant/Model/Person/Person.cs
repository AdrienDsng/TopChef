using System.Collections.Generic;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Interfaces;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Model.Person
{
    public class Person : IPerson, IDisplayable, IState, IStatic, INamed
    {
        public int WorkingTime { get; set; }
        public bool Available { get; set; }
        
        public void Arrive()
        {
            throw new System.NotImplementedException();
        }

        public void Leave()
        {
            throw new System.NotImplementedException();
        }

        public bool IsAlive()
        {
            throw new System.NotImplementedException();
        }

        public string Sprite { get; set; }
        public Position Position { get; set; }
        public string State { get; set; }
        public bool IsStatic { get; set; }
        public string Name { get; set; }
        public IAction CurrentAction { get; set; }
        
        private Queue<IAction> ActionsList = new Queue<IAction>();

        public void AddAction(IAction action) => ActionsList.Enqueue(action);
        public void NextAction() => CurrentAction = ActionsList.Dequeue();

        public bool HasActionLeft()
        {
            return ActionsList.Count >= 1;
        }

        public int GetRemainingWorkingTime()
        {
            int remaining = 0;
            if(CurrentAction != null)
                remaining += CurrentAction.RemainingTime;
            foreach (var action in ActionsList)
            {
                remaining += action.RemainingTime;
            }

            return remaining;
        }

        public Person(string name, Position position)
        {
            this.Name = name;
            this.Position = position;
            this.Available = true;
        }
    }
}
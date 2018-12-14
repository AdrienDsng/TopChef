using System.Collections.Generic;
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Interfaces;
using TopChefRestaurant.Model.Positions;
using TopChefRestaurant.View;

namespace TopChefRestaurant.Model.Person
{
    public class Person : IDisplayable, INamed
    {
        public bool Available { get; set; }
        public string Name { get; set; }
        public IAction CurrentAction { get; set; }
        public string Sprite { get; set; }
        private Position _position;
        private Queue<IAction> ActionsList = new Queue<IAction>();
        private RestaurantView _restaurantView;
        
        public Position Position
        {
            get { return _position; }
            set
            {
                _position = value;
                Program.RestaurantView.ChangePosition(this);
            }
        }

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
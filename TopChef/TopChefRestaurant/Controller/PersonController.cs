using System.Collections.Generic;
using System.Linq;
using TopChefRestaurant.Controller.Actions;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Controller
{
    public class PersonController
    {
        private List<IAction> _runningActions = new List<IAction>();
        private Queue<IAction> _actionsNotAttributed = new Queue<IAction>();
        private List<Person> _restaurantEmployees = new List<Person>();

        public PersonController()
        {
            _restaurantEmployees.Add(new Apprentice("Jacquie", new Position(0, 0)));
            _restaurantEmployees.Add(new HotelMaster("Jean-Jacque", new Position(0, 0)));
            _restaurantEmployees.Add(new RowChief("Adrien", new Position(0, 0)));
            _restaurantEmployees.Add(new RowChief("Paulo", new Position(0, 0)));
            _restaurantEmployees.Add(new Waiter("Mathieu", new Position(0, 0)));
            _restaurantEmployees.Add(new Waiter("Nico", new Position(0, 0)));
            _restaurantEmployees.Add(new Waiter("Pogba", new Position(0, 0)));
            _restaurantEmployees.Add(new Waiter("Jacqueline", new Position(0, 0)));
            _restaurantEmployees.Add(new Apprentice("Dodo l'escabo", new Position(0, 0)));
        }
        
        public void MainLoop()
        {
            AttributeActions();
            RunActions();
            ChangeRunningActions();
        }

        private void AttributeActions()
        {
            bool shouldBreak = false;
            foreach (IAction action in _actionsNotAttributed)
            {
                foreach (Person employee in _restaurantEmployees)
                {
                    if (action.CanRealize(employee))
                    {
                        employee.AddAction(action);
                        shouldBreak = true;
                        break;
                    }
                }
                if (shouldBreak) break;
            }
        }

        private void RunActions()
        {
            foreach (IAction action in _runningActions.ToList())
            {
                if (action.DecreaseTime() == 0)
                {
                    _runningActions.Remove(action);
                    action.Employee.Available = true;
                    action.Employee.CurrentAction = null;
                }
            }
        }

        private void ChangeRunningActions()
        {
            foreach (Person employee in _restaurantEmployees)
            {
                if (employee.Available && employee.HasActionLeft())
                {
                    employee.NextAction();
                    employee.Available = false;
                    _runningActions.Add(employee.CurrentAction);
                }
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Controller
{
    public class PersonController
    {
        private List<IAction> _runningActions = new List<IAction>();
        private List<IAction> _actionsNotAttributed = new List<IAction>();
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
            foreach (IAction action in _actionsNotAttributed.ToList())
            {
                Person bestMatch = null;

                foreach (Person employee in _restaurantEmployees)
                {
                    if (!action.CanRealize(employee)) continue;
                    
                    if (bestMatch == null)
                        bestMatch = employee;
                    else if (bestMatch.GetRemainingWorkingTime() > employee.GetRemainingWorkingTime())
                        bestMatch = employee;
                }

                if (bestMatch != null)
                {
                    bestMatch.AddAction(action);
                    _actionsNotAttributed.Remove(action);
                    action.Employee = bestMatch;
                }
            }
        }

        private void RunActions()
        {
            foreach (IAction action in _runningActions.ToList())
            {
                if (action.DecreaseTime() != 0) continue;
                
                _runningActions.Remove(action);
                action.Employee.Available = true;
                action.Employee.CurrentAction = null;
            }
        }

        private void ChangeRunningActions()
        {
            foreach (Person employee in _restaurantEmployees)
            {
                if (!employee.Available || !employee.HasActionLeft()) continue;
                
                employee.NextAction();
                employee.Available = false;
                _runningActions.Add(employee.CurrentAction);
            }
        }

        public void AddAction(IAction action) => _actionsNotAttributed.Add(action);
    }
}
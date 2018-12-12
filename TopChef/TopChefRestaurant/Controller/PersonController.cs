using System.Collections.Generic;
using System.Linq;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;
using TopChefRestaurant.View;
using Apprentice = TopChefRestaurant.Model.Person.Apprentice;
using HotelMaster = TopChefRestaurant.Model.Person.HotelMaster;
using RowChief = TopChefRestaurant.Model.Person.RowChief;
using Waiter = TopChefRestaurant.Model.Person.Waiter;

namespace TopChefRestaurant.Controller
{
    /// <summary>
    /// Controller managing all the employee
    /// </summary>
    public class PersonController
    {
        private List<IAction> _runningActions = new List<IAction>();
        private List<IAction> _actionsNotAttributed = new List<IAction>();
        private List<Person> _restaurantEmployees = new List<Person>();
        private RestaurantView _restaurantView;
        
        /// <summary>
        /// Person controller constructor
        /// </summary>
        public PersonController(RestaurantView restaurantView)
        {
            this._restaurantView = restaurantView;
            
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
        
        /// <summary>
        /// Main loop called from the restaurant controller
        /// </summary>
        public void MainLoop()
        {
            AttributeActions();
            RunActions();
            ChangeRunningActions();
        }

        /// <summary>
        /// Attribute an action to an employee
        /// </summary>
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

        /// <summary>
        /// Run all employee's current actions
        /// </summary>
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

        /// <summary>
        /// Change the current action for an employee
        /// </summary>
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
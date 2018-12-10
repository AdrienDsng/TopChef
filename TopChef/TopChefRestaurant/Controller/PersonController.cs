using System.Collections.Generic;
using TopChefRestaurant.Controller.Actions;

namespace TopChefRestaurant.Controller
{
    public class PersonController
    {
        private List<IAction> RunningActions = new List<IAction>();
        private Queue<IAction> ActionsNotAttributed = new Queue<IAction>();

        public void MainLoop()
        {
            
        }
    }
}
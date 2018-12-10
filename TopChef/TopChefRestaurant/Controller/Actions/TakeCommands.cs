using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Controller.Actions
{
    public class TakeCommands : Action, IAction
    {

        public TakeCommands() : base(60)
        {
        }
        public void Realize(object o)
        {
            throw new System.NotImplementedException();
        }

        public int Time { get; }
        public bool CanRealize(object person)
        {
            return person is RowChief;
        }
    }
}
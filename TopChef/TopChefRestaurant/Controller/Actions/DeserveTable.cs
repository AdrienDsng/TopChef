using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Controller.Actions
{
    public class DeserveTable : Action, IAction
    {
        
        public DeserveTable() : base(60)
        {
        }
        public void Realize(object o)
        {
            throw new System.NotImplementedException();
        }

        public int Time { get; }
        public bool CanRealize(object person)
        {
            return person is Waiter;
        }

    }
}
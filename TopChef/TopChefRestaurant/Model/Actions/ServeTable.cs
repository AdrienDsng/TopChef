using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class ServeTable : Action, IAction
    {
        public ServeTable() : base(30)
        {
        }
        
        public override void Realize()
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
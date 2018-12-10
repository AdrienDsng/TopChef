using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Controller.Actions
{
    public class WelcomeClient : Action, IAction
    {
        
        public WelcomeClient() : base(20)
        {
        }
        public void Realize(object o)
        {
            throw new System.NotImplementedException();
        }

        public bool CanRealize(object person)
        {
            return person is HotelMaster;
        }

        public int Time { get; }

    }
}
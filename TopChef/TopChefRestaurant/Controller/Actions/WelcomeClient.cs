using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Controller.Actions
{
    public class WelcomeClient : IAction
    {
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
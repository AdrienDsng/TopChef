using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class WelcomeClient : Action, IAction
    {
        
        public WelcomeClient() : base(20)
        {
        }
        public override void Realize()
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
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Controller.Actions
{
    public class AssignClient : Action, IAction
    {
        public AssignClient() : base(30)
        {
        }
        public void Realize(object o)
        {
            throw new System.NotImplementedException();
        }

        public int Time { get; }
        public bool CanRealize(object person)
        {
            return person is HotelMaster;
        }

    }
}
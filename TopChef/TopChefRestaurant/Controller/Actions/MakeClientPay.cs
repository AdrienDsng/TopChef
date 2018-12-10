using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Controller.Actions
{
    public class MakeClientPay : Action, IAction
    {
        
        public MakeClientPay() : base(20)
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
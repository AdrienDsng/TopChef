using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class TakeCommands : Action, IAction
    {

        public TakeCommands() : base(60)
        {
        }
        public override void Realize()
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
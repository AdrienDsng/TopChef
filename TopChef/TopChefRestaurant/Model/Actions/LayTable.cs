using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class LayTable : Action, IAction
    {
        
        public LayTable() : base(60)
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
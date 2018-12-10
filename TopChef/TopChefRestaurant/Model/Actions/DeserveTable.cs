using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class DeserveTable : Action, IAction
    {
        private Table Table;
        public DeserveTable(Table table) : base(60)
        {
            this.Table = table;
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
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class RefreshWater : Action, IAction
    {
        private Table Table { get; set; }
        public RefreshWater(Table table) : base(30)
        {
            this.Table = table;
        }
        public override void Realize()
        {
            Table.HasWater = true;
        }

        public bool CanRealize(object person)
        {
            return person is Apprentice;
        }

    }
}
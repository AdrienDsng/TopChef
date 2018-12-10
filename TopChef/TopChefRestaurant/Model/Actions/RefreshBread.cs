using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class RefreshBread : Action, IAction
    {
        private Table Table { get; set; }
        public RefreshBread(Table table) : base(30)
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
            return person is Apprentice;
        }

    }
}
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class RefreshBread : Action, IAction
    {
        public Table Table { get; set; }
        
        public RefreshBread(Table table) : base(30)
        {
            this.Table = table;
        }
        public override void Realize()
        {
            Table.HasBread = true;
            LogController.Log(new Event(this));
        }

        public bool CanRealize(object person)
        {
            return person is Apprentice;
        }

    }
}
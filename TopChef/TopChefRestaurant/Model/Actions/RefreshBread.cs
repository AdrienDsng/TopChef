using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Model.Actions
{
    public class RefreshBread : Action, IAction
    {
        public Table Table { get; set; }
        
        public RefreshBread(Table table) : base(30)
        {
            this.Table = table;
            this.Position = new Position(Table.Position.X + 1, Table.Position.Y);
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

        public Position Position { get; set; }
    }
}
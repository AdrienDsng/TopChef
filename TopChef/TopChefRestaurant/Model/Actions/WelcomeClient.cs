using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class WelcomeClient : Action, IAction
    {
        private Client Client { get; set; }
        private TableController TableController { get; set; }
        
        public WelcomeClient(Client client, TableController tableController) : base(20)
        {
            this.Client = client;
            this.TableController = tableController;
        }
        public override void Realize()
        {
            TableController.AssignTable(Client);
        }

        public bool CanRealize(object person)
        {
            return person is HotelMaster;
        }
    }
}
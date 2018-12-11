using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class WelcomeClient : Action, IAction
    {
        public Client Client { get; set; }
        private TableController TableController { get; set; }
        
        public WelcomeClient(Client client, TableController tableController) : base(20)
        {
            this.Client = client;
            this.TableController = tableController;
        }
        public override void Realize()
        {
            TableController.AssignTable(Client);
            LogController.Log(new Event(this));
        }

        public bool CanRealize(object person)
        {
            return person is HotelMaster;
        }
    }
}
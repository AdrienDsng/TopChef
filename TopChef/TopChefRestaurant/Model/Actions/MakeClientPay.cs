using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class MakeClientPay : Action, IAction
    {
        public Client Client;
        private ClientController _clientController;
        
        public MakeClientPay(Client client, ClientController clientController) : base(20)
        {
            this.Client = client;
            this._clientController = clientController;
        }
        
        public override void Realize()
        {
            _clientController.RemoveClient(Client);
            LogController.Log(new Event(this));
        }

        public bool CanRealize(object person)
        {
            return person is HotelMaster;
        }
    }
}
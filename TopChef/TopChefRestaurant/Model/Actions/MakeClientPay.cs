using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

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
            this.Position = new Position(Client.Position.X + 1, Client.Position.Y);
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

        public Position Position { get; set; }
    }
}
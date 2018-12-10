using System;
using System.Collections.Generic;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Controller
{
    public class ClientController
    {
        private List<Client> _clients = new List<Client>();
        private PersonController _personController;
        private TableController _tableController;
        
        public ClientController(PersonController personController, TableController tableController)
        {
            _personController = personController;
         
            Client client = new Client("Michel et sa famille", new Position(0, 0));
            _clients.Add(client);
            _personController.AddAction(new WelcomeClient(client, _tableController));
        }

        public void MainLoop()
        {
            GenerateNewClient();
        }

        private void GenerateNewClient()
        {
            Random random = new Random();
            if (random.Next(60 * 10) != 0) return;
            
            Client client = new Client($"Client {random.Next(1000)}", new Position(0, 0));
            _clients.Add(client);
            _personController.AddAction(new WelcomeClient(client, _tableController));
        }

        public void RemoveClient(Client client)
        {
            this._clients.Remove(client);
        }
    }
}
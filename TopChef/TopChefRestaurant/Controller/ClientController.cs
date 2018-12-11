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
            _tableController = tableController;
            
            Client client = new Client("Michel et sa famille", new Position(0, 0));
            _clients.Add(client);
            _personController.AddAction(new WelcomeClient(client, _tableController));
        }

        public void MainLoop()
        {
            GenerateNewClient();
            MakeClientEat();
        }

        private void GenerateNewClient()
        {
            Random random = new Random();
            if (random.Next(60 * 10) != 0) return;

            Client client = new Client($"Client {random.Next(1000)}", new Position(0, 0));
            _clients.Add(client);
            _personController.AddAction(new WelcomeClient(client, _tableController));
        }

        private void MakeClientEat()
        {
            Random random = new Random();
            foreach (var client in _clients)
            {
                if (client.EatingTimeLeft == null) continue;
                
                int nb = random.Next(20 * 60);

                if (nb == 0)
                {
                    client.Table.HasBread = false;
                    _personController.AddAction(new RefreshBread(client.Table));
                }
                else if (nb == 1)
                {
                    client.Table.HasWater = false;
                    _personController.AddAction(new RefreshWater(client.Table));
                }

                client.EatingTimeLeft--;
                if (client.EatingTimeLeft == 0)
                {
                    _personController.AddAction(new MakeClientPay(client, this));
                    _personController.AddAction(new DeserveTable(client.Table, _personController));
                    client.EatingTimeLeft = null;
                }
            }
        }

        public void RemoveClient(Client client)
        {
            this._clients.Remove(client);
        }
    }
}
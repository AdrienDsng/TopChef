using System;
using System.Collections.Generic;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Positions;
using TopChefRestaurant.View;
using Client = TopChefRestaurant.Model.Person.Client;

namespace TopChefRestaurant.Controller
{
    /// <summary>
    /// Controller managing all the clients
    /// </summary>
    public class ClientController
    {
        private List<Client> _clients = new List<Client>();
        private PersonController _personController;
        private TableController _tableController { get; set; }

        /// <summary>
        /// ClientController constructor
        /// </summary>
        /// <param name="restaurantView"></param>
        /// <param name="personController"></param>
        /// <param name="tableController"></param>
        public ClientController(PersonController personController, TableController tableController)
        {
            _personController = personController;
            _tableController = tableController;
            
            Client client = new Client("Michel et sa famille", new Position(44, 96));
            _clients.Add(client);
            _personController.AddAction(new WelcomeClient(client, this._tableController));
        }

        /// <summary>
        /// Main loop called from the restaurant controller
        /// </summary>
        public void MainLoop()
        {
            GenerateNewClient();
            MakeClientEat();
        }
        
        /// <summary>
        /// Randomly generate new clients
        /// </summary>
        private void GenerateNewClient()
        {
            Random random = new Random();
            if (random.Next(60 * 10) != 0) return;

            Client client = new Client($"Client {random.Next(1000)}", new Position(44, 96));
            _clients.Add(client);
            _personController.AddAction(new WelcomeClient(client, _tableController));
        }

        /// <summary>
        /// Randomly make clients eat bread or drink water. Also decrementing their remaining eating time
        /// </summary>
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

        /// <summary>
        /// Remove a client from the clients list
        /// </summary>
        /// <param name="client"></param>
        public void RemoveClient(Client client)
        {
            this._clients.Remove(client);
        }
    }
}
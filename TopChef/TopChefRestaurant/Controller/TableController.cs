using System;
using System.Collections.Generic;
using System.Linq;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Positions;
using TopChefRestaurant.View;
using Client = TopChefRestaurant.Model.Person.Client;

namespace TopChefRestaurant.Controller
{
    /// <summary>
    /// Controller managing all the tables
    /// </summary>
    public class TableController
    {
        private Dictionary<int, List<Table>> _availableTable = new Dictionary<int, List<Table>>();
        private List<Table> _busyTable = new List<Table>();
        private List<Client> _clientsWaiting = new List<Client>();
        private PersonController _personController;
        private RecipeController _recipeController;
        private RestaurantView _restaurantView;
        
        /// <summary>
        /// Table controller constructor
        /// </summary>
        /// <param name="personController"></param>
        /// <param name="recipeController"></param>
        public TableController(RestaurantView restaurantView, PersonController personController, RecipeController recipeController)
        {
            this._restaurantView = restaurantView;
            this._personController = personController;
            this._recipeController = recipeController;
            
            _availableTable.Add(2, new List<Table>());
            _availableTable.Add(4, new List<Table>());
            _availableTable.Add(6, new List<Table>());
            _availableTable.Add(8, new List<Table>());
            _availableTable.Add(10, new List<Table>());
            
            Random random = new Random();
            
            for(int i=0;i<10;i++)
                _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(0, 0)));
            for(int i=0;i<10;i++)
                _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(0, 0)));
            for(int i=0;i<5;i++)
                _availableTable[6].Add(new Table(6, $"Table {random.Next(1000)}", new Position(0, 0)));
            for(int i=0;i<5;i++)
                _availableTable[8].Add(new Table(8, $"Table {random.Next(1000)}", new Position(0, 0)));
            for(int i=0;i<2;i++)
                _availableTable[10].Add(new Table(10, $"Table {random.Next(1000)}", new Position(0, 0)));
        }
        
        /// <summary>
        /// Main loop called from the restaurant controller
        /// </summary>
        public void MainLoop()
        {
            RandomTableEvent();
        }

        /// <summary>
        /// Generate random 
        /// </summary>
        private void RandomTableEvent()
        {
            Random rnd = new Random();

            foreach (var table in _busyTable.ToList())
            {
                if (table.Client == null)
                {
                    _availableTable[table.MaxNbClients].Add(table);
                    _busyTable.Remove(table); 
                    CheckWaitingClients();
                }
                if (rnd.Next(60 * 20) == 0)
                    table.HasBread = false;
                if (rnd.Next(60 * 20) == 0)
                    table.HasWater = false;
            }
        }
        
        /// <summary>
        /// Check if a table is available for a client who is waiting
        /// </summary>
        private void CheckWaitingClients()
        {
            foreach (var client in _clientsWaiting)
            {
                AssignTable(client);
            }
        }

        /// <summary>
        /// Assign a table to a client
        /// </summary>
        /// <param name="client"></param>
        public void AssignTable(Client client)
        {
            if (_availableTable[client.Number].Count > 0)
            {
                Table table = _availableTable[client.Number][0];
                _availableTable[client.Number].Remove(table);
                table.Client = client;
                client.Table = table;
                _busyTable.Add(table);
                _personController.AddAction(new TakeCommands(table, _recipeController));
            }
            else if(!_clientsWaiting.Contains(client))
            {
                _clientsWaiting.Add(client);
            }
        }
    }
}
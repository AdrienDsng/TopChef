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

        /// <summary>
        /// Table controller constructor
        /// </summary>
        /// <param name="restaurantView"></param>
        /// <param name="personController"></param>
        /// <param name="recipeController"></param>
        public TableController(PersonController personController, RecipeController recipeController)
        {
            this._personController = personController;
            this._recipeController = recipeController;
            
            _availableTable.Add(2, new List<Table>());
            _availableTable.Add(4, new List<Table>());
            _availableTable.Add(6, new List<Table>());
            _availableTable.Add(8, new List<Table>());
            _availableTable.Add(10, new List<Table>());
            
            Random random = new Random();

            _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(6, 16)));
            _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(6, 24)));
            _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(6, 32)));
            _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(19, 24)));
            _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(19, 32)));
            _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(48, 70)));
            _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(48, 78)));
            _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(48, 84)));
            _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(60, 78)));
            _availableTable[2].Add(new Table(2, $"Table {random.Next(1000)}", new Position(60, 84)));

            _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(18, 16)));
            _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(18, 42)));
            _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(6, 42)));
            _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(6, 52)));
            _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(18, 52)));
            _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(48, 48)));
            _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(62, 48)));
            _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(62, 60)));
            _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(48, 60)));
            _availableTable[4].Add(new Table(4, $"Table {random.Next(1000)}", new Position(62, 68)));

            _availableTable[6].Add(new Table(6, $"Table {random.Next(1000)}", new Position(4, 62)));
            _availableTable[6].Add(new Table(6, $"Table {random.Next(1000)}", new Position(4, 72)));
            _availableTable[6].Add(new Table(6, $"Table {random.Next(1000)}", new Position(18, 62)));
            _availableTable[6].Add(new Table(6, $"Table {random.Next(1000)}", new Position(48, 40)));
            _availableTable[6].Add(new Table(6, $"Table {random.Next(1000)}", new Position(62, 40)));

            _availableTable[8].Add(new Table(8, $"Table {random.Next(1000)}", new Position(20, 72)));
            _availableTable[8].Add(new Table(8, $"Table {random.Next(1000)}", new Position(6, 80)));
            _availableTable[8].Add(new Table(8, $"Table {random.Next(1000)}", new Position(48, 30)));
            _availableTable[8].Add(new Table(8, $"Table {random.Next(1000)}", new Position(68, 30)));
            _availableTable[8].Add(new Table(8, $"Table {random.Next(1000)}", new Position(48, 22)));

            _availableTable[10].Add(new Table(10, $"Table {random.Next(1000)}", new Position(20, 82)));
            _availableTable[10].Add(new Table(10, $"Table {random.Next(1000)}", new Position(64, 22)));
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
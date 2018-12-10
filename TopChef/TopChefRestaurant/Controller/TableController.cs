using System;
using System.Collections.Generic;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Controller
{
    public class TableController
    {
        private Dictionary<int, List<Table>> _availableTable = new Dictionary<int, List<Table>>();
        private List<Table> _busyTable = new List<Table>();
        private Queue<Client> _clientsWaiting = new Queue<Client>();
        private PersonController _personController;
        public TableController(PersonController personController)
        {
            this._personController = personController;
            
            _availableTable.Add(2, new List<Table>());
            _availableTable.Add(4, new List<Table>());
            _availableTable.Add(6, new List<Table>());
            _availableTable.Add(8, new List<Table>());
            _availableTable.Add(10, new List<Table>());
            
            for(int i=0;i<10;i++)
                _availableTable[2].Add(new Table(2, new Position(0, 0)));
            for(int i=0;i<10;i++)
                _availableTable[4].Add(new Table(4, new Position(0, 0)));
            for(int i=0;i<5;i++)
                _availableTable[6].Add(new Table(6, new Position(0, 0)));
            for(int i=0;i<5;i++)
                _availableTable[8].Add(new Table(8, new Position(0, 0)));
            for(int i=0;i<2;i++)
                _availableTable[10].Add(new Table(10, new Position(0, 0)));
        }

        public void MainLoop()
        {
            RandomTableEvent();
            CheckTables();
        }

        private void RandomTableEvent()
        {
            Random rnd = new Random();

            foreach (var table in _busyTable)
            {
                if (rnd.Next(60 * 20) == 0)
                    table.HasBread = false;
                if (rnd.Next(60 * 20) == 0)
                    table.HasWater = false;
            }
        }

        private void CheckTables()
        {
            foreach (var table in _busyTable)
            {
                if (!table.HasBread)
                {
                    _personController.AddAction(new RefreshBread(table));
                }
                if (!table.HasWater)
                {
                    _personController.AddAction(new RefreshWater(table));
                }
                if (table.Client.Number == 0)
                {
                    _personController.AddAction(new DeserveTable(table));
                }
            }
        }

        public void AssignTable(Client client)
        {
            if (_availableTable[client.Number].Count > 0)
            {
                Table table = _availableTable[client.Number][0];
                _availableTable.Remove(0);
                table.Client = client;
                client.Table = table;
                _busyTable.Add(table);
            }
            else
            {
                _clientsWaiting.Enqueue(client);
            }
        }
    }
}
using System.Collections.Generic;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Controller
{
    public class TableController
    {
        private Dictionary<int, List<Table>> _availableTable = new Dictionary<int, List<Table>>();
        private List<Table> _busyTable = new List<Table>();

        public TableController()
        {
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
            
        }
    }
}
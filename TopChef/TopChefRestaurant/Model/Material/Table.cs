using System.Collections.Generic;
using TopChefRestaurant.Model.Interfaces;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Model.Material
{
    public class Table : IDisplayable, IStatic, INamed, IState
    {
        private int MaxNbClients { get; set; }
        private List<Client> Clients { get; set; }
        private TableNapkin TableNapkin { get; set; }
        private bool HasBread { get; set; }
        private bool HasWater { get; set; }


        public string Sprite { get; set; }
        public Position Position { get; set; }
        public bool IsStatic { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public Table(int maxNbClients, Position position)
        {
            this.MaxNbClients = maxNbClients;
            this.Position = position;
        }
    }
}
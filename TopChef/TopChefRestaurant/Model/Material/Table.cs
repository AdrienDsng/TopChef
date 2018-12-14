using System.Collections.Generic;
using TopChefRestaurant.Model.Interfaces;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Model.Material
{
    public class Table : IDisplayable, INamed
    {
        public int MaxNbClients { get; set; }
        public Client Client { get; set; }
        public TableNapkin TableNapkin { get; set; }
        public bool HasBread { get; set; }
        public bool HasWater { get; set; }
        public List<Dish> Dishes = new List<Dish>();
        public List<Recipe> Orders = new List<Recipe>();

        public string Sprite { get; set; }
        public Position Position { get; set; }
        public bool IsStatic { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

        public Table(int maxNbClients, string name, Position position)
        {
            this.MaxNbClients = maxNbClients;
            this.Position = position;
            this.Name = name;
        }
    }
}
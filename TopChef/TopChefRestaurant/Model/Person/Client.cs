using System;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Positions;
using TopChefRestaurant.View;

namespace TopChefRestaurant.Model.Person
{
    public class Client : Person
    {
        public int Number { get; set; }
        public Table Table { get; set; }
        public int? EatingTimeLeft = null;
        
        public Client(string name, Position position) : base(name, position)
        {
            Random random = new Random();
            int result = random.Next(100);
            
            if (result < 30)
                this.Number = 2;
            else if (result < 60)
                this.Number = 4;
            else if (result < 75)
                this.Number = 6;
            else if (result < 88)
                this.Number = 8;
            else if (result < 100)
                this.Number = 10;
        }
    }
}
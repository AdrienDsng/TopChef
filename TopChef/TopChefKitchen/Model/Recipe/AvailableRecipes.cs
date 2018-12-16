using System.Collections.Generic;

namespace TopChefKitchen.Model.Recipe
{
    public class AvailableRecipes
    {
        public List<Order> Entries { get; set; }
        public List<Order> Plats { get; set; }
        public List<Order> Desserts { get; set; }


    }
}

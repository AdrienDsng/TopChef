using System.Collections.Generic;

namespace TopChefRestaurant.Model
{
    public class AvailableRecipes
    {
        public List<Order> entries { get; set; }
        public List<Order> plats { get; set; }
        public List<Order> desserts { get; set; }


    }
}

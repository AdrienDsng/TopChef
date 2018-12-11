using System;
using TopChefRestaurant;
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model;
using TopChefRestaurant.View;

namespace TopChefRestaurant
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Restaurant())
            game.Run();

            RestaurantModel model = new RestaurantModel();
            RestaurantController controller = new RestaurantController(model);
            RestaurantView view = new RestaurantView(controller);
            
            controller.Loop();
        }
    }
}

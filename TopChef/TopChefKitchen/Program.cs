using System;
using TopChefKitchen.Controller;

namespace TopChefKitchen
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
            using (var game = new kitchen())
            {
                KitchenController controller = new KitchenController();
                game.Run();
            }
        }
    }
}

using System;
using System.Threading;
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
                Console.WriteLine("test");
                KitchenController controller = new KitchenController();
                Console.WriteLine("test");
                new Thread(new ThreadStart(controller.TestMehtod)).Start();
                new Thread( new ThreadStart (controller.Loop)).Start();
                game.Run();
            }
        }
    }
}

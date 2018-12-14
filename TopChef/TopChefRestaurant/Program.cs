using System;
using System.Runtime.CompilerServices;
using System.Threading;
using TopChefRestaurant;
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model;
using TopChefRestaurant.View;

namespace TopChefRestaurant
{
    /// <summary>
    /// The main class.
    /// </summary>
    /// 

    
    public static class Program
    {
        public static RestaurantView RestaurantView;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            using (var game = new RestaurantView())
            {
                RestaurantView = game;
                
                Thread loop = new Thread(() =>
                {
                    RestaurantController controller = new RestaurantController();

                    try
                    {
                        controller.Loop();
                    }
                    catch (ThreadAbortException e)
                    {
                        controller.StopLoop();
                    }
                });
                
                loop.Start();

                game.Run();

                loop.Abort();
            }
        }
    }
}

using System;
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
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            var game = new RestaurantView();
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

using System;
using TopChefRestaurant.Model;

namespace TopChefRestaurant.Controller
{
    public static class LogController
    {
        public static void Log(Event evnt)
        {
            Console.WriteLine(evnt);
        }
    }
}
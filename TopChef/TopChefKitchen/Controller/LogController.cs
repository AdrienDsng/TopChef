using System;
using System.Diagnostics;
using TopChefKitchen.Model;

namespace TopChefKitchen.Controller
{
    public static class LogController
    {
        public static void Log(string msg)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(Sleeper.Instance.TimeElapsed);
            string time = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", t.Hours, t.Minutes, t.Seconds);
            Debug.WriteLine($"{time} - {msg}");
        }
    }
}
namespace TopChefRestaurant.Model
{
    public sealed class Sleeper
    {
        public int Speed { get; set; }
        public bool IsPaused { get; set; }
        public int TimeElapsed { get; set; }
        public int Period => 1000 / Speed;
        
        private static Sleeper instance = null;
        private static readonly object padlock = new object();
        
        Sleeper()
        {
            this.TimeElapsed = 0;
            this.Speed = 60;
            this.IsPaused = false;
        }
        
        public static Sleeper Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Sleeper();
                    }
                    return instance;
                }
            }
        }
    }
}
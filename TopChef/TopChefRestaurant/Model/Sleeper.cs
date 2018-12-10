namespace TopChefRestaurant.Model
{
    public class Sleeper
    {
        public int Speed { get; set; }
        public bool IsPaused { get; set; }
        
        public Sleeper()
        {
            this.Speed = 1;
            this.IsPaused = false;
        }

        public int Period => 1000 / Speed;
    }
}
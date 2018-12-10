namespace TopChefRestaurant.Model
{
    public class Sleeper
    {
        public float Multiplicator { get; set; }
        public bool IsPaused { get; set; }
        
        public Sleeper()
        {
            this.Multiplicator = 1;
            this.IsPaused = false;
        }
    }
}
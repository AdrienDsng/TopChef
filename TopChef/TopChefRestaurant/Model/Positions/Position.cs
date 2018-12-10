namespace TopChefRestaurant.Model.Positions
{
    public class Position
    {
        private int X { get; set; }
        private int Y { get; set; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
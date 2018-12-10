namespace TopChefRestaurant.Model.Positions
{
    public interface IDisplayable
    {
        string Sprite { get; set; }
        Position Position { get; set; }
    }
}
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Model.Actions
{
    public interface IAction
    {
        void Realize();
        int RemainingTime { get; set; }
        int DecreaseTime();
        bool CanRealize(object person);
        Position Position { get; set; }
        Person.Person Employee { get; set; }
    }
}
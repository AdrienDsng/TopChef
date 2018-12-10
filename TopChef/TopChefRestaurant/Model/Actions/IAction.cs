namespace TopChefRestaurant.Model.Actions
{
    public interface IAction
    {
        void Realize();
        int RemainingTime { get; set; }
        int DecreaseTime();
        bool CanRealize(object person);
        Person.Person Employee { get; set; }
    }
}
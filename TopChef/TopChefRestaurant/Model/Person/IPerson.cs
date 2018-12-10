namespace TopChefRestaurant.Model.Person
{
    public interface IPerson
    {
        int WorkingTime { get; set; }
        void Arrive();
        void Leave();
        bool IsAlive();
    }
}
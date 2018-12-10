namespace TopChefRestaurant.Controller.Actions
{
    public class Action
    {
        private int Time { get; set; }
        private int RemainingTime { get; set; }
        public Action(int time)
        {
            this.Time = time;
        }
    }
}
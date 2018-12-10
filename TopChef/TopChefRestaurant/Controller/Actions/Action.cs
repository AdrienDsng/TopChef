using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Controller.Actions
{
    public abstract class Action
    {
        private int Time { get; set; }
        private int RemainingTime { get; set; }
        public Person Employee { get; set; }
        
        public Action(int time)
        {
            this.Time = time;
            this.RemainingTime = time;
        }

        public virtual void Realize()
        {
            throw new System.NotImplementedException();
        }

        public int DecreaseTime()
        {
            this.RemainingTime--;
            if (this.RemainingTime == 0)
            {
                Realize();
            }
            return this.RemainingTime;
        }
    }
}
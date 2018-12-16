namespace TopChefRestaurant.Model.Actions
{
    public abstract class Action
    {
        private int Time { get; set; }
        public int RemainingTime { get; set; }
        public Person.Person Employee { get; set; }
        
        public Action(int time)
        {
            this.Time = time;
            this.RemainingTime = time;
        }

        public virtual void Realize()
        {
            
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
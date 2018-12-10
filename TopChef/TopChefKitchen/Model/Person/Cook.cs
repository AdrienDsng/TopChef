using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Person;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Personn
{
    class Cook : Person, ICook
    {
        public Cook(string name, Position position, int time) : base(name, position, time)
        {
            IsAlive = true;
            IsStatic = false;
            Arrive();
        }

        public void CookIngredient()
        {
            throw new NotImplementedException();
        }

        public void CookIngredientWithFire()
        {
            throw new NotImplementedException();
        }

        public void CutIngredient()
        {
            throw new NotImplementedException();
        }

        public void PeelIngredient()
        {
            throw new NotImplementedException();
        }

        public void putIngredientInTheFridge()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.position;

namespace TopChefKitchen.Model.Personn
{
    class Apprentice : Person
    {
        public Apprentice(string name, Position position, int time) : base(name, position, time)
        {
            IsAlive = true;
            IsStatic = false;
            Arrive();
        }

        public void CutIngredient()
        {
            throw new NotImplementedException();
        }

        public void PeelIngredient()
        {
            throw new NotImplementedException();
        }

        public void getIngredientFromStock()
        {

        }
    }
}

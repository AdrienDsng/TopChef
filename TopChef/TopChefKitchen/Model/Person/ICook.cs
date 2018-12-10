using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Person
{
    interface ICook
    {
        void CutIngredient();
        void PeelIngredient();
        void CookIngredientWithFire();
        void putIngredientInTheFridge();
        void CookIngredient();
    }
}

using System;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Controller.Actions
{
    public interface IAction
    {
        void Realize();
        int DecreaseTime();
        bool CanRealize(object person);
        Person Employee { get; set; }
    }
}
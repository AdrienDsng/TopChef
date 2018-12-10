using System;

namespace TopChefRestaurant.Controller.Actions
{
    public interface IAction
    {
        void Realize(Object o);
        bool CanRealize(object person);
    }
}
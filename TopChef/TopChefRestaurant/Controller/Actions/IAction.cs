using System;

namespace TopChefRestaurant.Controller.Actions
{
    public interface IAction
    {
        void Realize(Object o);
        int Time { get; }
        bool CanRealize(object person);
    }
}
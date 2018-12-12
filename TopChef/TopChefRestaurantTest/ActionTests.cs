using System;
using NUnit.Framework;
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Actions;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurantTest
{
    public class ActionTests
    {
        [Test, TestCaseSource("CanRealizeCases")]
        public void CanRealizeTest(Person person, IAction action, bool expected)
        {
            Assert.AreEqual(action.CanRealize(person), expected);
        }

        private static object[] CanRealizeCases =
        {
            new object[]
            {
                new Apprentice("Michel", new Position(0, 0)),
                new DeserveTable(new Table(2, "Coucou", new Position(0, 0)), new PersonController()), 
                false
            },
            new object[]
            {
                new Waiter("Michel", new Position(0, 0)),
                new DeserveTable(new Table(2, "Coucou", new Position(0, 0)), new PersonController()), 
                true
            },
        };
    }
}
using System;
using System.Collections.Generic;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class ServeTable : Action, IAction
    {
        private Table Table { get; set; }

        public ServeTable(Table table) : base(30)
        {
            this.Table = table;
        }

        public override void Realize()
        {
            Table.Orders = new List<Recipe>(); //todo
            Table.Client.EatingTimeLeft = (new Random()).Next(30, 90);
        }

        public bool CanRealize(object person)
        {
            return person is Waiter;
        }
    }
}
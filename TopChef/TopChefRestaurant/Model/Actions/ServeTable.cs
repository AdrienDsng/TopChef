using System;
using System.Collections.Generic;
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Model.Actions
{
    public class ServeTable : Action, IAction
    {
        public Table Table { get; set; }

        public ServeTable(Table table) : base(30)
        {
            this.Table = table;
            this.Position = new Position(Table.Position.X + 1, Table.Position.Y);
        }

        public override void Realize()
        {
            Table.Orders = new List<Order>(); //todo
            Table.Client.EatingTimeLeft = (new Random()).Next(30, 90) * 60;
            LogController.Log(new Event(this));
        }

        public bool CanRealize(object person)
        {
            return person is Waiter;
        }

        public Position Position { get; set; }
    }
}
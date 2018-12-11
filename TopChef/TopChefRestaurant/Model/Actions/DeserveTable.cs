using System.Collections.Generic;
using System.Net.WebSockets;
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class DeserveTable : Action, IAction
    {
        public Table Table { get; set; }
        public DeserveTable(Table table) : base(60)
        {
            this.Table = table;
        }
        public override void Realize()
        {
//            ClientSocket.send(Table.Dishes); TODO
//            ClientSocket.send(Table.TableNapkin);
            Table.Dishes = null;
            Table.TableNapkin = null;
            LogController.Log(new Event(this));
        }

        public bool CanRealize(object person)
        {
            return person is Waiter;
        }

    }
}
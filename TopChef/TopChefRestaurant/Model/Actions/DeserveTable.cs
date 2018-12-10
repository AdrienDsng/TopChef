using System.Collections.Generic;
using System.Net.WebSockets;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class DeserveTable : Action, IAction
    {
        private Table Table;
        public DeserveTable(Table table) : base(60)
        {
            this.Table = table;
        }
        public override void Realize()
        {
//            ClientSocket.send(Table.Dishes); TODO
//            ClientSocket.send(Table.TableNapkin);
            Table.Dishes = new List<Dish>();
            Table.TableNapkin = null;
        }

        public bool CanRealize(object person)
        {
            return person is Waiter;
        }

    }
}
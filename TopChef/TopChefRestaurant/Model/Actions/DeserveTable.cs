using System.Collections.Generic;
using System.Net.WebSockets;
using Common;
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Model.Actions
{
    public class DeserveTable : Action, IAction
    {
        public Table Table { get; set; }
        private PersonController _personController;
        public Position Position { get; set; }
        
        public DeserveTable(Table table, PersonController personController) : base(60)
        {
            this.Table = table;
            this._personController = personController;
            this.Position = new Position(Table.Position.X + 1, Table.Position.Y);
        }
        public override void Realize()
        {
            Communicator.SendObject(Serialized.Serialize(Table.Dishes));
            Communicator.SendObject(Serialized.Serialize(Table.TableNapkin));
            Table.Dishes = null;
            Table.TableNapkin = null;
            Table.Client = null;
            
            _personController.AddAction(new LayTable(Table));
            LogController.Log(new Event(this));
        }

        public bool CanRealize(object person)
        {
            return person is Waiter;
        }

        
    }
}
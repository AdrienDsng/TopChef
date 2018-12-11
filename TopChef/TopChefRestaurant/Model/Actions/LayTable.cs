using System.Collections.Generic;
using TopChefRestaurant.Controller;
using TopChefRestaurant.Model.Material;
using TopChefRestaurant.Model.Person;

namespace TopChefRestaurant.Model.Actions
{
    public class LayTable : Action, IAction
    {
        public Table Table { get; set; }
        public LayTable(Table table) : base(60)
        {
            this.Table = table;
        }
        public override void Realize()
        {
            Table.TableNapkin = new TableNapkin();
            Table.Dishes = new List<Dish>();

            for (var i = 0; i < Table.MaxNbClients; i++)
            {
                Table.Dishes.Add(new Plate());
                Table.Dishes.Add(new Fork());
                Table.Dishes.Add(new Knife());
                Table.Dishes.Add(new Glass());
                Table.Dishes.Add(new WineGlass());
                Table.Dishes.Add(new LittleSpoon());
            }
            LogController.Log(new Event(this));
        }

        public bool CanRealize(object person)
        {
            return person is RowChief;
        }

    }
}
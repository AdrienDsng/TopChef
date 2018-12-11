using TopChefRestaurant.Model.Actions;

namespace TopChefRestaurant.Model
{
    public class Event
    {
        public string Type { get; set; }
        public string Name { get; set; }
        
        public Event(Action action)
        {
            if (action is DeserveTable)
            {
                var deserveTable = (DeserveTable) action;
                Type = "Cette table a été desservie : ";
                Name = deserveTable.Table.Name;
            }
            else if (action is LayTable)
            {
                var layTable = (LayTable) action;
                Type = "Cette table a été préparé : ";
                Name = layTable.Table.Name;
            }
               else if (action is MakeClientPay)
            {
                var makeClientPay = (MakeClientPay) action;
                Type = "Ce client a payé : ";
                Name = makeClientPay.Client.Name;
            }
            else if (action is RefreshBread)
            {
                var refreshBread = (RefreshBread) action;
                Type = "Du pain a été servie à cette table : ";
                Name = refreshBread.Table.Name;
            }
            else if (action is RefreshWater)
            {
                var refreshWater = (RefreshWater) action;
                Type = "De l'eau a été servie à cette table : ";
                Name = refreshWater.Table.Name;
            }
            else if (action is ServeTable)
            {
                var serveTable = (ServeTable) action;
                Type = "Cette table a été servie : ";
                Name = serveTable.Table.Name;
            }
            else if (action is TakeCommands)
            {
                var takeCommands = (TakeCommands) action;
                Type = "Les commandes ont été prises à cette table : ";
                Name = takeCommands.Table.Name;
            }
            else if (action is WelcomeClient)
            {
                var welcomeClient = (WelcomeClient) action;
                Type = "Ce client a été accueilli : ";
                Name = welcomeClient.Client.Name;
            }     
        }

        public override string ToString()
        {
            return this.Type + this.Name;
        }
    }
}
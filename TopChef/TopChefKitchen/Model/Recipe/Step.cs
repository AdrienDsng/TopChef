using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Recipe
{
    public class Step
    {
        public string RecipeName { get; set; }
        public int Nb_step { get; set; }
        public int Id { get; set; }
        public int Wait_Time { get; set; }
        public int Sync { get; set; }
        public string Resource_Needed { get; set; }
        public string Machine_Needed { get; set; }
        public string People_Needed { get; set; }

        public Step()
        {

        }

    }
}

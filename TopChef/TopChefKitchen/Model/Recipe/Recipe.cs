using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;


namespace TopChefKitchen.Model.Recipe
{
    public class Recipe : INamed
    {
        
        public string Name { get ; set ; }
        public int Type { get; set; }
        public List<Step> Steps { get ; set ; }
        public int Time { get ; set ; }
        public int Nb_people { get; set; }

        public Recipe()
        {
            Steps = new List<Step>();
        }

        public void GetRecipe(string name)
        {
            
        }

        public void AddStep(Step step)
        {
            Steps.Add(step);
        }
    }
}

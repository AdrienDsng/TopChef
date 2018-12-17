using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.Recipe;

namespace TopChefKitchen.Model.Tool
{
    public interface ITool : IWashable
    {
        int Quantity { get; set; }
        string Size { get; set; }
        Preparation Preparation { get;set; }

        void GetPreparation(Preparation preparation);
    }
}

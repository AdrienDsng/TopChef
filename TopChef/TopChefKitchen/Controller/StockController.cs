using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model;

namespace TopChefKitchen.Controller
{
    class StockController
    {
        public Stock Stock { get; set; }

        public StockController()
        {
            Stock = new Stock();
        }

        public void UpdateStock()
        {
            Stock.UpdateStock();
        }
    }
}

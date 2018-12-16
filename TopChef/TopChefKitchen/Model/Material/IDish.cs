using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    public interface IDish
    {
        int Quantity { get; set; }
        string Size { get; set;  }
    }
}

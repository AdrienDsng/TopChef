using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Interface
{
    //<summary>
    //Interface to Give Attribute to know if the classes its dirty
    //<summary>
    public interface IWashable
    {
        bool IsDirty { get; set; }
    }
}

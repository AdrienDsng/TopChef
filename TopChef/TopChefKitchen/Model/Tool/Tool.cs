using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefKitchen.Model.Interface;
using TopChefKitchen.Model.position;
using TopChefKitchen.Model.Recipe;

namespace TopChefKitchen.Model.Tool
{
    abstract class Tool : ITool, INamed , IStatic, IPosition , IState, IWashable
    {
        public int Quantity { get ; set ; }
        public string Size { get ; set ; }
        public Position Position { get ; set ; }
        public bool IsStatic { get ; set ; }
        public string Name { get ; set ; }
        public string State { get ; set ; }
        public bool IsDirty { get ; set ; }
        public Preparation Preparation { get ; set ; }

        public void GetPreparation(Preparation preparation)
        {
            this.Preparation = preparation;
        }

        public void move(Position position)
        {
            Position = position;
        }
    }
}

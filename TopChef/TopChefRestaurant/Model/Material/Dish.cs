using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopChefRestaurant.Model.Interfaces;
using TopChefRestaurant.Model.Positions;

namespace TopChefRestaurant.Model.Material
{
    public class Dish : Material, IStatic, INamed, IWashable, IState, IDisplayable
    {
        public bool IsStatic { get; set; }
        public string Name { get; set; }
        public bool IsDirty { get; set; }
        public string State { get; set; }
        public string Sprite { get; set; }
        public Position Position { get; set; }
    }
}

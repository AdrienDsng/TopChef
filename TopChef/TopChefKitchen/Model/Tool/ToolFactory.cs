using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Tool
{
    class ToolFactory : Tool
    {
        public ToolFactory()
        {

        }
        public static Tool GetInstance(string name, position.Position position)
        {
            switch (name)
            {
                case "Juicer":
                    return new Juicer(position);
                               
                case "CookingKnife":
                    return new CookingKnife(position);
                    
                case "Funnel":
                    return new Funnel(position);
                                                      
                case "Pan":
                    return new Pan(position);
                    
                case "PressureCooker":
                    return new PressureCooker(position);
                    
                case "SaladBowl":
                    return new SaladBowl(position);
                    
                case "Sieve":
                    return new Sieve(position);
                    
                case "Stove":
                    return new Stove(position);
                    
                case "WoodenSpoon":
                    return new WoodenSpoon(position);
                    
                default:
                    return null;
            }           
        }
    }
}

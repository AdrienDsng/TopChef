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
                    break;
                case "CookingFire":
                    return new CookingFire(position);
                    break;
                case "CookingKnife":
                    return new CookingKnife(position);
                    break;
                case "Funnel":
                    return new Funnel(position);
                    break;
                case "Mixer":
                    return new Mixer(position);
                    break;
                case "Oven":
                    return new Oven(position);
                    break;
                case "Pan":
                    return new Pan(position);
                    break;
                case "PressureCooker":
                    return new PressureCooker(position);
                    break;
                case "SaladBowl":
                    return new SaladBowl(position);
                    break;
                case "Sieve":
                    return new Sieve(position);
                    break;
                case "Stove":
                    return new Stove(position);
                    break;
                case "WoodenSpoon":
                    return new WoodenSpoon(position);
                    break;

                default:
                    return new CookingKnife(position);
                    break;

            }           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen.Model.Material
{
    class DishFactory : Dish
    {
        public DishFactory()
        {

        }
        public static Dish GetInstance(string name, position.Position position)
        {
            switch (name)
            {
                case "BigSpoon":
                    return new BigSpoon(position);

                case "ChampagneGlass":
                    return new ChampagneGlass(position);

                case "CoffeeCup":
                    return new CoffeeCup(position);

                case "CurvyPlate":
                    return new CurvyPlate(position);

                case "DessertPLate":
                    return new DessertPlate(position);

                case "Fork":
                    return new Fork(position);

                case "Glass":
                    return new Glass(position);

                case "Knife":
                    return new Knife(position);

                case "LittlePlate":
                    return new LittlePlate(position);

                case "LittleSpoon":
                    return new LittleSpoon(position);

                case "Plate":
                    return new Plate(position);

                case "WineGlass":
                    return new WineGlass(position);

                default:
                    return new Knife(position);
            }
        }
    }
}

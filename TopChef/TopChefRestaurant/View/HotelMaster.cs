using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopChefRestaurant.View
{
    class HotelMaster
    {
        public HotelMaster (GraphicsDevice graphicsDevice)
        {

        }


        public void Draw(SpriteBatch spriteBatch, Texture2D hotelMaster)
        {            
            spriteBatch.Begin();
            spriteBatch.Draw(hotelMaster, new Rectangle(270, 710, 64, 48), Color.White);//Draw sprite with position (x,y) and size (x,y)
            spriteBatch.End();
        }
    }
}

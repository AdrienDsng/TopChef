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
            Vector2 position = new Vector2(0, 0);
            spriteBatch.Begin();
            spriteBatch.Draw(hotelMaster, position, Color.White);
            spriteBatch.End();
        }
    }
}

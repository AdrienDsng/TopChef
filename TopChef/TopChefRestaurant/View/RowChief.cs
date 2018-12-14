using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopChefRestaurant.View
{
    class RowChief
    {

        int x = 215;
        int y = 680;

        public RowChief(GraphicsDevice graphicsDevice)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D rowChief)
        {            
            spriteBatch.Begin();
            spriteBatch.Draw(rowChief, new Rectangle(x, y, 24, 32), Color.White);
            spriteBatch.End();
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopChefRestaurant.View
{
    class RowChief
    {
        public RowChief(GraphicsDevice graphicsDevice)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D rowChief)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(rowChief, new Rectangle(100, 100, 24, 32), Color.White);
            spriteBatch.End();
        }
    }
}

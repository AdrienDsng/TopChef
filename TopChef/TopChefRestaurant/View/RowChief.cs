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
            spriteBatch.Draw(rowChief, new Rectangle(270, 710, 64, 48), Color.White);
            spriteBatch.End();
        }
    }
}

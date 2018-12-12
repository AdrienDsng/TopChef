using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopChefRestaurant.View
{
    class Waiter
    {
        public Waiter(GraphicsDevice graphicsDevice)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D waiter)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(waiter, new Rectangle(270, 710, 64, 48), Color.White);
            spriteBatch.End();
        }
    }
}

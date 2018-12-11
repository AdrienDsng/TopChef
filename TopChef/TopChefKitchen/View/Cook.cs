using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopChefKitchen.View
{
    class Cook
    {
        public Cook(GraphicsDevice graphicsDevice)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D cook)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(cook, new Rectangle(43, 56, 64, 48), Color.White);
            spriteBatch.End();
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopChefKitchen.View
{
    class Apprentice
    {
        public Apprentice(GraphicsDevice graphicsDevice)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D apprentice)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(apprentice, new Rectangle(42, 54, 64,48), Color.White);
            spriteBatch.End();
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopChefKitchen.View
{
    class DishWasherDiver
    {
        public DishWasherDiver(GraphicsDevice graphicsDevice)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D dishWasherDiver)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(dishWasherDiver, new Rectangle(43, 33, 64, 48), Color.White);
            spriteBatch.End();
        }
    }
}

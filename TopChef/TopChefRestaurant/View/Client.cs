using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopChefRestaurant.View
{
    class Client
    {
        public Client(GraphicsDevice graphicsDevice)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D client)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(client, new Rectangle(270, 710, 64, 48), Color.White);
            spriteBatch.End();
        }
    }
}

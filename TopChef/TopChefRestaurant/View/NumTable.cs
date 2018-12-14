using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopChefRestaurant.View
{
    class NumTable
    {
        public NumTable(GraphicsDevice graphicsDevice)
        {

        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Begin();
            //spriteBatch.DrawString(font, "NumTable : " + numTable, new Vector2(100, 100), Color.Black);
            spriteBatch.End();
        }
    }
}

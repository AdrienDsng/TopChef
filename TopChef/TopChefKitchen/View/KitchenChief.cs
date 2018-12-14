using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace TopChefKitchen.View
{
    class KitchenChief
    {
        private SpriteBatch spriteBatch;

        public KitchenChief()
        {
            
        }

        public void Draw(SpriteBatch spritebatch, int x, int y)
        {
            Vector2 tilePosition = Vector2.Zero;
            spriteBatch.Begin();

            spriteBatch.FillRectangle(tilePosition + new Vector2(0, 0), new Size2(2000, 2000), Color.Black);

            spriteBatch.End();
        }
    }
}

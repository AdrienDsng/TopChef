using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChefKitchen
{
    class Map
    {
        private int tileWidth;
        private int tileHeight;
        private int width;
        private int height;

        public Map(int pTileWidth, int pTileHeight, int pWidth, int pHeight)
        {
            tileWidth = pTileWidth;
            tileHeight = pTileHeight;
            width = pWidth;
            height = pHeight;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            Vector2 tilePosition = Vector2.Zero;
            spriteBatch.Begin();

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    spriteBatch.FillRectangle(tilePosition, new Size2(tileWidth, tileHeight), Color.Black);
                }
            }

            spriteBatch.End();

        }
    }
}

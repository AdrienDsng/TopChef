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
        public Map()
        {

        }

        public void draw(SpriteBatch spriteBatch, Texture2D tile)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(tile, new Rectangle(0, 0, 928, 320), Color.White);
            
            spriteBatch.End();

        }
    }
}

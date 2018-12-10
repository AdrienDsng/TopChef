using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;


namespace TopChefKitchen
{
    public class Entity
    {

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public Entity(GraphicsDevice graphicsDevice)
        {
            
            
        }

        public void Draw(SpriteBatch spriteBatch,  Texture2D characterSheetTexture)
        {
            Vector2 topLeftOfSprite = new Vector2(this.X, this.Y);
            Color tintColor = Color.White;
            spriteBatch.Begin();
            spriteBatch.Draw(characterSheetTexture, new Rectangle(X, Y, 128, 96), tintColor);
            spriteBatch.End();
        }
    }
}
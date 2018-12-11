using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopChefRestaurant.View
{
    public class Restaurant : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public const int WINDOWS_WIDTH = 568;
        public const int WINDOWS_HEIGHT = 784;

        Vector2 position;

        Texture2D redSquare;
        Texture2D backgroundmap;
        Texture2D hotelMaster;
        Texture2D rowChief;
        Texture2D waiter;
        Texture2D apprentice;

        HotelMaster hotelmaster;
        RowChief rowchief;
        Waiter waiteR;
        Apprentice apprenticE;

        public Restaurant()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WINDOWS_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOWS_HEIGHT;
            Content.RootDirectory = "Content";
            position = new Vector2(0, 0);
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            hotelmaster = new HotelMaster(this.GraphicsDevice);
            rowchief = new RowChief(this.GraphicsDevice);
            waiteR = new Waiter(this.GraphicsDevice);
            apprenticE = new Apprentice(this.GraphicsDevice);

            redSquare = new Texture2D(this.GraphicsDevice, 100, 100);
            Color[] colorData = new Color[100 * 100];
            for (int i = 0; i < 10000; i++)
                colorData[i] = Color.Pink;

            redSquare.SetData<Color>(colorData);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundmap = Content.Load<Texture2D>("Restaurant");
            hotelMaster = Content.Load<Texture2D>("HotelMaster");
            rowChief = Content.Load<Texture2D>("RowChief");
            //waiter = Content.Load<Texture2D>("Waiter");
            //apprentice = Content.Load<Texture2D>("Apprentice");
            // TODO: use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            position.X += 1;
            if (position.X > this.GraphicsDevice.Viewport.Width)
                position.X = 0;

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //Draw background
            spriteBatch.Begin();
            spriteBatch.Draw(backgroundmap, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            //Draw square
            spriteBatch.Begin();
            spriteBatch.Draw(redSquare, position);
            spriteBatch.End();

            hotelmaster.Draw(spriteBatch, hotelMaster);
            rowchief.Draw(spriteBatch, rowChief);
            //waiteR.Draw(spriteBatch, waiter);
            //apprenticE.Draw(spriteBatch, apprentice);

            base.Draw(gameTime);
        }

    }
}

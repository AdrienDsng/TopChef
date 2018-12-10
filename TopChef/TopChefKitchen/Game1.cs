using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TopChefKitchen
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        private Map myMap = new Map();
        SpriteBatch spriteBatch;

        Texture2D kitchen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 320;
            graphics.PreferredBackBufferWidth = 928;
            graphics.ApplyChanges();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            kitchen = Content.Load<Texture2D>("Kitchen");
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            myMap.draw(spriteBatch, kitchen);

            base.Draw(gameTime);
        }
    }
}

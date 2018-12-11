using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TopChefKitchen.Model.Tool;

namespace TopChefKitchen
{
    public class kitchen : Game
    {
        GraphicsDeviceManager graphics;
        private Map myMap = new Map();
        SpriteBatch spriteBatch;
        Entity test;

        Texture2D kitchenTile;
        Texture2D playerTile;

        public kitchen()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Tool tool = ToolFactory.GetInstance("Juicer", new Model.position.Position(1,1));
        }

        protected override void Initialize()
        {
            test = new Entity(this.GraphicsDevice);

            graphics.PreferredBackBufferHeight = 480;
            graphics.PreferredBackBufferWidth = 1392;
            graphics.ApplyChanges();

            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            kitchenTile = Content.Load<Texture2D>("Kitchen");
            playerTile = Content.Load<Texture2D>("player");
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                test.Y --;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                test.Y++;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                test.X --;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                test.X ++;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                test.X += 1000;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            myMap.draw(spriteBatch, kitchenTile);
            test.Draw(spriteBatch, playerTile);

            

            base.Draw(gameTime);
        }
    }
}

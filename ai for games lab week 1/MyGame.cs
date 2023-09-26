using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLib;
using System.Runtime.CompilerServices;

namespace ai_for_games_lab_week_1
{
    public class MyGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private ShapeBatcher _shapeBatcher;


        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _shapeBatcher = new ShapeBatcher(this);


            base.Initialize();


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _font = this.Content.Load<SpriteFont>("MyFont");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Circle c1 = new Circle(300,400);
            
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "Hello, World", new Vector2(100,100), Color.Black);
            _spriteBatch.End();

            _shapeBatcher.Begin();
            _shapeBatcher.DrawLine(new Vector2(20, 20), new Vector2(_graphics.GraphicsDevice.Viewport.Width - 20, _graphics.GraphicsDevice.Viewport.Height - 20), 5, Color.OrangeRed);
            _shapeBatcher.DrawCircle(c1.position, 20, 16, 3, Color.DarkGreen);
            
            _shapeBatcher.End();

            


            base.Draw(gameTime);
        }
    }
}

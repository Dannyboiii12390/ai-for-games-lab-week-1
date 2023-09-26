using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLib;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace ai_for_games_lab_week_1
{
    public class MyGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private ShapeBatcher _shapeBatcher;
        private Circle c1 = new Circle(300, 400);
        private Circle c2 = new Circle(600, 250, 30);
        


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
            c1.changeColour(Color.Blue);

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
            this.Draw(gameTime);

            float seconds = gameTime.ElapsedGameTime.Milliseconds / 1000f;

            c1.position += Vector2.Multiply(c1.velocity, seconds);

            if (c1.position.X - c1._circleRadius < 0 || c1.position.X + c1._circleRadius > _graphics.GraphicsDevice.Viewport.Width)
            {
                c1.changeVelX(-c1.velocity.X);
                
            }

            if (c1.position.Y - c1._circleRadius < 0 || c1.position.Y + c1._circleRadius > _graphics.GraphicsDevice.Viewport.Height)
            {
               c1.changeVelY(-c1.velocity.Y);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "Hello, World", new Vector2(100,100), Color.Black);
            _spriteBatch.End();

            _shapeBatcher.Begin();
            _shapeBatcher.DrawLine(new Vector2(20, 20), new Vector2(_graphics.GraphicsDevice.Viewport.Width - 20, _graphics.GraphicsDevice.Viewport.Height - 20), 5, Color.OrangeRed);
            _shapeBatcher.DrawCircle(c1.position, c1._circleRadius, 16, 3, Color.DarkGreen);
            _shapeBatcher.DrawCircle(c2.position, c2._circleRadius, 16, 3, c2.colour);
            _shapeBatcher.DrawArrow(c1.position, c1.velocity, 2, 10, Color.DarkSalmon);


            _shapeBatcher.End();

            


            base.Draw(gameTime);
        }
    }
}

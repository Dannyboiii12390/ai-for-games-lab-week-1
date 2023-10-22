using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ImGuiNET;
using MonoGameLib.Shapes;
using System.Runtime.CompilerServices;

namespace ai_for_games_lab_week_1
{
    public class MyGame : Game
    {
        //utilities
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private ShapeBatcher _shapeBatcher;
        private int screenWidth;
        private int screenHeight;




        //shapes
        private Circle _mouseCircle;
        private Circle _followingCircle;


        public MyGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            screenWidth = _graphics.GraphicsDevice.Viewport.Width;
            screenHeight = _graphics.GraphicsDevice.Viewport.Height;


            _mouseCircle = new Circle(new Vector2(screenWidth/2, screenHeight/2), 30, Color.BlueViolet);
            _followingCircle = new Circle(new Vector2(screenWidth / 2 - 50, screenHeight / 2 - 50), 30, Color.Red);

           
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

            Vector2 mousePosition = Mouse.GetState().Position.FlipY(_graphics.GraphicsDevice.Viewport.Height);
            _mouseCircle = new Circle(mousePosition, _mouseCircle._radius, _mouseCircle._colour);

            _followingCircle.updateVel(mousePosition);
            _followingCircle.seek();





            // TODO: Add your update logic here                                                   
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _shapeBatcher.Draw(_mouseCircle);
            _shapeBatcher.Draw(_followingCircle);





            
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLib;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using MonoGame.ImGui;
using ImGuiNET;
using System;
using MonoGameLib.Shapes;

namespace ai_for_games_lab_week_1
{
    public class MyGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;
        private ShapeBatcher _shapeBatcher;
        private Circle c1 = new Circle(100,200);
        private Circle c2 = new Circle(0, 0, 30);
        private ImGuiRenderer _guiRenderer;
        private Agent _agent;
        private bool _simulating = false;
        private Circle MouseCircle = new Circle(50,50);
        private bool inside;
        private int _windowWidth;
        private int _windowHeight;
        private Text text;
        private Line line;



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
            _guiRenderer = new ImGuiRenderer(this).Initialize().RebuildFontAtlas();
            _agent = new Agent(new System.Numerics.Vector2(200, 200), new System.Numerics.Vector2(50, 50), 20);
            MouseCircle.changeColour(Color.GreenYellow);

            _windowWidth = _graphics.GraphicsDevice.Viewport.Width;
            _windowHeight = _graphics.GraphicsDevice.Viewport.Height;

            text = new Text("Hello World", new Vector2(100, 100), Color.White);
            line = new Line(new Vector2(20, 20), new Vector2(_windowWidth - 20, _windowHeight - 20), Color.AliceBlue, 5 );


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

            c1.position += Vector2.Multiply(c1._velocity, seconds);

            if (c1.position.X - c1._radius < 0 || c1.position.X + c1._radius > _graphics.GraphicsDevice.Viewport.Width)
            {
                
                c1.changeVelX(-c1._velocity.X);
                
            }

            if (c1.position.Y - c1._radius < 0 || c1.position.Y + c1._radius > _graphics.GraphicsDevice.Viewport.Height)
            {
               c1.changeVelY(-c1._velocity.Y);
            }
            if (_simulating)
            {
                _agent.update(seconds);
            }

            Vector2 mousePosition = Mouse.GetState().Position.FlipY(_graphics.GraphicsDevice.Viewport.Height);
            this.inside = MouseCircle.isInside(mousePosition);
            
                
            


            
            //if ()
            
            //_agent.update(seconds);



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, text.text, text.position, text._colour);
            _spriteBatch.End();

            _shapeBatcher.HelperDrawLine(line);
            _shapeBatcher.HelperDraw(c1);
            _shapeBatcher.HelperDraw(c2);
            _shapeBatcher.HelperDrawArrow(c1);
            _shapeBatcher.HelperDraw(_agent, Color.Red);
            _shapeBatcher.HelperDrawArrow(_agent, Color.Green);
            _shapeBatcher.HelperDraw(MouseCircle);
            
            _guiRenderer.BeginLayout(gameTime);
            ImGui.Begin("Debug Interface");

            //ImGui.SliderFloat("x", ref _cheesePosition.X, 0.0f, GraphicsDevice.Viewport.width, string.Empty);
            //ImGui.SliderFloat("y", ref _cheesePosition.Y, 0.0f, GraphicsDevice.Viewport.height, string.Empty)
            
            if (_simulating)
            {
                if (ImGui.Button("Stop"))
                {
                    _simulating = false;
                }

            }
            else
            {
                if (ImGui.Button("Start"))
                {
                    _simulating = true;
                }
            }
            _agent.RenderGui();
            ImGui.End();
            ImGui.Begin("is inside");
            ImGui.Button(inside.ToString());
            ImGui.End();





            _guiRenderer.EndLayout();

            

            


            base.Draw(gameTime);
        }
    }
}

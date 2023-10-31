using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ImGuiNET;
using MonoGameLib.Shapes;
using MonoGameLib.Entities;
using System.Runtime.CompilerServices;
using ai_Game.Helpers;
using System.Collections.Generic;
using System;

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
        private int gameTick = 0;
        private int shootInterval = 10;


        //Entities
        private Player _player;
        private Enemy _boss;

        //shapes
        Line BossHealthBar;
        


        //test variables
        

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


            Circle playerCircle = new Circle(new Vector2(screenWidth/2, screenHeight/2), 30, Color.BlueViolet);
            Circle EnemyCircle = new Circle(new Vector2(screenWidth / 2 - 50, screenHeight / 2 - 50), 30, Color.Red);

            _player = new Player(100, 5, playerCircle);
            _boss = new Enemy(100, 5, EnemyCircle);

            //_betweenMouseAndFollower = new Line(_player.Hitbox._position, _boss.Hitbox._position, Color.Green, 5) ;

            
            BossHealthBar = new Line(new Vector2(screenWidth * 0.01f, screenHeight * 0.95f), new Vector2(screenWidth * 0.99f, screenHeight * 0.95f), Color.Purple, 10);



           
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || _boss.Health == 0f)
                Exit();

            Vector2 mousePosition = Mouse.GetState().Position.FlipY(_graphics.GraphicsDevice.Viewport.Height);
            _player.Hitbox.changePosition(mousePosition);

            _boss.Hitbox.updateVel(mousePosition);
            _boss.Hitbox.seek();
            //_betweenMouseAndFollower = new Line(_player.Hitbox._position, _boss.Hitbox._position, _betweenMouseAndFollower._colour, _betweenMouseAndFollower.thickness);

            //if space pressed shoot a bullet
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && gameTick >= shootInterval)
            {
                Bullet bull = new Bullet(_player.Hitbox._position, 10, _boss.Hitbox._position, Color.OrangeRed);
                _player.shoot(bull);
                gameTick = 0;
            }
            else
            {
                 gameTick++;
            }

            //update location of each bullet
            foreach (Bullet bullet in _player._bullets)
            {
                bullet.seek();
            }

            //check if bullet has hit
            // todo remove a bulllet if off screen
            for (int i = _player._bullets.Count - 1; i >= 0; i--)
            {
                if (_boss.Hitbox.isInside(_player._bullets[i].hitbox._position))
                {
                    _player._bullets.Remove(_player._bullets[i]);
                    _boss.TakeDamage(_player.Damage);

                }
            }

            //update boss health bar
            float percentleft = _boss.GetHealthAsDecimal();
            float UpdatedX = BossHealthBar.end.X * percentleft;
            BossHealthBar.SetEnd(new Vector2 (UpdatedX, BossHealthBar.end.Y));
            


            

            // TODO: Add your update logic here                                                   
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _shapeBatcher.Draw(_player.Hitbox);
            _shapeBatcher.Draw(_boss.Hitbox);
            _shapeBatcher.Draw(BossHealthBar);
            //_shapeBatcher.Draw(_betweenMouseAndFollower);

            //Circle c = new Circle(_followingCircle._position - _mouseCircle._position + _followingCircle._position, _followingCircle._radius, Color.HotPink);
            //_shapeBatcher.Draw(c);

            foreach (Bullet bullet in _player._bullets)
            {
                _shapeBatcher.Draw(bullet);
            }





            
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
        
    }
}

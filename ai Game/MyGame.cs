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
using MonoGameLib.Items;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using MonoGame.ImGui;

//todo
//todo change movement so it takes keyboard input, not mouse input
//todo fix issues with polygon class
//todo add flies
//todo add flocking steering behaviour
//todo add pathfinding algorithm
//todo add blocks 



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
        
        


        //Entities
        private Player _player;
        private Enemy _boss;

        //shapes
        HealthBar BossHealthBar;
        HealthBar playerHealthBar;



        //test variables
        private ImGuiRenderer _guiRenderer;

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

            BossHealthBar = new HealthBar(new Vector2(screenWidth * 0.01f, screenHeight * 0.95f), new Vector2(screenWidth * 0.99f, screenHeight * 0.95f), Color.Purple, 30);
            playerHealthBar = new HealthBar(new Vector2(screenWidth * 0.65f, screenHeight * 0.05f), new Vector2(screenWidth * 0.99f, screenHeight * 0.05f), Color.Red);
           
            _shapeBatcher = new ShapeBatcher(this);


            //IMGui
            _guiRenderer = new ImGuiRenderer(this).Initialize().RebuildFontAtlas();




            base.Initialize();


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _font = this.Content.Load<SpriteFont>("MyFont");

            //use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || _boss.Health <= 0f || _player.Health <= 0f)
                Exit();

            Vector2 mousePosition = Mouse.GetState().Position.FlipY(_graphics.GraphicsDevice.Viewport.Height);
            _player.Hitbox.changePosition(mousePosition);

            _boss.Hitbox.updateVel(mousePosition);
            _boss.Hitbox.seek();

            //if space pressed shoot a bullet
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _player.gameTick >= _player.DealDamageInterval)
            {
                Bullet bull = new Bullet(_player.Hitbox._position, 1, _boss.Hitbox._position, Color.OrangeRed);
                _player.shoot(bull);
                _player.ResetGameTick();

            }
            else
            {
                _player.IncGameTick();
            }

            //update location of each bullet
            foreach (Bullet bullet in _player._bullets)
            {
                bullet.seek();
            }

            //check if bullet has hit
            for (int i = _player._bullets.Count - 1; i >= 0; i--)
            {
                if (_boss.Hitbox.isInside(_player._bullets[i].hitbox._position))
                {
                    _player._bullets.Remove(_player._bullets[i]);
                    _boss.TakeDamage(_player.Damage);

                    
                }
                
            }

            //remove a bullet if off screen
            for(int i = _player._bullets.Count - 1; i >= 0;i--)
            {
                Bullet bullet = _player._bullets[i];
                //check if bullet is less than screenwidth and more than 0
                if (bullet.hitbox._position.X < 0 || bullet.hitbox._position.X > screenWidth)
                {
                    _player._bullets.Remove(bullet);

                    
                }
                //check if bullet is less than screenheight and more than 0
                if (bullet.hitbox._position.Y < 0 || bullet._position.Y > screenHeight)
                {
                    _player._bullets.Remove(bullet);

                    
                }
            }

            //check if boss is in melee range to swing
            if(_boss.Hitbox.isInside(_player.Hitbox._position) && _boss.gameTick >= _boss.DealDamageInterval)
            {
                _player.TakeDamage(_boss.Damage);
                _boss.ResetGameTick();
            }
            else
            {
                _boss.IncGameTick();
            }

            //update boss health bar
            BossHealthBar.update(_boss.GetHealthAsDecimal());
            //update player health bar
            playerHealthBar.update(_player.GetHealthAsDecimal());
                                    
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _shapeBatcher.Draw(_player.Hitbox);
            _shapeBatcher.Draw(_boss.Hitbox);
            _shapeBatcher.Draw(BossHealthBar);
            _shapeBatcher.Draw(playerHealthBar);
            
            foreach (Bullet bullet in _player._bullets)
            {
                _shapeBatcher.Draw(bullet);
            }



            //IMGui
            /*
            _guiRenderer.BeginLayout(gameTime);

            ImGui.Begin("Player");

            ImGui.Button($"Health {_player.Health.ToString()}");
            ImGui.Button($"Health as Dec {_player.GetHealthAsDecimal().ToString()}");
            ImGui.Button(playerHealthBar.End.ToString());
            ImGui.Button($"game tick {_player.gameTick}");
            ImGui.Button($"shootInterval {_player.DealDamageInterval}");

            ImGui.End();


            ImGui.Begin("Boss Health");

            ImGui.Button($"Health {_boss.Health.ToString()}");
            ImGui.Button($"Health as Dec {_boss.GetHealthAsDecimal().ToString()}");
            ImGui.Button(BossHealthBar.End.ToString());
            ImGui.Button($"game tick {_boss.gameTick}");
            ImGui.Button($"shootInterval {_boss.DealDamageInterval}");

            ImGui.End();
            

            _guiRenderer.EndLayout();
            */

            
            



            base.Draw(gameTime);
        }
        
    }
}

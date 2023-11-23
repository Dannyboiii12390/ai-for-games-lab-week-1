using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ImGuiNET;
using MonoGameLib.Shapes;
using MonoGameLib.Entities;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;
using MonoGameLib.Items;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using MonoGame.ImGui;
using Microsoft.Xna.Framework.Input.Touch;
using MonoGameLib.FileHandlers;
using ai_Game.Classes.Helpers;
using ai_Game.Classes.Utilities;

//todo
//todo add flocking steering behaviour
//todo add pathfinding algorithm
//todo add blocks 
//read level info from file



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
        
        //Entities
        private Player _player;
        private Enemy _boss;
        private List<Fly> swarm = new List<Fly>();

        //shapes
        Arena arena = new Arena();

        //test variables
        private ImGuiRenderer _guiRenderer;
        bool inside;

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

            Circle playerCircle = new Circle(new Vector2(screenWidth/2, screenHeight/2), 15, Color.BlueViolet);
            Circle EnemyCircle = new Circle(new Vector2(screenWidth / 2 - 50, screenHeight / 2 - 50), 30, Color.Red);

            _player = new Player(100, 5, playerCircle, 30);
            _boss = new Enemy(100, 5, EnemyCircle, 35);

            HealthBar BossHealthBar = new HealthBar(new Vector2(screenWidth * 0.01f, screenHeight * 0.95f), new Vector2(screenWidth * 0.99f, screenHeight * 0.95f), Color.Purple, 30);
            HealthBar playerHealthBar = new HealthBar(new Vector2(screenWidth * 0.65f, screenHeight * 0.05f), new Vector2(screenWidth * 0.99f, screenHeight * 0.05f), Color.Red);
            
            _player.AddHealthBar(playerHealthBar);
            _boss.AddHealthBar(BossHealthBar);

            _shapeBatcher = new ShapeBatcher(this);

            //Arena
            arena = new Arena(GetBoard(Environment.CurrentDirectory + @"\Files\Level 1.JSON"));

            //Test
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

            //change player position
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _player.Move(new Vector2(0, _player.movespeed));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _player.Move(new Vector2(0, -_player.movespeed));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _player.Move(new Vector2(-_player.movespeed, 0));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _player.Move(new Vector2(_player.movespeed, 0));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                _boss.isInvincible = false;
            }
            
            _boss.Hitbox.updateVel(_player.Hitbox._position);
            _boss.Hitbox.seek();

            //if space pressed shoot a bullet
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && _player.gameTick >= _player.DealDamageInterval)
            {
                Bullet bull = new Bullet(_player.Hitbox._position, 1, 10, mousePosition, Color.OrangeRed);
                _player.shoot(bull);
                _player.ResetGameTick();
            }
            else
            {
                _player.IncGameTick();
            }

            //update location of each fly
            foreach (Fly fly in swarm)
            {
                
                fly.Hitbox.seek();
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

                    if ( _boss.Health <= _boss.MaxHealth * 0.5)
                    {
                        List<Fly> flies = _boss.CreateSwarm(10, _player.Hitbox._position);
                        foreach (Fly fly in flies)
                        {
                            swarm.Add(fly);
                        }
                    }
                }
                //check if bullet has hit obstacle
                else if (arena.isInside(_player._bullets[i].hitbox._position))
                {
                    _player._bullets.Remove(_player._bullets[i]);
                }
                
            }
            //check if fly has hit obstacle
            for(int i = swarm.Count - 1; i >= 0;i--)
            {
                if (arena.isInside(swarm[i].Hitbox._position))
                {
                    swarm.Remove(swarm[i]);
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

            // todo check no object is colliding with arena

            

            //update boss health bar
            _boss.healthBar.update(_boss.GetHealthAsDecimal());
            //update player health bar
            _player.healthBar.update(_player.GetHealthAsDecimal());

            //Test
                                    
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            
            GraphicsDevice.Clear(Color.DarkGray);
            _shapeBatcher.Draw(_player.Hitbox);
            _shapeBatcher.Draw(_boss.Hitbox);
            _shapeBatcher.Draw(_boss.healthBar);
            _shapeBatcher.Draw(_player.healthBar);
            
            
            foreach (Bullet bullet in _player._bullets)
            {
                _shapeBatcher.Draw(bullet);
            }
            foreach(Fly fly in swarm)
            {
                _shapeBatcher.Draw(fly);
            }
            foreach (Polygon poly in arena.Obstacles)
            {
                _shapeBatcher.Draw(poly);
            }

            //Test

            _guiRenderer.BeginLayout(gameTime);
            /*
            ImGui.Begin("Flies");
    
            foreach(Fly fly in swarm)
            {
                ImGui.Text($"Fly {fly.Hitbox._position.X} : {fly.Hitbox._position.Y}");
            }

            ImGui.End();
            */
            _guiRenderer.EndLayout();

            base.Draw(gameTime);
        }

        public List<Polygon> GetBoard(string pPath)
        {
            List<Square> obstacles;
            JSONFileHandler<Square> json = new JSONFileHandler<Square>(pPath);
            obstacles = json.Read();

            List<Polygon> polygons = new List<Polygon>();
            foreach (Square square in obstacles)
            {
                polygons.Add(square.hitbox);
            }

            return polygons;
        }
        


    }
}

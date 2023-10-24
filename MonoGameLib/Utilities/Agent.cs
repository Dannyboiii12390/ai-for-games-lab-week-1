using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ai_for_games_lab_week_1
{
    class Agent
    {
        public Microsoft.Xna.Framework.Vector2 Position { get; set; }
        public Microsoft.Xna.Framework.Vector2 Velocity { get; set;}
        public float Radius { get; set;}

        public Agent(Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Vector2 velocity, float radius)
        {
            Position = position;
            Velocity = velocity;
            Radius = radius;
        }

        public void update(float pSeconds) 
        {
            Position += Velocity * pSeconds;

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ai_for_games_lab_week_1
{
    class Agent
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set;}
        public float Radius { get; set;}

        public Agent(Vector2 position, Vector2 velocity, float radius)
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

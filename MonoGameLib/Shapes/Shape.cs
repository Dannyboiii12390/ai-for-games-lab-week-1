using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_for_games_lab_week_1.Shapes
{
    public abstract class Shape
    {

        public Vector2 _position { get; protected set; }
        public Vector2 _velocity { get; protected set; }
        public Microsoft.Xna.Framework.Color _colour { get; protected set; }
        

        public Shape(Vector2 pPosition, Microsoft.Xna.Framework.Color pColour)
        {
            _position = pPosition;
            _colour = pColour;
            

        }
        public abstract bool isInside(Vector2 pPosition);

        public void changeColour(Microsoft.Xna.Framework.Color c)
        {
            _colour = c;
        }
        public override string ToString()
        {
            return $"Shape with position {_position.ToString()}";
        }
        public void changeVelX(float velX)
        {
            _velocity = new Vector2 (velX, _velocity.Y);
        }
        public void changeVelY(float velY)
        {
            _velocity = new Vector2(_velocity.X, velY);
        }
        
        
    }

    
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Shapes
{   

    public abstract class Shape
    {
        
        public Vector2 _position { get; protected set; }
        public Vector2 _velocity { get; protected set; }



        private float coefficientOfSpeed = 0.015f;
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
        
        public void changeVelocity(Vector2 v)
        {
            _velocity = v;
        }

        public void updateVel(Vector2 pTarget)
        {


            //difference
            Vector2 v = _position - pTarget;

            //normalise
            v = Vector2.Normalize(v);

            //multiply by length between

            
            _velocity = v * getLengthBetween(pTarget) * coefficientOfSpeed;
           
            
        }
        
        private float getLengthBetween(Vector2 pTarget)
        {
            Vector2 delV = _position - pTarget;
            float len = delV.Length();

            return len;
        }
        public void seek()
        {
            _position = _position - _velocity;
        }
        



        
        
    }

    
}

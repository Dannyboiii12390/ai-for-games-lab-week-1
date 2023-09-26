
using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MonoGameLib
{
    public class Circle
    {
        public Vector2 position { get; set; } = Vector2.Zero;
        private int _x = 0;
        private int _y = 0;
        public Vector2 velocity {  get; set; } = new Vector2(40,40);
        public float _circleRadius { get; private set; } = 20f;
        public Color colour { get; private set; } = Color.White;
        

        public Circle(int px, int py)
        {
            _x = px;
            _y = py;
            position = new Vector2(px, py);
            
        }
        public Circle(int px, int py, float pRad)
        {
            _x = px;
            _y = py;
            position = new Vector2(px, py);

            _circleRadius = pRad;

        }
        public void changeColour(Color c) 
        {
            colour = c;
        }
        public override string ToString()
        {
            return position.ToString();
        }

        public void changeVelX(float v) 
        {
            velocity = new Vector2(v, velocity.Y);
        }
        public void changeVelY(float v)
        {
            velocity = new Vector2(velocity.X, v);
        }
    }
}

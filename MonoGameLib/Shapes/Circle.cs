
using ai_for_games_lab_week_1.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MonoGameLib
{
    public class Circle : Shape, IcanMove
    {
        public Vector2 position { get; set; } = Vector2.Zero;
        private int _x = 0;
        private int _y = 0;
        public Vector2 velocity {  get; set; } = new Vector2(40,40);
        public float _radius { get; private set; } = 20f;
        
        public Circle(int px, int py, float pRad = 20f) : base (new Vector2(px, py), Color.Red)
        {
            _radius = pRad;

        }
     
        public override string ToString()
        {
            return $"Circle with position {position.ToString()}";
        }

      
        public override bool isInside(Vector2 pPosition)
        {
            float dx = (_position.X - pPosition.X);
            float dy = (_position.Y - pPosition.Y);
            if ((dx * dx + dy * dy) < _radius*_radius)
            {
                return true;
            }
            return false;


            throw new NotImplementedException();


        }
    }
}

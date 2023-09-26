
using Microsoft.Xna.Framework;
using System;

namespace MonoGameLib
{
    public class Circle
    {
        public Vector2 position { get; private set; } = Vector2.Zero;
        private int _x = 0;
        private int _y = 0;
        

        public Circle(int px, int py)
        {
            _x = px;
            _y = py;
            position = new Vector2(px, py);



        }
        public override string ToString()
        {
            return position.ToString();
        }
    }
}

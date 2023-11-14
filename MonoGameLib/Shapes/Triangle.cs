using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Shapes
{
    public class Triangle : Shape
    {
        public Vector2 _position2 { get; private set; }
        public Vector2 _position3 { get; private set; }

        public Triangle(Vector2 pPosition, Vector2 p2, Vector2 p3, Microsoft.Xna.Framework.Color pColour) : base(pPosition, pColour)
        {
            _position2 = p2;
            _position3 = p3;

        }

        public override bool isInside(Vector2 point)
        {
            float Px = point.X - _position.X,
            Py = point.Y - _position.Y,
            V1x = _position2.X - _position.X,
            V1y = _position2.Y - _position.Y,
            V2x = _position3.X - _position.X,
            V2y = _position3.Y - _position.Y;

            float n = (Py * V1x - Px * V1y) / (V2y * V1x - V2x * V1y);
            float m = (Px - n * V2x) / V1x;
            
            if (float.IsNaN(m) || float.IsInfinity(m) || float.IsNegativeInfinity(m))
            {
                m = (_position.Y - point.Y) / (_position2.Y - point.Y);
            }

            return m >= 0 && m <= 1 && n >= 0 && n <= 1 && m + n <= 1;
        }

        
    }
}

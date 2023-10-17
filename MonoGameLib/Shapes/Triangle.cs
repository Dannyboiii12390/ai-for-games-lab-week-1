using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Shapes
{
    internal class Triangle : Shape
    {
        public Triangle(Vector2 pPosition, Color pColour) : base(pPosition, pColour)
        {

        }

        public override bool isInside(Vector2 pPosition)
        {
            throw new NotImplementedException();
        }
    }
}

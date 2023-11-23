using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLib.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Shapes
{   

    public abstract class Shape : AI
    {
        public Microsoft.Xna.Framework.Color _colour { get; protected set; }
        

        public Shape(Vector2 pPosition, Microsoft.Xna.Framework.Color pColour) : base(pPosition, Vector2.Zero, 0.015f)
        {
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


    }

    
}

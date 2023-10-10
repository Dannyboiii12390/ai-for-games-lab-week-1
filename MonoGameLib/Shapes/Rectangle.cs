using ai_for_games_lab_week_1.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Shapes
{
    public class Rectangle : Shape, IcanMove
    {
        public Vector2 velocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public Rectangle(Vector2 pPosition, Color pColour) : base(pPosition, pColour)
        {


        }

        public override bool isInside(Vector2 pPosition)
        {
            throw new NotImplementedException();
        }
    }
}

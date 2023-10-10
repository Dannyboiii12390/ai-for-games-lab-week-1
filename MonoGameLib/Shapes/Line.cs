using ai_for_games_lab_week_1.Shapes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Shapes
{
    public class Line : Shape
    {
        public Vector2 end { get; private set; }
        public int thickness{ get; private set; }
        

        public Line(Vector2 pPosition, Vector2 pEnd, Color pColour, int pThickness) : base(pPosition, pColour)
        {
            end = pEnd;
            thickness = pThickness;

        }

        public override bool isInside(Vector2 pPosition)
        {
            throw new NotImplementedException();
        }
    }
}

using Microsoft.Xna.Framework;
using MonoGameLib.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Items
{
    

    public class HealthBar
    {
        public Vector2 Position {  get; private set; }
        public Vector2 End {  get; private set; }
        public Line bar { get; private set; } 
        private Vector2 FullEnd;
        private Color colour;
        

        public HealthBar(Vector2 pPosition, Vector2 pEnd, Color pColour, int pThickness = 10)
        {
            this.Position = pPosition;
            this.End = pEnd;
            this.FullEnd = pEnd;
            this.colour = pColour;
            this.bar = new Line(pPosition, pEnd, pColour, pThickness);

        }

        public void update(float health)
        {
            float x = FullEnd.X - Position.X;
            x = x * health;
  
            End = new Vector2(Position.X + x, End.Y);

            bar = new Line(Position, End, colour, bar.thickness);
        }
    }
}

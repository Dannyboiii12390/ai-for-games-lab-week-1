using Microsoft.Xna.Framework;
using MonoGameLib.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Items
{
    

    class BossHealthBar
    {
        public Vector2 Position {  get; private set; }
        public Vector2 End {  get; private set; }

        public Line bar { get; private set; } 
        

        public BossHealthBar(Vector2 pPosition, Vector2 pEnd, Color pColour, int pThickness = 10)
        {
            this.Position = pPosition;
            this.End = pEnd;
            this.bar = new Line(pPosition, pEnd, pColour, pThickness);

        }

        public void Draw()
        {

        }





    }
}

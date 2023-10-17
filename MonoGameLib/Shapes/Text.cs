
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Shapes
{
    public class Text : Shape 
    {
        public string text { get; private set; }
        //public SpriteFont font { get; private set; }
        public Vector2 position { get; private set; }
        public Text (string pText, Vector2 pPosition, Color pColour) : base(pPosition , pColour)
        {
            text = pText;
            

        }

        public override bool isInside(Vector2 pPosition)
        {
            throw new NotImplementedException();
        }
    }
}

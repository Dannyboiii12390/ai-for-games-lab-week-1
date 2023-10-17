
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Shapes
{
    public class Rectangle : Shape
    {
        public float width { get; private set; }
        public float height { get; private set; }



        public Rectangle(Vector2 pPosition, float pWidth, float pHeight, Color pColour) : base(pPosition, pColour)
        {
            width = pWidth;
            height = pHeight;


        }

        

        public override bool isInside(Vector2 pPosition)
        {


            throw new NotImplementedException();
            
            
            //if (!(pPosition.X < _position.X + width && pPosition.X > _position.X) )
            //{
            //    return false;
            //}
            //if (!(pPosition.Y < _position.Y + height && pPosition.Y > _position.Y))
            //{
            //    return false;
            //}
            //return true;
        }
    }
}

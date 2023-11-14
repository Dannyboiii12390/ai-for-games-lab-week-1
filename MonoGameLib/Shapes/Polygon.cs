using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLib.Shapes
{
    public class Polygon : Shape
    {
        public  List<Triangle> triangles { get; private set; } = new List<Triangle>();


        public Polygon(List<Vector2> point,Color pColour) : base(point[0], pColour)
        {
            for (int i = 2; i < point.Count; i++)
            {
                triangles.Add(new Triangle(point[i - 2], point[i-1], point[i], pColour));
            }
            //triangles.Add(new Triangle(point[0], point[point.Count-1], point[point.Count-2], pColour));
        }

        public override bool isInside(Vector2 pPosition)
        {
            for(int i = 0; i < triangles.Count; i++)
            {
                if (triangles[i].isInside(pPosition)) return true;
            }
            return false;

        }

        
    }
}

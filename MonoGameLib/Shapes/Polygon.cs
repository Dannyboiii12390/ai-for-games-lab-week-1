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
        /* example of how vector points need to be organised (Z pattern)
            List<Vector2> v = new List<Vector2>();
            v.Add(new Vector2(200, 200));
            v.Add(new Vector2(250, 200));
            v.Add(new Vector2(200, 150));
            v.Add(new Vector2(250, 150));
        */

        public List<Triangle> triangles { get; private set; } = new List<Triangle>();
        public List<Vector2> points { get; private set; }

        public Polygon(List<Vector2> point,Color pColour) : base(point[0], pColour)
        {
            for (int i = 2; i < point.Count; i++)
            {
                triangles.Add(new Triangle(point[i - 2], point[i-1], point[i], pColour));
            }
            //triangles.Add(new Triangle(point[0], point[point.Count-1], point[point.Count-2], pColour));
            points = point;
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

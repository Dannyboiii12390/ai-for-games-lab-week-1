using Microsoft.Xna.Framework;
using MonoGameLib.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Items
{
    public class Arena
    {
        public List<Polygon> Obstacles { get; private set; } = new List<Polygon>();

        public Arena(List<Polygon> poly) 
        {
            /* example of how vector points need to be organised (Z pattern)
            List<Vector2> v = new List<Vector2>();
            v.Add(new Vector2(200, 200));
            v.Add(new Vector2(250, 200));
            v.Add(new Vector2(200, 150));
            v.Add(new Vector2(250, 150));
            */  
            Obstacles = poly;
        }
        public Arena()
        {

        }
        public void AddPolygon(Polygon p)
        {
            Obstacles.Add(p);
        }
        public void AddPolygon(List<Vector2> sides, Color colour)
        {
            Obstacles.Add(new Polygon(sides, colour));
        }





    }
}

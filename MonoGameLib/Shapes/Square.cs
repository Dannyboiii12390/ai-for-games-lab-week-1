using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Shapes
{
    public class Square
    {
        public Vector2 position { get; private set; }
        public float width { get; private set; }
        public float height { get; private set; }
        public Color color { get; private set; }
        public Polygon hitbox { get; private set; }
        public Square(float X, float Y, float width, float height)
        {
            this.position = new Vector2(X, Y);
            this.width = width;
            this.height = height;
            color = Color.Gray;
            List<Vector2> points = new List<Vector2>();
            points.Add(position);
            points.Add(new Vector2(position.X + width, position.Y));
            points.Add(new Vector2(position.X, position.Y + height));
            points.Add(new Vector2(position.X + width, position.Y + height));
            hitbox = new Polygon(points, color);


        }
    }
}

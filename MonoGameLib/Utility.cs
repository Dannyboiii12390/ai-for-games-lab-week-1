using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoGameLib
{
    public class Utility
    {
        public static bool IsInsideCircle(Vector2 pPoint, Vector2 pCircle, float pRadius)
        {
            return Vector2.DistanceSquared(pPoint, pCircle) < pRadius * pRadius;
        }
    }
    
}

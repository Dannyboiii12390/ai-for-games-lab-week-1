using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities
{
   public static class Utilities
    {
        public static Vector2 FlipY(this Point pPoint, float pScreenHeight)
        {
            return new Vector2(pPoint.X, pScreenHeight * (1f - pPoint.Y / pScreenHeight));
        }

        public static int GetRandNumber(int a, int b)
        {
            Random random = new Random();

            int randomNumber = random.Next(a, b + 1);

            return randomNumber;
        }
        public static float GetRandNumber(float a, float b)
        {
            Random random = new Random();

            float randVal = random.NextSingle();
            float dif = b - a;
            return a + randVal * dif;

        }

        /// <summary>
        /// pAboutPoint point the vector is rotating around.
        /// 
        /// pAngle radians. anti clockwise
        /// 
        /// </summary>
        /// <returns>
        /// new Vector2 that has been rotated by the angle given
        /// </returns>
        public static Vector2 Rotate(this Vector2 v, Vector2 pAboutPoint, float pAngle)
        {
           //x' = x cos(angle) - y sin(angle)
           //y' = x sin(angle) - y cos(angle)

            Vector2 norm = v - pAboutPoint;
            
            float x = norm.X;
            float y = norm.Y;

            float rotx = x*(float)Math.Cos(pAngle) - y*(float)Math.Sin(pAngle);
            float roty = x*(float)Math.Sin(pAngle) - y* (float)Math.Cos(pAngle);    

            Vector2 normadj = new Vector2(rotx , roty);
            normadj = normadj + pAboutPoint;

            return normadj;
        }


    }
}

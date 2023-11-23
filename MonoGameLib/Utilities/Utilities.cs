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


    }
}

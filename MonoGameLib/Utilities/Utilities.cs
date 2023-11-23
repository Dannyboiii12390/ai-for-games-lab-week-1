using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities
{
    public class Utilities
    {
        public static int GetRandNumber(int a, int b)
        {
            Random random = new Random();

            int randomNumber = random.Next(a, b + 1);

            return randomNumber;
        }
        public static float GetRandNumber(float a, float b)
        {
            int integer = GetRandNumber((int)a, (int)b);

            int dec = GetRandNumber(0, 99);
            float deci = dec / 100;

            return integer + deci;
        }

    }
}

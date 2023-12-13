using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameLib.Shapes;

namespace MonoGameLib.Items
{
    public class Bullet
    {
        public Circle Hitbox { get; private set; }
        public float Damage { get; private set; }
        public Vector2 Position { get { return Hitbox._position; } }
        


        public Bullet(Vector2 pPosition, int size, float pDamage, Vector2 pTarget ,Color pColour)
        {
            Hitbox = new Circle(pPosition, size, pColour);
            Damage = pDamage;
            Hitbox.changeCoefficientSpeed(0.01f);
            

        }

        public bool isInside(Vector2 pPosition)
        {
            return Hitbox.isInside(pPosition);
        }

        
    }
}

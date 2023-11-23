using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameLib.Shapes;

namespace MonoGameLib.Items
{
    public class Bullet : Shape
    {
        public Circle hitbox { get; private set; }
        public float Damage { get; private set; }
        


        public Bullet(Vector2 pPosition, int size, float pDamage, Vector2 pTarget ,Color pColour) : base(pPosition, pColour)
        {
            hitbox = new Circle(pPosition, size, pColour);
            Damage = pDamage;
            coefficientOfSpeed = 2f;
            updateVel(pTarget);

        }

        public override void updateVel(Vector2 pTarget)
        {
            //difference
            Vector2 v = _position - pTarget;

            //normalise
            v = Vector2.Normalize(v);

            //multiply by length between


            _velocity = v * coefficientOfSpeed;

        }

        public override bool isInside(Vector2 pPosition)
        {
            return hitbox.isInside(pPosition);
        }

        public override void seek()
        {
            
            hitbox.changePosition(hitbox._position - _velocity);

        }
    }
}

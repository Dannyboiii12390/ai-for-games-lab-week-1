using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Shapes
{
    public class Bullet : Shape
    {
        public Circle hitbox { get; private set; }
        public float Damage { get; private set; }


        public Bullet(Vector2 pPosition,float pDamage, Vector2 pTarget ,Color pColour) : base(pPosition, pColour)
        {
            hitbox = new Circle(pPosition, 1, pColour);
            Damage = pDamage;
            coefficientOfSpeed = 0.25f;
            updateVel(pTarget);

        }

        public override void updateVel(Vector2 pTarget)
        {
            base.updateVel(pTarget);
            _velocity = -_velocity;
        }

        public override bool isInside(Vector2 pPosition)
        {
            return hitbox.isInside(pPosition);
        }
    }
}

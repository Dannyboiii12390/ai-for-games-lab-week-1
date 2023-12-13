using Microsoft.Xna.Framework;
using MonoGameLib.Shapes;
using MonoGameLib.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Entities
{
    public class Fly : Entity
    {
        public float minSeparation { get; private set; } = 10;
        public float maxCohesion { get; private set; } = 20;
        public override Circle Hitbox { get; protected set; }
        public float Radius { get { return Hitbox._radius; } }
        public float maxForce { get; private set; } = 20;
        public float maxSpeed { get; private set; } = 5;

        public Fly(Circle circle, Vector2 pTarget, float pHealth = 1, float pDamage = 1, int pDamageInterval = 0) : base(pHealth, pDamage, pDamageInterval)
        {
            Hitbox = circle;
            Hitbox.updateVel(pTarget);
            Hitbox._velocity.Normalize();
            Hitbox.changeVelocity(Hitbox._velocity * (3f + Utilities.Utilities.GetRandNumber(0f, 1f))); 

        }

        



    }
}

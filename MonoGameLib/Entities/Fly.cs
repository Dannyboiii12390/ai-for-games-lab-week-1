using MonoGameLib.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Entities
{
    public class Fly : Entity
    {
        public override Circle Hitbox { get; protected set; }

        public Fly(Circle circle, float pHealth = 1, float pDamage = 1, int pDamageInterval = 0) : base(pHealth, pDamage, pDamageInterval)
        {
            Hitbox = circle;
            Hitbox.ChangeSteeringMethod(Hitbox.seek);
            
        }
        



    }
}

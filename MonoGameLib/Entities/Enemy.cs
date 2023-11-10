using MonoGameLib.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Entities
{
    public class Enemy : Entity
    {
        public override Circle Hitbox { get; protected set; }

        
        

        public Enemy(float pHealth, float pDamage, Circle pHitbox) : base(pHealth, pDamage)
        {
            Hitbox = pHitbox;

            



        }

    }
}

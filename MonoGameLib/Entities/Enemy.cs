using MonoGameLib.Shapes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        public Enemy(float pHealth, float pDamage, Circle pHitbox, int pDealDamageInterval) : base(pHealth, pDamage, pDealDamageInterval)
        {
            Hitbox = pHitbox;

        }
        public List<Fly> CreateSwarm(int Amount)
        {
            List<Fly> swarm = new List<Fly>();
            for(int i = 0; i < Amount; i++)
            {
                Fly fly = new Fly(new Circle(new Microsoft.Xna.Framework.Vector2 (Hitbox._position.X+i, Hitbox._position.Y*1.1f), 1, Microsoft.Xna.Framework.Color.Yellow));
                swarm.Add(fly);
            }
            return swarm;
        }

    }
}

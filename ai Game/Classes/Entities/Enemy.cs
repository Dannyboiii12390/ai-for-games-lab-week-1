using ai_Game.Classes.Entities;
using Microsoft.Xna.Framework;
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
        public Swarm CreateSwarm(int Amount, Vector2 pTarget)
        {
            List<Fly> swarm = new List<Fly>();
            Swarm s = new Swarm();
            for(int i = 0; i < Amount; i++)
            {
                Fly fly = new Fly(new Circle(new Vector2 (Hitbox._position.X+i, Hitbox._position.Y*1.1f), 1, Microsoft.Xna.Framework.Color.Yellow), pTarget);
                fly.Hitbox.coefficientOfSpeed = 0.02f;
                swarm.Add(fly);
            }


            s.Add(swarm);

            return s;
        }

    }
}

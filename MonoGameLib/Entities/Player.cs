using Microsoft.Xna.Framework;
using MonoGameLib;
using MonoGameLib.Items;
using MonoGameLib.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Entities
{
    public class Player : Entity
    {
        public override Circle Hitbox { get; protected set; }
        public List<Bullet> _bullets { get; protected set; } = new List<Bullet>();
        public float movespeed { get; protected set; } = 1.25f;

        

        public Player(float pHealth, float pDamage, Circle pHitbox) : base(pHealth, pDamage)
        {
            Hitbox = pHitbox;

        }
        public Player(float pHealth, float pDamage, Circle pHitbox, int pDealDamageInterval) : base(pHealth, pDamage, pDealDamageInterval)
        {
            Hitbox = pHitbox;

        }
        public void shoot(Bullet bullet)
        {
            _bullets.Add(bullet);
        }
        public void Move(Vector2 v)
        {
            Hitbox.changePosition(Hitbox._position + v);
        }

       
    }
}

using MonoGameLib.Items;
using MonoGameLib.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib
{
    public abstract class Entity
    {        
        public float Health { get; protected set; }
        public float MaxHealth { get; protected set; }
        public float Damage { get; protected set; }
        public abstract Circle Hitbox { get; protected set; }
        public int DealDamageInterval { get; protected set; }
        public int gameTick { get; private set; } = 0;
        public bool isInvincible { get; set; } = false;
        public HealthBar healthBar { get; protected set; } = null;
 
        public Entity(float pHealth, float pDamage, int pDamageInterval = 10) 
        { 
            Health = pHealth;
            MaxHealth = pHealth;
            Damage = pDamage;
            DealDamageInterval = pDamageInterval;
            
        }

        public virtual void TakeDamage(float pDamage)
        {
            if (isInvincible) { return; }
            Health -= pDamage;
        }

        public float GetHealthAsDecimal()
        {
            return (Health / MaxHealth);
        }
        public void IncGameTick()
        {
            gameTick++;
        }
        public void ResetGameTick()
        {
            gameTick = 0;
        }
        public void AddHealthBar(HealthBar hb)
        {
            healthBar = hb;
        }


    }
}

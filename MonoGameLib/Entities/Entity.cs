using MonoGameLib.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib
{
    public abstract class Entity
    {        

        //static int nextID = 0;
        //private int ID;
        public float Health { get; protected set; }
        public float MaxHealth { get; protected set; }
        public float Damage { get; protected set; }
        public abstract Circle Hitbox { get; protected set; }
        public int DealDamageInterval { get; protected set; }
        public int gameTick { get; private set; } = 0;



        public Entity(float pHealth, float pDamage, int pDamageInterval = 10) 
        { 
            Health = pHealth;
            MaxHealth = pHealth;
            Damage = pDamage;
            DealDamageInterval = pDamageInterval;
            //ID = nextID;
            //nextID++;
        }

        public void TakeDamage(float pDamage)
        {
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


    }
}

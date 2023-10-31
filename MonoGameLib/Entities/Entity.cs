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

        static int nextID = 0;
        private int ID;
        public float Health { get; protected set; }
        public float MaxHealth { get; protected set; }
        public float Damage { get; protected set; }
        public abstract Circle Hitbox { get; protected set; }



        public Entity(float pHealth, float pDamage) 
        { 
            Health = pHealth;
            MaxHealth = pHealth;
            Damage = pDamage;
            ID = nextID;
            nextID++;
        }

        public void TakeDamage(float pDamage)
        {
            Health -= pDamage;
        }


    }
}

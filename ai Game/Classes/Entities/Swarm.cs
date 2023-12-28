using Microsoft.Xna.Framework;

using MonoGameLib.Entities;
using MonoGameLib.Shapes;
using Microsoft.Xna.Framework.Content;
using MonoGameLib.Entities;
using MonoGameLib.Items;
using MonoGameLib.Shapes;
using MonoGameLib.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_Game.Classes.Entities
{
    public class Swarm
    {

        public List<Fly> flies { get; private set; } = new List<Fly>();
        public List<Circle> Hitboxes { get { return GetHitboxes(); } }


        public Swarm() { }



        public void Add(Fly fly)
        {
            flies.Add(fly);
        }
        public void Add(List<Fly> flys) 
        {
            foreach (Fly fly in flys)
            {
                Add(fly);
            }
        }

        public void Flock(Vector2 pTarget)
        {
            foreach (Fly fly in flies)
            {
                fly.Hitbox.Flock(Circle.CastToAI(Hitboxes), pTarget);
            }
        }

        private List<Circle> GetHitboxes()
        {
            List<Circle> hitboxes = new List<Circle>();

            foreach (Fly fly in flies)
            {
                hitboxes.Add(fly.Hitbox);
            }
            return hitboxes;
        }
        
        
    }
}

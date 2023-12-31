﻿using Microsoft.Xna.Framework;
using MonoGameLib.Shapes;
using System;

namespace ai_Game.Classes.Utilities
{
    internal static class Utilities
    {
        /// <summary>
        /// pPdwith.
        /// 
        /// pDirection is the direction the moveable object will do in.
        /// 
        /// pShape is the hitbox of the moving onject.
        /// 
        /// pSpeed is the speed the object is moving at.
        /// </summary>

        /// <returns>
        /// new Vector2 new velocity the object (Shape needs its position updated by this amount). 
        /// </returns>
        public static Vector2 ManagePosition(Vector2 pPos, Vector2 pDirection, Shape pShape, float pSpeed)
        {
            bool inside = !pShape.isInside(pPos);
            if (inside)
           {
                Vector2 v = pDirection * pSpeed;

                return v;
            }
            return Vector2.Zero;
            
        }
    }
}

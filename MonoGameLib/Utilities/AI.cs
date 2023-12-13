using ai_for_games_lab_week_1;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities
{
    public abstract class AI
    {
        public Vector2 _velocity { get; protected set; }
        public Vector2 _position { get; protected set; }

        public float coefficientOfSpeed {get; protected set; }  
        private float variance = Utilities.GetRandNumber(0, 3);

        public AI(Vector2 pPosition, Vector2 pVelocity, float pCoefficientOfSpeed)
        {
            _position = pPosition;
            _velocity = pVelocity;
            coefficientOfSpeed = pCoefficientOfSpeed;
        }

        //utilities
        public void changePosition(Vector2 pPos)
        {
            _position = pPos;
        }

        public void changeVelocity(Vector2 v)
        {
            _velocity = v;
        }
        public void changeCoefficientSpeed(float pSpeed)
        {
            coefficientOfSpeed = pSpeed;
        }

        public virtual void updateVel(Vector2 pTarget)
        {
            //difference
            Vector2 v = _position - pTarget;

            //normalise
            v = Vector2.Normalize(v);

            //multiply by length between


            _velocity = v * getLengthBetween(pTarget) * coefficientOfSpeed;

        }
        public virtual void updateVel(Vector2 pTarget, float pSpeed)
        {
            //difference
            Vector2 v = _position - pTarget;

            //normalise
            v = Vector2.Normalize(v);

            _velocity = v * pSpeed;
        }

        private float getLengthBetween(Vector2 pTarget)
        {
            Vector2 delV = _position - pTarget;
            float len = delV.Length();

            return len;
        }

        //steering behaviours
        public virtual Vector2 Seek(Vector2 pPosition)
        {
            updateVel(pPosition);
            return Seek();
        }
        public virtual Vector2 Seek()
        {
            return (_position - _velocity);
        }
        
        public virtual Vector2 Evade()
        {
            Vector2 v = _velocity.Rotate(_position, variance);
            v.Normalize();
            return _position + v*_velocity;
        }
    }
}

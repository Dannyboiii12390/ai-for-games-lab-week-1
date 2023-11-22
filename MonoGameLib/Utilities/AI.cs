using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities
{
    public abstract class AI
    {
        public delegate void SteeringMethod();
        public SteeringMethod ai;
        public Vector2 _velocity { get; protected set; }
        public Vector2 _position { get; protected set; }

        protected float coefficientOfSpeed;

        public AI(Vector2 pPosition, Vector2 pVelocity, float pCoefficientOfSpeed, SteeringMethod pAI)
        {
            _position = pPosition;
            _velocity = pVelocity;
            coefficientOfSpeed = pCoefficientOfSpeed;
            ai = pAI;
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

        public virtual void updateVel(Vector2 pTarget)
        {


            //difference
            Vector2 v = _position - pTarget;

            //normalise
            v = Vector2.Normalize(v);

            //multiply by length between


            _velocity = v * getLengthBetween(pTarget) * coefficientOfSpeed;


        }

        private float getLengthBetween(Vector2 pTarget)
        {
            Vector2 delV = _position - pTarget;
            float len = delV.Length();

            return len;
        }

        //steering behaviours
        public void ChangeSteeringMethod(SteeringMethod pAI)
        {
            ai = pAI;
        }

        //set useAI to one of these
        public virtual void seek()
        {
            _position = _position - _velocity;
        }
        
        public virtual void Evade()
        {
            throw new NotImplementedException();
        }
        public virtual void Flock()
        {
            throw new NotImplementedException();
        }
        public virtual void Separation()
        {
            throw new NotImplementedException();
        }
        public virtual void Cohesion()
        {
            throw new NotImplementedException();
        }
        public virtual void Alignment()
        {
            throw new NotImplementedException();
        }





    }
}

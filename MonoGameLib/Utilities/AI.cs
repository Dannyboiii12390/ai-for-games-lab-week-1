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

        protected float coefficientOfSpeed;
        private float variance = Utilities.GetRandNumber(0, 3);

        private float minSeparation = 5;
        private float maxSeparation = 10;
        

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
        public virtual void seek()
        {
            _position = _position - _velocity;
        }
        
        public virtual void Evade()
        {
            Vector2 v = _velocity.Rotate(_position, variance);
            v.Normalize();
            _position = _position + v*_velocity;
        }
        public virtual void Flock()
        {
            throw new NotImplementedException();
        }
        public virtual void Separation(List<AI> agents) // move away from those entities we are too close too
        {
            Vector2 totalForce = Vector2.Zero;
            int neighboursCount = 0;

            //foreach agent
            for (int i = 0; i <agents.Count; i++)
            {
                var a = agents[i];
                //that is not us
                if (a != this)
                {
                    float distance = (_position - a._position).Length();
                    //that is within the distance we want to separate from
                    if (distance <minSeparation && distance > 0)
                    {
                        //calculate a vector from the other agents to us
                        var pushForce = _position - a._position;
                        //scale it based on how close they are compared to our radius
                        //and add it to the sum
                        totalForce = totalForce + pushForce*coefficientOfSpeed;
                        neighboursCount++;
                    }
                }
            }

            if (neighboursCount != 0)
            {
                totalForce = totalForce / neighboursCount;
                _position = _position - totalForce;
            }
            //not tested yet
        }
        public virtual void Cohesion() // move nearer to those entities we are near but not near enough to
        {
            throw new NotImplementedException();
        }
        public virtual void Alignment() // change our direction to be closer to our neighbours
        {
            throw new NotImplementedException();
        }





    }
}

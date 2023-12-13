using Microsoft.Xna.Framework;
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
        public List<Fly> agents { get; private set; } = new List<Fly>();
        public List<Line> forces { get; private set; } = new List<Line>();
        
        public Swarm() 
        { 
            
        }
        public void AddFly(Fly fly)
        {
            agents.Add(fly);
            forces.Add(new Line(Vector2.Zero, Vector2.Zero, Color.White, 1));
            forces.Add(new Line(Vector2.Zero, Vector2.Zero, Color.White, 1));
            forces.Add(new Line(Vector2.Zero, Vector2.Zero, Color.White, 1));
            forces.Add(new Line(Vector2.Zero, Vector2.Zero, Color.White, 1));
        }
        public void AddFlies(List<Fly> flies)
        {
            
            foreach (Fly fly in flies)
            {
                AddFly(fly);
            }
            
        }
        public virtual Vector2 Separation(Fly agent) // move away from those entities we are too close too
        {
            Vector2 totalForce = Vector2.Zero;
            var neighboursCount = 0;

            //for each agent
            for (var i = 0; i < agents.Count; i++)
            {
                Fly a = agents[i];
                //that is not us
                if (a != agent)
                {
                    float distance = (agent.Position - a.Position).Length();
                    //that is within the distance we want to separate from
                    if (distance < agent.minSeparation && distance > 0)
                    {
                        //Calculate a Vector from the other agent to us
                        float pushForce = (agent.Position - a.Position).Length();
                        //Scale it based on how close they are compared to our radius
                        // and add it to the sum
                        totalForce.X = totalForce.X + (pushForce / agent.Radius);
                        totalForce.Y = totalForce.Y + (pushForce / agent.Radius);
                        neighboursCount++;
                    }
                }
            }

            if (neighboursCount == 0)
            {
                return Vector2.Zero;
            }

            //Normalise the force back down and then back up based on the maximum force
            totalForce = totalForce/neighboursCount;
            return totalForce * agent.maxForce;
            //not tested yet
            }
        public virtual Vector2 Cohesion(Fly agent) // move nearer to those entities we are near but not near enough to
        {
            //Start with just our position
            Vector2 centerOfMass = agent.Position;
            int neighboursCount = 1;

            for (int i = 0; i < agents.Count; i++)
            {
                Fly a = agents[i];
                if (a != agent)
                {
                    float distance = (agent.Position - a.Position).Length();
                    if (distance < agent.maxCohesion)
                    {
                        //sum up the position of our neighbours
                        centerOfMass = centerOfMass + a.Position;
                        neighboursCount++;
                    }
                }
            }

            if (neighboursCount == 1)
            {
                return Vector2.Zero;
            }

            //Get the average position of ourself and our neighbours
            centerOfMass = centerOfMass/neighboursCount;

            //seek that position
            return agent.Hitbox.Seek(centerOfMass);
        }
        public virtual Vector2 Alignment(Fly agent) // change our direction to be closer to our neighbours
        {
            var averageHeading = Vector2.Zero;
            var neighboursCount = 0;

            //for each of our neighbours (including ourself)
            for (var i = 0; i < agents.Count; i++)
            {
                var a = agents[i];
                var distance = (agent.Position-a.Position).Length();
                //That are within the max distance and are moving
                if (distance < agent.maxCohesion && a.Hitbox._velocity.Length() > 0)
                {
                    //Sum up our headings
                    a.Hitbox._velocity.Normalize();
                    averageHeading = averageHeading + a.Hitbox._velocity;
                    neighboursCount++;
                }
            }

            if (neighboursCount == 0)
            {
                return Vector2.Zero;
            }

            //Divide to get the average heading
            averageHeading = averageHeading/neighboursCount;

            //Steer towards that heading
            var desired = averageHeading * agent.maxSpeed;
            var force = desired - agent.Hitbox._velocity;
            return force * agent.maxForce / agent.maxSpeed;
        }

        public void FindNeighbourhoods()
        {
            //for(int i = 0; i < agents.Count; i++)
            //{
            //    agents[i].ClearNeighbourhood();
            //}

            //for(int i = 0; i < agents.Count; i++)
            //{
            //    for(int j = i; j < agents.Count; j++)
            //    {
            //        if (agents[i].IsInNeighbourhood(agents[j]))
            //        {
            //            agents[i].AddNeighbour(agents[j]);
            //            agents[j].AddNeighbour(agents[i]);
            //        }
            //    }
            //}
        }

        public virtual void Flock(Fly agent, Vector2 pDestination)
        {
            List<Vector2> forceToApply = new List<Vector2>();
            //Calculate steering and flocking forces for all agents
            for (int i = agents.Count - 1; i >= 0; i--)
            {
                agent = agents[i];

                //Work out our behaviours
                //var seek = agent.Hitbox.Seek(pDestination);
                //forces[i + 0] = new Line(agent.Position, seek, Color.Red, 10);

                var separation = Separation(agent);
                forces[i + 1] = new Line(agent.Position, separation, Color.Blue, 10);

                var cohesion = Cohesion(agent);
                forces[i + 2] = new Line(agent.Position, cohesion, Color.Green, 10);

                //var alignment = Alignment(agent);
                //forces[i + 3] = new Line(agent.Position, alignment, Color.Yellow, 10);

                //Combine them to come up with a total force to apply, decreasing the effect of cohesion
                Vector2 v = Vector2.Zero;
                //v = v + seek;
                v = v + separation;
                v = v + cohesion * 0.1f;
                //v = v + alignment;
                forceToApply.Add(v);
            }

            //Move agents based on forces being applied (aka physics)
            for (int i = agents.Count - 1; i >= 0; i--)
            {
                agent = agents[i];

                //Apply the force
                agent.Hitbox.changeVelocity(agent.Hitbox._velocity + forceToApply[i]);

                //Cap speed as required
                var speed = agent.Hitbox._velocity.Length();
                if (speed > agent.maxSpeed)
                {
                    agent.Hitbox.changeVelocity(agent.Hitbox._velocity * agent.maxSpeed / speed);
                }

                //Move a bit
                agent.Hitbox.changePosition(agent.Position + agent.Hitbox._velocity*agent.Hitbox.coefficientOfSpeed);
            }
        }
    }
}

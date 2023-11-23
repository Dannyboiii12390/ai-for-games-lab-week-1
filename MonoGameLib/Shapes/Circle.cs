﻿

using Microsoft.Xna.Framework;
using System;
using System.Runtime.CompilerServices;
using System.Threading;


namespace MonoGameLib.Shapes
{
    public class Circle : Shape
    {
        //public Vector2 position { get; set; } = Vector2.Zero;
        public float _radius { get; private set; }
        public int numVertices { get; private set; } = 100;
        public int thickness { get; private set; } = 2;


   
        public Circle(Vector2 position, float radius, Color pColour) : base(position, pColour)
        {
            _radius=radius;
            
        }
        

        public override string ToString()
        {
            return $"Circle with position {_position.ToString()}";
        }
        
        public override bool isInside(Vector2 pPosition)
        {
            return (_position - pPosition).LengthSquared() < _radius * _radius;
        }
        

        
    }
}

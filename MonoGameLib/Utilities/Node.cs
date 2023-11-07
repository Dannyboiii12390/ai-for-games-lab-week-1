using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities
{
    public class Node<T>
    {
        static int nextID = 0;
        public int ID { get; private set; }
        public Vector2 Position { get; private set; }

        public Node(Vector2 pPosition)
        {
            Position = pPosition;
            ID = nextID;
            nextID++;
        }
    }
}

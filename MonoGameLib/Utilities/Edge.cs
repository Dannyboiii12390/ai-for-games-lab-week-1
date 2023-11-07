using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities
{
    public class Edge<T>
    {
        static int nextID = 0;
        public int from {get; private set;}
        public int to { get; private set; }
        public int ID { get; private set; }

        public Edge(int FromID, int ToID)
        {
            from = FromID;
            to = ToID;
            ID = nextID;
            nextID++;

        }
    }
}

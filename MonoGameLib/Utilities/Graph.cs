using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities
{
    public class Graph<T>
    {
        private List<Node<T>> nodes;
        private List<Edge<T>> edges;

        public Graph()
        {
            nodes = new List<Node<T>>();
            edges = new List<Edge<T>>();

        }

        public IEnumerable<Node<T>> Nodes { get { return nodes; } }
        public IEnumerable<Edge<T>> Edges { get {  return edges; } }

        public int NodeCount { get { return nodes.Count; } }

        public void AddEdge(int pFromID, int pToID)
        {
            bool from = false;
            bool to = false;
            foreach (Node<T> node in nodes)
            {
                if (node.ID == pFromID)
                {
                    from = true;

                }
                if (node.ID == pToID)
                {
                    to = true;
                }
                if (from && to)
                {
                    edges.Add(new Edge<T>(pFromID, pToID));
                }
            }
        }
        public Node<T> GetNode(int pID)
        {
            for(int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].ID == pID)
                {
                    return nodes[i];
                }
            }
            return null;
        }
        public Edge<T> GetEdge(int pID)
        {
            for (int i = 0;i < edges.Count; i++)
            {
                if (edges[i].ID == pID)
                {
                    return edges[i];
                }
            }
            return null;

        } 
        public void RemoveNode(int pID)
        {
            for (int i = 0; i<nodes.Count; i++)
            {
                if (nodes[i].ID == pID)
                {
                    for (int j = edges.Count - 1; j >= 0; j--)
                    {
                        if (edges[j].from == pID)
                        {
                            edges.RemoveAt(j);
                        }
                    }
                }
            }
        }
        public float getEdgeCost(int pID)
        {
            Edge<T> edge = GetEdge(pID);
            if (edge == null)
            {
                return -1f;
            }

            return MathF.Round((GetNode(edge.from).Position - GetNode(edge.to).Position).Length() * 0.1f, 1);

        }






    }
}

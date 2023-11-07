using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities.Path_Finding.Dijkstras
{
    public class Dijkstras
    {
        public List<NodeInfo> VisitedNodes { get; private set; } = new List<NodeInfo>();
        public List<NodeInfo> NodeQueue { get; private set; }

        private bool IsFinished = false;
        float _timeTillStep = 1;
        float stepInterval = 1;

        public Dijkstras() 
        {
            if (NodeQueue.Count > 0)
            {
                NodeQueue.Sort();
                NodeInfo currentNode = NodeQueue[NodeQueue.Count - 1];
                NodeQueue.RemoveAt(NodeQueue.Count - 1);

                // more new code goes here
            }
        }


        public void Update(float pSeconds)
        {
            if (IsFinished)
            {
                return;
            }

            _timeTillStep -= pSeconds;

            if (_timeTillStep > 0)
            {
                return;
            }

            _timeTillStep = stepInterval;

            // new code goes here!
        }
    }
}

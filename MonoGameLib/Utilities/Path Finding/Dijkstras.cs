using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLib.Utilities.Path_Finding.Dijkstras
{
    public class Dijkstra<T>
    {
        bool _isFinished = false;
        float _timeTillStep = 0f;
        float _stepInterval = 0.5f;
        
        public int ID { get; set; }
        public float LowestCostToNode { get; set; }

        //list of nodes we want to look at next
        List<NodeInfo> _nodeQueue = new List<NodeInfo>();
        //list of nodes that have had all their joining edges put on the nodeQueue
        List<NodeInfo> _visitedNodes = new List<NodeInfo>();


        public Dijkstra(int pID, float pCostToNode) 
        { 
            ID = pID;
            LowestCostToNode = pCostToNode;
        }

        public int CompareTo(NodeInfo pOther)
        {
            if (LowestCostToNode > pOther.LowestCostToNode)
            {
                return -1;
            }
            else if (LowestCostToNode < pOther.LowestCostToNode) 
            {
                return 1;
            }
            return 0;
        }

        public void update(float pSeconds)
        {
            if (_isFinished)
            { 
                return;
            }

            _timeTillStep -= pSeconds;

            if (_timeTillStep > 0)
            {
                return;
            }
            _timeTillStep = _stepInterval;

            //new code goes here
            
        }

    }
}

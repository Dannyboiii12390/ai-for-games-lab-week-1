using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameLib.Utilities;

namespace MonoGameLib.Utilities.Path_Finding.Dijkstras
{
    public class NodeInfo : IComparable<NodeInfo>
    {
        public NodeInfo(int pID, float pCostToNode)
        {
            ID = pID;
            LowestCostToNode = pCostToNode;
        }

        public int ID { get; private set; }
        public float LowestCostToNode { get; set; }

        public int CompareTo(NodeInfo pOther)
        {
            if (LowestCostToNode > pOther.LowestCostToNode)
                return -1;
            else if (LowestCostToNode < pOther.LowestCostToNode)
                return 1;
            return 0;
        }
    }
    
}

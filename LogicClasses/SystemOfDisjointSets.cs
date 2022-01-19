using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicClasses
{
    class SystemOfDisjointSets
    {
        public List<Set> Sets;

        public SystemOfDisjointSets()
        {
            Sets = new List<Set>();
        }

        public void AddEdgeInSet(Edge edge)
        {
            Set setA = Find(edge.VertexA);
            Set setB = Find(edge.VertexB);

            if (setA != null && setB == null)
            {
                setA.AddEdge(edge);
            }
            else if (setA == null && setB != null)
            {
                setB.AddEdge(edge);
            }
            else if (setA == null && setB == null)
            {
                Set set = new Set(edge);
                Sets.Add(set);
            }
            else if (setA != null && setB != null)
            {
                if (setA != setB)
                {
                    setA.Union(setB, edge);
                    Sets.Remove(setB);
                }
            }
        }

        public Set Find(string vertex)
        {
            foreach (Set set in Sets)
            {
                if (set.Contains(vertex)) return set;
            }
            return null;
        }
    }
}

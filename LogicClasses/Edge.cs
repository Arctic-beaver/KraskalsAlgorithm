
using System;

namespace LogicClasses
{
    public class Edge : IComparable<Edge>
    {
        public int EdgeWeight { get; set; }
        public string VertexA { get; set; }
        public string VertexB { get; set; }


        public Edge(string vertexA, string vertexB, int weight)
        {
            VertexA = vertexA;
            VertexB = vertexB;
            EdgeWeight = weight;
        }

        public int CompareTo(Edge other)
        {
            if (other == null) return 1;
            return EdgeWeight.CompareTo(other.EdgeWeight);
        }
    }
}

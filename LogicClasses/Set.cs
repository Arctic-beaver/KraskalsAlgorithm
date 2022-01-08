using System.Collections.Generic;

namespace LogicClasses
{
    public class Set
    {
        public Graph SetGraph;
        public List<string> Vertices;

        public Set(Edge edge)
        {
            SetGraph = new Graph(edge);

            Vertices = new List<string>();
            Vertices.Add(edge.VertexA);
            Vertices.Add(edge.VertexB);
        }

        public void Union(Set set, Edge connectingEdge)
        {
            SetGraph.Add(set.SetGraph);
            Vertices.AddRange(set.Vertices);
            SetGraph.Add(connectingEdge);
        }

        public void AddEdge(Edge edge)
        {
            SetGraph.Add(edge);
            Vertices.Add(edge.VertexA);
            Vertices.Add(edge.VertexB);
        }

        public bool Contains(string vertex)
        {
            return Vertices.Contains(vertex);
        }
    }
}

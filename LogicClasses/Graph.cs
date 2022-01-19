using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LogicClasses
{
    public class Graph : IEnumerable<Edge>
    {
        private List<Edge> _graph;

        public Graph()
        {
            _graph = new List<Edge>();
        }

        public Graph(Edge val)
        {
            Edge[] value = new Edge[] { val };

            _graph = new List<Edge>(value);
        }

        public void Add(Graph graph)
        {
            foreach (Edge edge in graph)
            {
                _graph.Add(edge);
            }
        }

        public void Add(Edge edge)
        {
            _graph.Add(edge);
        }

        public int GetWeight()
        {
            int weight = 0;
            foreach (Edge edge in _graph)
            {
                weight += edge.EdgeWeight;   
            }
            return weight;
        }

        public Graph FindMinimumSpanningTree()
        {
            Sort();
            var disjointSets = new SystemOfDisjointSets();
            foreach (Edge edge in _graph)
            {
                disjointSets.AddEdgeInSet(edge);
            }

            return disjointSets.Sets.First().SetGraph;
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (Edge edge in _graph)
            {
                result += $"{edge.VertexA} {edge.VertexB} {edge.EdgeWeight}\n";
            }

            return result;
        }

        public void Sort()
        {
            _graph.Sort();
        }

        public IEnumerator<Edge> GetEnumerator()
        {
            return _graph.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _graph.GetEnumerator();
        }
    }
}

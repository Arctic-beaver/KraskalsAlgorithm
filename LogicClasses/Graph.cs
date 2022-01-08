using System.Collections;
using System.Collections.Generic;

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

        public Graph(Edge[] val)
        {
            _graph = new List<Edge>(val);
        }

        public int GetLength() => _graph.Count;
        public bool Contains(Edge edge) => _graph.Contains(edge);

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

        public void ToSets(KraskalsAlgorithm storage)
        {
            foreach (Edge edge in _graph)
            {
                Set setA = storage.Find(edge.VertexA);
                Set setB = storage.Find(edge.VertexB);

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
                    storage.Sets.Add(set);
                }
                else if (setA != null && setB != null)
                {
                    if (setA != setB)
                    {
                        setA.Union(setB, edge);
                        storage.Sets.Remove(setB);
                    }
                }
            }
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
            Edge[] graph = _graph.ToArray();
            MergeSort.Sort(graph);
            _graph = new List<Edge>(graph);
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

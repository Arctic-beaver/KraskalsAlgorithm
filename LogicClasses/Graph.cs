using LinkedListClass;
using System;

namespace GraphLogic
{
    public class Graph
    {
        private LinkedList<Edge> _graph;

        public Graph()
        {
            _graph = new LinkedList<Edge>();
        }

        public Graph(Edge val)
        {
            _graph = new LinkedList<Edge>(val);
        }

        public Graph(Edge[] val)
        {
            _graph = new LinkedList<Edge>(val);
        }

        public int GetLength() => _graph.GetLength();
        public bool Contains(Edge edge) => _graph.Contains(edge);

        public void Add(Graph graph)
        {
            _graph.AddLast(graph._graph);
        }

        public void Add(Edge edge)
        {
            _graph.AddLast(edge);
        }

        public int GetWeight()
        {
            Node<Edge> shovel = _graph.GetFirstNode();
            if (shovel == null) return 0;
            int weight = 0;

            while (shovel != null)
            {
                weight += shovel.Data.EdgeWeight;
                shovel = shovel.Next;
            }
            return weight;
        }

        public void ToSets(KraskalsAlgorithm storage)
        {
            Node<Edge> shovel = _graph.GetFirstNode();
            if (shovel == null) return;

            while (shovel != null)
            {
                Set setA = storage.Contains(shovel.Data.VertexA);
                Set setB = storage.Contains(shovel.Data.VertexB);

                if (setA != null && setB == null)
                {
                    setA.AddEdge(shovel.Data);
                }
                else if (setA == null && setB != null)
                {
                    setB.AddEdge(shovel.Data);
                }
                else if (setA == null && setB == null)
                {
                    Set set = new Set(shovel.Data);
                    storage.Sets.Add(set);
                }
                else if (setA != null && setB != null)
                {
                    if (setA != setB)
                    {
                        setA.Union(setB, shovel.Data);
                        storage.Sets.RemoveFirst(setB);
                    }
                }
                shovel = shovel.Next;
            }
        }

        public override string ToString()
        {
            Edge[] graph = _graph.ToArray();
            string result = string.Empty;

            for (int i = 0; i < graph.Length; i++)
            {
                result += $"{graph[i].VertexA} {graph[i].VertexB} {graph[i].EdgeWeight}\n";
            }

            return result;
        }

        public void RemoveAt(int idx)
        {
            try
            {
                _graph.RemoveAt(idx);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Sort()
        {
            Edge[] graph = _graph.ToArray();
            MergeSort.Sort(graph);
            _graph = new LinkedList<Edge>(graph);
        }
    }
}

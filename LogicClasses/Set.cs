using ArrayListClass;

namespace GraphLogic
{
    public class Set
    {
        public Graph SetGraph;
        public ArrayList<string> Vertices;

        public Set(Edge edge)
        {
            SetGraph = new Graph(edge);

            Vertices = new ArrayList<string>();
            Vertices.Add(edge.VertexA);
            Vertices.Add(edge.VertexB);
        }

        public void Union(Set set, Edge connectingEdge)
        {
            SetGraph.Add(set.SetGraph);
            Vertices.Add(set.Vertices);
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
            for (int i = 0; i < Vertices.GetLength(); i++)
            {
                if (Vertices.Get(i) == vertex) return true;
            }
            return false;
        }
    }
}

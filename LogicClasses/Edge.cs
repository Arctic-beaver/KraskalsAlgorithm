
namespace GraphLogic
{
    public class Edge
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

        public Edge(int weight)
        {
            EdgeWeight = weight;
        }
    }
}

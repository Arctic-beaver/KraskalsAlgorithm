
using ArrayListClass;

namespace GraphLogic
{
    public class KraskalsAlgorithm
    {
        public ArrayList<Set> Sets;

        public Graph FindMinimumBackbone(Graph graph)
        {
            Sets = new ArrayList<Set>();

            graph.Sort();

            graph.ToSets(this);

            graph = Sets.Get(0).SetGraph;

            return graph;
        }

        public Set Contains(string vertex)
        {
            for (int i = 0; i < Sets.GetLength(); i++)
            {
                if (Sets.Get(i).Contains(vertex)) return Sets.Get(i);
            }
            return null;
        }
    }
}

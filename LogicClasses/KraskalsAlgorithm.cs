using System.Linq;
using System.Collections.Generic;

namespace LogicClasses
{
    public class KraskalsAlgorithm
    {
        public List<Set> Sets;

        public Graph FindMinimumBackbone(Graph graph)
        {
            Sets = new List<Set>();

            graph.Sort();

            graph.ToSets(this);

            graph = Sets.First().SetGraph;

            return graph;
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

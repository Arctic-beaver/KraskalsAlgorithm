using LogicClasses;
using System;

namespace MinimumBackboneConsole
{
    public class ConsoleUI
    {
        private string[] filenames = new string[] { @"..\..\..\..\TestFiles\test.txt", @"..\..\..\..\TestFiles\test1.txt", @"..\..\..\..\TestFiles\test2.txt" };

        public void GraphFromFile()
        {
            foreach (string filename in filenames)
            {
                string[] lines = System.IO.File.ReadAllLines(filename);

                Graph graph = new Graph();
                foreach (string line in lines)
                {
                    string[] splitted = line.Split();
                    Edge edge = new Edge(splitted[0], splitted[1], Int32.Parse(splitted[2]));
                    graph.Add(edge);
                }
                Console.WriteLine("Your graph: ");
                Console.WriteLine(graph.ToString());
                Result(graph);
            }
        }

        public void GraphFromConsole()
        {
            Console.WriteLine("Enter amount of edges: ");
            int amount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Good. Now enter edges: each one from new line, format: Vertex1 Vertex2 EdgeWeight");
            Console.WriteLine();
            Graph graph = new Graph();

            for (int i = 0; i < amount; i++)
            {
                string line = Console.ReadLine();
                string[] splitted = line.Split();
                Edge edge = new Edge(splitted[0], splitted[1], Int32.Parse(splitted[2]));
                graph.Add(edge);
            }
            Result(graph);
        }

        public void Result(Graph graph)
        {
            graph = graph.FindMinimumSpanningTree();
            Console.WriteLine();
            Console.WriteLine("Minimum backbone: ");
            Console.Write(graph.ToString());
            Console.WriteLine(graph.GetWeight());
            Console.WriteLine();
        }
    }
}

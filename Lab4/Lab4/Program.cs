using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter graph nodes count:");
            int size = Convert.ToInt32(Console.ReadLine());

            Graph graph = new Graph(size);
            graph.AddEdge(0, 2, 5);
            graph.AddEdge(0, 4, 3);
            graph.AddEdge(1, 0, 9);
            graph.AddEdge(2, 1, 15);
            graph.AddEdge(3, 2, 92);
            graph.AddEdge(3, 1, 4);
            graph.AddEdge(4, 3, 8);
            graph.Print();
        }
    }
}
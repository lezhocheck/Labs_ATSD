using System;
using System.Collections.Generic;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter graph nodes count:");
            int size = Convert.ToInt32(Console.ReadLine());

            Graph graph = new Graph(size);

            Console.WriteLine("Enter graph edges. If edge is absent enter '0'.");
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if(i == j) continue;
                    
                    Console.Write($"Enter [{i}, {j}] edge weight: ");
                    int val = Convert.ToInt32(Console.ReadLine());
                    if(val != 0)
                        graph.AddEdge(i, j, val);
                }
            }
            graph.Print();
            graph.Kruskal();
            graph.Dijkstra(0);
            graph.Prim();
        }
    }
}
using System;
using System.Collections.Generic;

namespace Lab4
{
    public class Edge
    {
        public int Vertex { get; }
        public int AdjacentVertex { get; }
        public int Weight { get; }

        public Edge(int vertex, int adjacentVertex, int weight)
        {
            Vertex = vertex;
            AdjacentVertex = adjacentVertex;
            Weight = weight;
        }
    }
    
    public class Graph
    {
        private int _size;
        private List<Edge> _edges;

        public Graph(int size)
        {
            _size = size;
            _edges = new List<Edge>();
        }

        public void AddEdge(int v1, int v2, int weight)
        {
            _edges.Add(new Edge(v1, v2, weight));
        }

        public void Print()
        {
            Console.WriteLine("Graph:");

            foreach (var edge in _edges)
                Console.WriteLine($"Edge [{edge.Vertex}, {edge.AdjacentVertex} with weight: {edge.Weight}]");
        }

        public void Kruskal()
        {
            List<Edge> edges = KruskalList();
            int totalWeight = 0;
            Console.WriteLine("Kruskal:");
            foreach (var edge in edges)
            {
                Console.WriteLine($"Edge [{edge.Vertex}, {edge.AdjacentVertex}] with weight: {edge.Weight}");
                totalWeight += edge.Weight;
            }
            Console.WriteLine($"MST weight: {totalWeight}");
        }
        private List<Edge> KruskalList()
        {
            _edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));
            
            int[] parent = new int[_size];
            
            for (int i = 0; i < _size; i++)
                parent[i] = i;
            
            List<Edge> tree = new List<Edge>();
            foreach (var edge in _edges)
            {
                int startNodeRoot = FindRoot(parent, edge.Vertex);
                int endNodeRoot = FindRoot(parent, edge.AdjacentVertex);
 
                if (startNodeRoot != endNodeRoot)
                {
                    tree.Add(edge);
                    parent[endNodeRoot] = startNodeRoot;
                }
            }
            
            return tree;
        }
 
        private int FindRoot(int[] parent, int node)
        {
            var root = node;
            while (root != parent[root])
            {
                root = parent[root];
            }
 
            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }
 
            return root;
        }

        private int MinDistance(int[] distance, bool[] visited)
        {
            int min = Int32.MaxValue;
            int minIndex = 0;

            for (int i = 0; i < _size; i++)
            {
                if (visited[i] == false && distance[i] <= min)
                {
                    min = distance[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        private int[,] To2dArray()
        {
            int[,] arr = new int[_size, _size];

            foreach (var e in _edges)
            {
                arr[e.Vertex, e.AdjacentVertex] = e.Weight;   
                arr[e.AdjacentVertex, e.Vertex] = e.Weight;
            }

            return arr;
        }
        public void Dijkstra(int start)
        {
            int[] distance = new int[_size];
            bool[] visited = new bool[_size];
            int[,] matrix = To2dArray();

            for (int i = 0; i < _size; i++)
            {
                distance[i] = Int32.MaxValue;
                visited[i] = false;
            }

            distance[start] = 0;

            for (int i = 0; i < _size - 1; i++)
            {
                int minInd = MinDistance(distance, visited);
                visited[minInd] = true;

                
                for (int j = 0; j < _size; j++)
                {
                    if (!visited[j] && matrix[minInd, j] != 0 && distance[minInd] != Int32.MaxValue &&
                        distance[minInd] + matrix[minInd, j] < distance[j])
                    {
                        distance[j] = distance[minInd] + matrix[minInd, j];
                    }   
                }
            }

            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine($"Smallest path from {start} to {i} is: {distance[i]}");
            }
        }
        
        public void Prim()
        {
            int[] parent = new int[_size];
            int[] key = new int[_size];
            bool[] visited = new bool[_size];
            int[,] matrix = To2dArray();

            for (int i = 0; i < _size; i++)
            {
                key[i] = Int32.MaxValue;
                visited[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int i = 0; i < _size - 1; i++)
            {
                int minInd = MinDistance(key, visited);
                visited[minInd] = true;

                for (int j = 0; j < _size; j++)
                {
                    if (matrix[minInd, j] != 0 && visited[j] == false && matrix[minInd, j] < key[j])
                    {
                        parent[j] = minInd;
                        key[j] = matrix[minInd, j];
                    }
                }
            }
            
            for (int i = 1; i < _size; i++)
            {
                Console.WriteLine($"Edge [{parent[i]}, {i}] with weight: {matrix[i, parent[i]]}");
            }
        }
    }
}
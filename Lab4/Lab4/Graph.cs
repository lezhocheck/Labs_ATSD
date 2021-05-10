using System;
using System.Collections.Generic;
using System.Linq;

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

        private int[] _parent;

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

        
        private int Find(int i)
        {
            while (_parent[i] != i)
                i = _parent[i];
            return i;
        }
        
        private void Union(int i, int j)
        {
            int a = Find(i);
            int b = Find(j);
            _parent[a] = b;
        }
        
        public List<Edge> Kruskal()
        {
            _edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));
            
            _parent = new int[_size];
            
            for (int i = 0; i < _size; i++)
                _parent[i] = i;
            
            List<Edge> tree = new List<Edge>();
            foreach (var edge in _edges)
            {
                int startNodeRoot = FindRoot(edge.Vertex);
                int endNodeRoot = FindRoot(edge.AdjacentVertex);
 
                if (startNodeRoot != endNodeRoot)
                {
                    tree.Add(edge);
                    _parent[endNodeRoot] = startNodeRoot;
                }
            }
            
            return tree;
        }
 
        private int FindRoot(int node)
        {
            var root = node;
            while (root != _parent[root])
            {
                root = _parent[root];
            }
 
            while (node != root)
            {
                var oldParent = _parent[node];
                _parent[node] = root;
                node = oldParent;
            }
 
            return root;
        }
    }
}
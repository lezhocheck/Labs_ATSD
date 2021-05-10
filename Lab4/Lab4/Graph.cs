using System;

namespace Lab4
{
    public class Graph
    {
        private int _size;
        private int[,] _matrix;

        public Graph(int size)
        {
            _size = size;
            _matrix = new int[size, size];
        }

        public void AddEdge(int v1, int v2, int value)
        {
            if (v1 < 0 || v1 > _size - 1 || v2 < 0 || v2 > _size - 1)
                throw new ArgumentOutOfRangeException();

            if (value == 0)
                throw new ArgumentNullException();
            
            _matrix[v1, v2] = value;
        }
        
        

        public void Print()
        {
            Console.WriteLine("Graph:");
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_matrix[i, j] != 0)
                    {
                        Console.WriteLine($"Edge '{i} {j}': {_matrix[i, j]}");
                    }
                }
            }
        }
    }
}
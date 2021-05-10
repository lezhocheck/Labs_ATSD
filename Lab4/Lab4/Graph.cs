using System;

namespace Lab4
{
    public class Graph
    {
        private int _nodesCouns; 
        private int[,] _matrix;

        public Graph(int[,] matrix)
        {
            int height = matrix.GetLength(0);
            int width = matrix.GetLength(0);

            if (height != width)
                throw new ArgumentException("Width height mismatch");

            _nodesCouns = width;
            _matrix = matrix;
        }
    }
}
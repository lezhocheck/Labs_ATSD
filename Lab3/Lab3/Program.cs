using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue pq = new PriorityQueue();

            pq.EndQueue(5, 1);
            pq.EndQueue(0, 3);
            pq.EndQueue(7, 0);
            pq.EndQueue(4, 2);
            pq.EndQueue(9, 8);
            pq.EndQueue(6, 9);
            pq.Print();
            pq.DequeueMax();
            pq.DequeueMax();
            pq.DequeueMax();
            pq.Print();
        }
    }
}
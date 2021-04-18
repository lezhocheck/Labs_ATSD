using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayList arrayList = new ArrayList();
            arrayList.AddItem(6);
            arrayList.AddItem(3);
            arrayList.AddItem(-8);
            arrayList.AddItem(0);
            arrayList.AddItem(3);
            arrayList.AddItem(5);
            arrayList.Print();
            arrayList.Delete(3);
            arrayList.HeapSort(ArrayList.Order.Descending);
            arrayList.Print();
            arrayList.DeleteAt(2);
            arrayList.HeapSort(ArrayList.Order.Ascending);
            arrayList.Print();
            
            
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
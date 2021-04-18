using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.AddItem(5);
            list.AddItem(4);
            list.AddItem(7);
            list.AddItem(1);
            list.AddItem(0);
            list.AddItem(6);
            list.Print();
            list.Delete(7);
            list.HeapSort();
            list.Print();
        }
    }
}
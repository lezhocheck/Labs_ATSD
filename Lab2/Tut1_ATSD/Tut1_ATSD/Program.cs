using System;

namespace Tut1_ATSD
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>(15);
            list.AddItem(4);
            list.AddItem(2);
            list.AddItem(7);
            list.AddItem(7);
            list.AddItem(4);
            list.AddItem(1);
            list.AddItem(1);
            LinkedList<int> list1 = new LinkedList<int>(15);
            list1.AddItem(7);
            list1.AddItem(8);
            list1.AddItem(0);
            list1.AddItem(5);
            list1.AddItem(4);
            list1.AddItem(1);
            list1.AddItem(1);
            list.Union(list1);
            list.Print();
        }
    }
}
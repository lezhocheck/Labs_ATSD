using System;

namespace  La
{
    
}
class LinkedListDemo
{
    static void Main(string[] args)
    {
        LinkedList<int> list1 = new LinkedList<int>(1, 0, -5, 1, 0, -5, 1, 0, -5);
        LinkedList<string> list2 = new LinkedList<string>();
        list1.AddItem(2);
        list1.AddItem(1);
        list1.AddItem(0);
        list1.AddItem(5);
        list1.AddItem(-5);
        list1.AddItem(0);
        list1.AddItem(5);
        list1.AddItem(-5);
        list1.Print();
        list1.DeleteItem(2);
        list1.Print();
        list1.DeleteItem(-5);
        list1.Print();
        list1.DeleteItem(100);
        list1.Print();
        Console.WriteLine(list1.Size);
        Console.WriteLine(list1.SearchItem(0)); // usual
        Console.WriteLine(list1.SearchItem(list1.Head, 1)); // recursive 
        Console.WriteLine(list1.GetItemByIndex(2));
        list1.MakeEmpty();
        list1.Print();

        list2.AddItem("c#");
        list2.AddItem("c++");
        list2.Print();
        list2.DeleteItem("c#");
        list2.AddItem("c++");
        list2.Print();
        Console.WriteLine(list2.Size);
        list2.AddItem("python");
        list2.Print();
        Console.WriteLine(list2.SearchItem("python"));
    }
}
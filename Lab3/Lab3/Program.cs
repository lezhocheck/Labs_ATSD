using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.AddItem(5);
            list.AddItem(3);
            list.AddItem(6);
            list.AddItem(5);
            list.AddItem(3);
            list.AddItem(6);
            list.Print();
        }
    }
}
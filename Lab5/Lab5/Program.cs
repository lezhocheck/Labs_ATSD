using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            UnsortedArrayList list = new UnsortedArrayList();

            for (int i = 0; i < 15; i++)
            {
                list.Add(i);
            }
            list.Add(5);
            
            list.Delete(5);
            list.Print(); 
        }
    }
}
using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            UnsortedArrayList list = new UnsortedArrayList();

            for (int i = 0; i < 25; i++)
            {
                list.Add(i);
            }
            
            list.Print(); 
            list.Delete(9);
            list.Separate();
            list.Print(); 
        }
    }
}
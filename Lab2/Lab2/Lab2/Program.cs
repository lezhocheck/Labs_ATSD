using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedBinarySearchTree bbst = new BalancedBinarySearchTree();
            
            bbst.AddItem(3);
            bbst.AddItem(2);
            bbst.AddItem(7);
            bbst.AddItem(2);
            bbst.AddItem(8);
            bbst.AddItem(10);
            bbst.AddItem(-1);
            
            bbst.PrintPreorder();
            
            bbst.PrintSorted();
            
            Console.WriteLine(bbst.CountNode());
            Console.WriteLine(bbst.SumKeys());
        }
    }
}
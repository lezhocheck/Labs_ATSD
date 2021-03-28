using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedBinarySearchTree bbst = new BalancedBinarySearchTree();
            
            bbst.AddItem(2);
            bbst.AddItem(2);
            bbst.AddItem(1);
            bbst.AddItem(8);

            BalancedBinarySearchTree bbst1 = bbst.Symmetric();
            bbst.PrintPreorder();
            bbst1.PrintPreorder();
        }
    }
}
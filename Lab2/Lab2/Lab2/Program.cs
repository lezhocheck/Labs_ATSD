using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedBinarySearchTree bbst = new BalancedBinarySearchTree();
            bbst.AddItem(5);
            bbst.AddItem(4);
            bbst.AddItem(6);
            bbst.AddItem(3);
            bbst.AddItem(8);
            bbst.AddItem(2);
        }
    }
}
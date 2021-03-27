using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedBinarySearchTree bbst = new BalancedBinarySearchTree();
            BinarySearchTree bst = new BinarySearchTree();
            bst.AddItem(1);
            bst.AddItem(2);
            bst.AddItem(3);
            bst.AddItem(4);
            bst.AddItem(5);
            bst.AddItem(6);
            bst.AddItem(7);

            bbst.AddItem(1);
            bbst.AddItem(2);
            bbst.AddItem(3);
            bbst.AddItem(4);
            bbst.AddItem(5);
            bbst.AddItem(6);
            bbst.AddItem(7);

            bst.PrintPreorder();
            bbst.PrintPreorder();
        }
    }
}
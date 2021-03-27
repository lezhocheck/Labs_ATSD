using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedBinarySearchTree bbst = new BalancedBinarySearchTree();
            BinarySearchTree bst = new BinarySearchTree();
            bst.AddItem(5);
            bst.AddItem(4);
            bst.AddItem(6);
            bst.AddItem(7);
            bst.AddItem(8);
            bst.AddItem(9);
            
            bbst.AddItem(5);
            bbst.AddItem(4);
            bbst.AddItem(6);
            bbst.AddItem(7);
            bbst.AddItem(8);
            bbst.AddItem(9);
            bst.PrintPostorder();
            bbst.PrintPostorder();
        }
    }
}
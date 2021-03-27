using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.AddItem(15);
            bst.AddItem(10);
            bst.AddItem(7);
            bst.AddItem(50);
            bst.AddItem(12);
            bst.AddItem(11);
            bst.AddItem(45);
            bst.AddItem(13);
            bst.AddItem(55);
            bst.AddItem(14);
            bst.DeleteItem(10);
            Console.WriteLine(bst.GetSize());
            bst.PrintPreorder();
            bst.PrintInorder();
            bst.PrintPostorder();
        }
    }
}
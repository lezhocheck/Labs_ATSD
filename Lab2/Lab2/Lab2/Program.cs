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
            bbst.AddItem(2);
            bbst.AddItem(3);
            bbst.AddItem(1);
            bbst.AddItem(8);
            bbst.AddItem(6);
            bbst.AddItem(7);
            bbst.AddItem(8);
            bbst.AddItem(4);
            bbst.AddItem(8);
            bbst.AddItem(5);
            bbst.PrintPreorder();
            
            bbst.DeleteItem(1);
            bbst.PrintPreorder();

            bbst.DeleteDuplicate();
            Console.WriteLine(bbst.GetCommonAncestor(5, 6));
            bbst.PrintPreorder();
            
            bbst.DeleteEven();
            bbst.PrintPreorder();
            
            Console.WriteLine(bbst.CountNode());
            Console.WriteLine(bbst.FindMiddle());
            Console.WriteLine(bbst.SumKeys());
            Console.WriteLine(bbst.IsBalanced());
            bbst.PrintPreorder();
        }
    }
}
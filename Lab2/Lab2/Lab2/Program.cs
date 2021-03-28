﻿using System;

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
            bbst.AddItem(8);
            bbst.AddItem(10);
            bbst.AddItem(18);
            bbst.AddItem(-1);
            BalancedBinarySearchTree bbst1 = bbst.Copy();
            bbst.PrintPreorder();
            bbst1.PrintPreorder();
           
            
            Console.WriteLine(bbst.CountNode());
            Console.WriteLine(bbst.SumKeys());
        }
    }
}
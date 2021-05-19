using System;
using System.Collections.Generic;

namespace Tut2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bst bst = new Bst();
            
            bst.Insert(4);
            bst.Insert(5);
            bst.Insert(6);
            bst.Insert(5);
            bst.DeleteItem(5);
            
            Bst bst1 = new Bst();
            
            bst1.Insert(6);
            bst1.Insert(5);
            bst1.Insert(3);

            Console.Write($"{bst.SameData(bst1)}\n");
            
            bst.PrintDescending();
            Console.Write(bst.Sum());

            Tutor t = new Tutor();
            
            Console.WriteLine(t.Task1Rec(3));
            
            Console.WriteLine(t.Prod(6, -5));


            LinkedList list = new LinkedList();
            list.AddItem(3);
            list.AddItem(5);
            list.AddItem(-3);
            list.AddItem(1);
            list.AddItem(0);
            list.AddItem(4);
            list.AddItem(2);
            Console.WriteLine(list.Sum());
            list.Print();
            list.PrindRev();
        }
    }

    class Tutor
    {
        public int Task1Rec(int n)
        {
            if(n <= 0) return 3;
            
            return 4 * Task1Rec(n - 1) + 2 * Task1Rec(n / 2) + 7;
        }

        public int Prod(int a, int b)
        {
            if (a < 0 && b < 0)
            {
                a = -a;
                b = -b;
            }

            int min = Math.Min(a, b);
            int max = Math.Max(a, b);

            if (max == 0)
                return 0;

            return min + Prod(min, max - 1);
        }
    }
}
//15: T(n log n)

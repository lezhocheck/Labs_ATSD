using System;
using System.Collections.Generic;

namespace Lab2
{
    public class BalancedBinarySearchTree : BinarySearchTree
    {
        public override void AddItem(int item)
        {
            Root = AddItemRec(item, Root);
            if(!IsBalancedRec(Root))
                Rebalance();
        }

        public override void DeleteItem(int item)
        {
            if (Search(item))
            {
                Root = DeleteItemRec(item, Root);
                
                if(!IsBalancedRec(Root))
                    Rebalance();
                
                return;
            }
            
            Console.WriteLine("Item was not deleted.");
        }

        public void PrintSorted()
        {
            if (Root != null)
            {
                List<Node> list = new List<Node>();
                ToListRec(list, Root);

                foreach (var node in list)
                {
                    Console.Write($"{node.Data} ");
                }
                Console.WriteLine();
            
                list.Reverse();
            
                foreach (var node in list)
                {
                    Console.Write($"{node.Data} ");
                }
                Console.WriteLine();   
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
        }

        public int CountNode()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty.");
                return Int32.MinValue;
            }

            return CountNodeRec(Root);
        }

        public int SumKeys()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty.");
                return Int32.MinValue;
            }
            
            return SumKeysRec(Root);
        }

        public void DeleteEven()
        {
            DeleteEvenRec(Root);   
        }

        private void DeleteEvenRec(Node r)
        {
            if(r == null) return;

            if (r.Data % 2 == 0)
            {
                DeleteItem(r.Data);
                r = Root;
                DeleteEvenRec(r);
            }
            else
            {
                DeleteEvenRec(r.LNode);
                DeleteEvenRec(r.RNode);   
            }
        }
        private int CountNodeRec(Node r)
        {
            if (r.LNode == null)
                return 0;

            return CountNodeRec(r.LNode) + 1;
        }

        private int SumKeysRec(Node r)
        {
            if (r.RNode == null)
                return 0;
            return SumKeysRec(r.RNode) + r.RNode.Data;
        }

        private void Rebalance()
        {
            List<Node> list = new List<Node>();
            ToListRec(list, Root);
            Root = ConvertToBbst(list, 0, list.Count - 1);
        }

        private void ToListRec(List<Node> list, Node r)
        {
            if(r == null)
                return;
            
            ToListRec(list, r.LNode);
            list.Add(r);
            ToListRec(list, r.RNode);
        }

        private Node ConvertToBbst(List<Node> list, int first, int last)
        {
            if (first > last)
                return null;

            int mid = (first + last) / 2;

            Node t = list[mid];
            t.LNode = ConvertToBbst(list, first, mid - 1);
            t.RNode = ConvertToBbst(list, mid + 1, last);

            return t;
        }
        

    }
}
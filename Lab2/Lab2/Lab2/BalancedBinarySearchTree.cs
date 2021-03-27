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
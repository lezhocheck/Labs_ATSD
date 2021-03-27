using System;

namespace Lab2
{
    public class BalancedBinarySearchTree : BinarySearchTree
    {
        public override void AddItem(int item)
        {
            Root = AddItemRec(item, Root);
        }

        private bool IsBalanced()
        {
            return IsBalancedRec(Root);
        }
        private bool IsBalancedRec(Node r)
        {
            if (r == null)
                return true;
            
            if (Math.Abs(GetHeight(r.LNode) - GetHeight(r.RNode)) <= 1
                && IsBalancedRec(r.LNode) && IsBalancedRec(r.RNode))
                return true;
            
            return false;
        }

        private int GetHeight(Node r)
        {
            if (r == null)
                return 0;

            return Math.Max(GetHeight(r.LNode), GetHeight(r.RNode)) + 1;
        }

    }
}
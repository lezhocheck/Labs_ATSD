using System;

namespace Lab2
{
    internal class Node
    {
        public Node RNode { get; }
        public Node LNode { get; }
        public int Data;

        public Node()
        {
            this.Data = Int32.MinValue;
            this.RNode = null;
            this.LNode = null;
        }
    }
    
    public class BinarySearchTree
    {
        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        public void AddItem(int item)
        {
            root = AddItemRec(item, root);
        }

        public bool Search(int item)
        {
            return SearchRec(item, root);
        }

        private bool SearchRec(int item, Node r)
        {
            if (r == null)
                return false; 
            
            if (r.Data == item)
                return true;

            if (item < r.Data)
                return SearchRec(item, r.LNode);
            else
                return SearchRec(item, r.RNode);
        }

        public int DeleteItem(int item)
        {
            if (Search(item))
            {
                root = DeleteItemRec(item, root);
                return root.Data;
            }

            Console.WriteLine("Item was not deleted.");
            return Int32.MinValue;
        }

        public bool IsEmpty()
        {
            if (root == null)
                return true;
            return false;
        }

        public int GetSize()
        {
            return GetSizeRec(root);
        }

        private int GetSizeRec(Node r)
        {
            if (r == null)
                return 0;
            
            return GetSizeRec(r.LNode) + GetSizeRec(r.RNode) + 1;
        }
        
        private Node DeleteItemRec(int item, Node r)
        {
            if (r.Data == item)
                return r;
            
            if (r.Data < item)
                return DeleteItemRec(item, r.LNode);
            else
                return DeleteItemRec(item, r.RNode);
        }
        
        private Node AddItemRec(int item, Node r)
        {
            if (r == null)
            {
                r = new Node { Data = item };
                return r;
            }

            if (item < r.Data)
                return AddItemRec(item, r.LNode);
            else
                return AddItemRec(item, r.RNode);
        }
    }
}
using System;

namespace Lab2
{
    public class Node
    {
        public Node RNode { get; set; }
        public Node LNode { get; set; }
        public int Data;

        public Node()
        {
            this.Data = 0;
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
        
        private Node AddItemRec(int item, Node r)
        {
            if (r == null)
            {
                r = new Node { Data = item };
                return r;
            }

            if (item < r.Data)
            {
                return AddItemRec(item, r.LNode);
            }
            else
            {
                return AddItemRec(item, r.RNode);
            }
        }
    }
}
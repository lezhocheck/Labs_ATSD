using System;

namespace Lab2
{
    internal class Node
    {
        public Node RNode { get; set; }
        public Node LNode { get; set; }
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

        public void PrintPreorder()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty.");   
            }
            else
            {
                PreorderRec(root);
                Console.WriteLine();
            }
        }
        
        public void PrintInorder()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty.");   
            }
            else
            {
                InorderRec(root);
                Console.WriteLine();
            }
        }

        private void PreorderRec(Node r)
        {
            if (r != null)
            {
                Console.Write($"{r.Data} ");
                PreorderRec(r.LNode);
                PreorderRec(r.RNode);   
            }
        }
        
        private void InorderRec(Node r)
        {
            if (r != null)
            {
                InorderRec(r.LNode);
                Console.Write($"{r.Data} ");
                InorderRec(r.RNode);   
            }
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
                r.LNode = AddItemRec(item, r.LNode);
            else
                r.RNode = AddItemRec(item, r.RNode);
            return r;
        }
    }
}
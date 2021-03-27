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
            this.Data = Int32.MinValue;
            this.RNode = null;
            this.LNode = null;
        }
    }
    
    public class BinarySearchTree
    {
        protected Node Root;

        public BinarySearchTree()
        {
            Root = null;
        }

        public void AddItem(int item)
        {
            Root = AddItemRec(item, Root);
        }

        public bool Search(int item)
        {
            return SearchRec(item, Root);
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
                Root = DeleteItemRec(item, Root);
                return Root.Data;
            }

            Console.WriteLine("Item was not deleted.");
            return Int32.MinValue;
        }

        public bool IsEmpty()
        {
            if (Root == null)
                return true;
            return false;
        }

        public void MakeEmpty()
        {
            Root = null;
        }
        
        public int GetSize()
        {
            return GetSizeRec(Root);
        }

        public void PrintPreorder()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty.");   
            }
            else
            {
                PreorderRec(Root);
                Console.WriteLine();
            }
        }
        
        public void PrintInorder()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty.");   
            }
            else
            {
                InorderRec(Root);
                Console.WriteLine();
            }
        }
        
        public void PrintPostorder()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty.");   
            }
            else
            {
                PostorderRec(Root);
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
        
        private void PostorderRec(Node r)
        {
            if (r != null)
            {
                PostorderRec(r.LNode);
                PostorderRec(r.RNode);   
                Console.Write($"{r.Data} ");
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
            if (item < r.Data)
                r.LNode = DeleteItemRec(item, r.LNode);
            else if (item > r.Data)
                r.RNode = DeleteItemRec(item, r.RNode);
            else
                r = DeleteFound(r);
            return r;  
        }

        private Node DeleteFound(Node t)
        {
            if (t.LNode == null)
                return t.RNode;
            else if (t.RNode == null)
                return t.LNode;
            else
            {
                Node temp = t.RNode;
                while (temp.LNode != null)
                {
                    temp = temp.LNode;
                }

                t.Data = temp.Data;
                t.RNode = DeleteItemRec(t.Data, t.RNode);
                return t;
            }
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
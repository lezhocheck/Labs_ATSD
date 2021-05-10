using System;
using System.Collections.Generic;

namespace Tut2
{
    public class Node
    {
        public Node RNode { get; set; }
        public Node LNode { get; set; }
        public int Data;

        public Node()
        {
            Data = Int32.MinValue;
            RNode = null;
            LNode = null;
        }
    }
    
    public class Bst
    {
        private Node _root;

        public Bst()
        {
            _root = null;
        }


        public void MakeEmpty() => _root = null;

        public void Insert(int item) =>  _root = InsertRec(item, _root);

        public bool Search(int item) => SearchRec(item, _root);

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

        public void DeleteItem(int item)
        {
            if (Search(item))
            {
                _root = DeleteItemRec(item, _root);
                return;
            }

            throw new ArgumentException("Item was not deleted.");
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
        private Node InsertRec(int item, Node r)
        {
            if (r == null)
            {
                r = new Node { Data = item };
                return r;
            }

            if (item < r.Data)
                r.LNode = InsertRec(item, r.LNode);
            else
                r.RNode = InsertRec(item, r.RNode);
            return r;
        }


        public int Size() => SizeRec(_root);

        private int SizeRec(Node r)
        {
            if (r == null)
                return 0;
            
            return SizeRec(r.LNode) + SizeRec(r.RNode) + 1;
        }

        public int Sum() => SumRec(_root);

        private int SumRec(Node root)
        {
            if (root == null)
                return 0;

            return root.Data + SumRec(root.LNode) + SumRec(root.RNode);
        }

        public void PrintAscending()
        {
            List<int> list = new List<int>();
            ToListRec(list, _root);

            foreach (var i in list)
            {
                Console.Write($"{i} ");
            }
            
            Console.WriteLine();
        }
        
        public void PrintDescending()
        {
            List<int> list = new List<int>();
            ToListRec(list, _root);
            list.Reverse();

            foreach (var i in list)
            {
                Console.Write($"{i} ");
            }
            
            Console.WriteLine();
        }

        private void ToListRec(List<int> list, Node r)
        {
            if(r == null)
                return;
            
            ToListRec(list, r.LNode);
            list.Add(r.Data);
            ToListRec(list, r.RNode);
        }

        public bool IsEquals(Bst tree)
        {
            IsEqualsRec(this._root, tree._root, out bool res);
            return res;
        }

        private void IsEqualsRec(Node r1, Node r2, out bool val)
        {
            if (r1 == null && r2 == null)
            {
                val = true;
                return;
            }
            
            if (r1.Data != r2.Data)
            {
                val = false;
                return;   
            }

            IsEqualsRec(r1.LNode, r2.LNode, out val);
            IsEqualsRec(r1.RNode, r2.RNode, out val);
        }

        public bool IsBalanced() => IsBalancedRec(_root);

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
        
        public bool SameData(Bst bst)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            ToListRec(list1, _root);
            ToListRec(list2, bst._root);

            if (list1.Count != list2.Count)
                return false;

            foreach (int i in list1)
            {
                if (!list2.Contains(i))
                    return false;
            }

            return true;
        }
    }
}
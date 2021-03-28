using System;
using System.Collections.Generic;
using System.ComponentModel;

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

        public int FindMiddle()
        {
            List<Node> list = new List<Node>();
            ToListRec(list, Root);
            
            int mid = (list[0].Data + list[^1].Data) / 2;
            Node temp = list[0];
            int minDif = Math.Abs(temp.Data - mid);

            foreach (Node item in list)
            {
                int t = Math.Abs(item.Data - mid);
                if (t < minDif)
                {
                    minDif = t;
                    temp = item;
                }
            }

            return temp.Data;
        }

        public void DeleteDuplicate()
        {
            BalancedBinarySearchTree t = new BalancedBinarySearchTree();
            DeleteDuplicateRec(this.Root, t);
            this.Root = t.Root;
        }
        
        public int FindSecondLargest()
        {
            List<Node> list = new List<Node>();
            ToListRec(list, Root);
            return list[^2].Data;
        }

        public BalancedBinarySearchTree Copy()
        {
            BalancedBinarySearchTree t = new BalancedBinarySearchTree();
            CopyRec(Root, t);
            
            return t;
        }

        public void Insert(BalancedBinarySearchTree tree)
        {
            InsertRec(tree.Root);
        }

        public bool Contains(BalancedBinarySearchTree tree)
        {
            BalancedBinarySearchTree temp = this.Copy();
            List<Node> list = new List<Node>();
            ToListRec(list, tree.Root);
            
            foreach (Node item in list)
            {
                if (temp.Search(item.Data))
                {
                    temp.DeleteItem(item.Data);
                }
                else return false;
            }
            
            return true;
        }

        public bool IsEquals(BalancedBinarySearchTree tree)
        {
            IsEqualsRec(this.Root, tree.Root, out bool res);
            return res;
        }

        public BalancedBinarySearchTree Symmetric()
        {
            BalancedBinarySearchTree temp = new BalancedBinarySearchTree();
            SymmetricRec(this.Root, temp);
            
            return temp;
        }

        private void SymmetricRec(Node t, BalancedBinarySearchTree tree)
        {
            if(t == null) return;

            tree.Root = AddItemSymRec(t.Data, tree.Root);

            SymmetricRec(t.LNode, tree);
            SymmetricRec(t.RNode, tree);
        }
        
        private Node AddItemSymRec(int item, Node r)
        {
            if (r == null)
            {
                r = new Node { Data = item };
                return r;
            }

            if (item >= r.Data)
                r.LNode = AddItemSymRec(item, r.LNode);
            else
                r.RNode = AddItemSymRec(item, r.RNode);
            return r;
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
        
        private void InsertRec(Node r)
        {
            if(r == null) return;
            
            this.AddItem(r.Data);
            
            InsertRec(r.LNode);
            InsertRec(r.RNode);
        }
        
        private void CopyRec(Node r, BalancedBinarySearchTree t)
        {
            if(r == null) return;
            t.AddItem(r.Data);
            
            CopyRec(r.LNode, t);
            CopyRec(r.RNode, t);
        }
        
        private void DeleteDuplicateRec(Node r, BalancedBinarySearchTree t)
        {
            if(r == null) return;
            
            if (!t.Search(r.Data))
                t.AddItem(r.Data);
            
            DeleteDuplicateRec(r.LNode, t);
            DeleteDuplicateRec(r.RNode, t);
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
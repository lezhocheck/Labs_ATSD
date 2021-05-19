using System;

namespace Lab3
{
    class Node
    {
        public Node LeftSon;
        public Node RightSon;

        public int Data;
        public int Priority;

        public Node()
        {
            LeftSon = null;
            RightSon = null;
            Data = Int32.MinValue;
            Priority = -1;
        }
    } 
    
    public class PriorityQueue
    {
        private Node _root;

        public bool IsEmpty => _root == null;
        public int Size => SizeRec(_root);
        
        public PriorityQueue()
        {
            _root = null;
        }
        
        private int SizeRec(Node root)
        {
            if (root == null)
                return 0;

            return 1 + SizeRec(root.LeftSon) + SizeRec(root.RightSon);
        }
        
        public void EndQueue(int item, int priority) => 
            _root = EndQueueRec(_root, item, priority);

        private Node EndQueueRec(Node root, int item, int priority)
        {
            if (root == null)
            {
                Node t = new Node();
                t.Data = item;
                t.Priority = priority;
                return t;   
            }

            if(priority < root.Priority)
                root.LeftSon = EndQueueRec(root.LeftSon, item, priority);
            else
               root.RightSon = EndQueueRec(root.RightSon, item, priority);

            return root;
        }

        private void PrintRec(Node root)
        {
            if(root == null)
                return;
            
            PrintRec(root.LeftSon);
            Console.Write($"{root.Data} ");
            PrintRec(root.RightSon);
        }

        public void Print()
        {
            PrintRec(_root);
            Console.WriteLine();
        }
        
        public void DequeueMax() =>  _root = DeleteItemRec(_root);

        private Node DeleteItemRec(Node root)
        {
            if (root.RightSon == null)
            {
                root = DeleteFound(root);  
                return root;  
            }
            root.RightSon = DeleteItemRec(root.RightSon);
            return root;  
        }

        private Node DeleteFound(Node root)
        {
            if (root.LeftSon == null)
                return root.RightSon;
            else if (root.RightSon == null)
                return root.LeftSon;
            else
            {
                Node temp = root.RightSon;
                while (temp.LeftSon != null)
                {
                    temp = temp.LeftSon;
                }

                root.Data = temp.Data;
                root.RightSon = DeleteItemRec(root.RightSon);
                return root;
            }
        }
    }
}
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

        public void EndQueue(int item, int priority) => 
            _root = EndQueueRec(_root, item, priority);

        private int SizeRec(Node root)
        {
            if (root == null)
                return 0;

            return 1 + SizeRec(root.LeftSon) + SizeRec(root.RightSon);
        }
        
        private Node EndQueueRec(Node root, int item, int priority)
        {
            if (root == null)
            {
                Node t = new Node();
                t.Data = item;
                t.Priority = priority;
                return t;   
            }

            if(root.Priority < priority)
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

        public void Print() => PrintRec(_root);
        
    }
}
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

        public void EndQueue(int item, int priority)
        {
            if (_root == null)
            {
                _root = new Node();
                _root.Data = item;
                _root.Priority = priority;
            }
            else
            {
                EndQueueRec(_root, item, priority);
            }
        }

        private int SizeRec(Node root)
        {
            if (root == null)
                return 0;

            return 1 + SizeRec(root.LeftSon) + SizeRec(root.RightSon);
        }
        private void EndQueueRec(Node root, int item, int priority)
        {
            if (root == null)
            {
                root = new Node();
                root.Data = item;
                root.Priority = priority;
            }
            
            if(root.Priority < priority)
                EndQueueRec(root.LeftSon, item, priority);
            else
                EndQueueRec(root.RightSon, item, priority);
        }
    }
}
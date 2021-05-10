using System;

namespace Tut2
{
    class NodeList 
    {
        public int Data { get; }
        public NodeList NextNode { get; set; }

        public NodeList(int data)
        {
            Data = data;
            NextNode = null;
        } 
    }
    
    class LinkedList
    {
        private NodeList _head;
        public int Size { get; private set; }

        public LinkedList()
        {
            _head = null;
            Size = 0;
        }
     
        public void AddItem(int item)
        {
            NodeList temp = _head;
            NodeList node = new NodeList(item);
            if(_head == null || _head.Data > item)
            {
                _head = node;
                _head.NextNode = temp;
            }
            else
            {
                while(temp.NextNode != null && temp.NextNode.Data < item)
                {
                    temp = temp.NextNode;
                }
                node.NextNode = temp.NextNode;
                temp.NextNode = node;
            }
            Size++;
        }

        public bool SearchItem(int item)
        {
            bool result = false;
            NodeList temp = _head;
            while(temp != null)
            {
                if(temp.Data == item)
                {
                    result = true;
                    break;
                }
                temp = temp.NextNode;
            }
            return result;
        }
        
        public int DeleteItem(int item)
        {
            if (SearchItem(item))
            {
                NodeList temp = _head;
                NodeList next = _head.NextNode;
                if(temp.Data == item && next != null)
                {
                    _head = next;
                    Size--;
                    return item;
                }
                else if(temp.Data == item && next == null)
                {
                    _head = null;
                    Size = 0;
                    return item;
                }
                do
                {
                    if (next.Data == item)
                    {
                        temp.NextNode = next.NextNode;
                        break;
                    }
                    temp = temp.NextNode;
                    next = temp.NextNode;
                } while (next != null && temp.Data != item);
                Size--;
                return item;
            }
            
            throw new ArgumentOutOfRangeException("List does not contain element '" + item + "'.");
        }


        public int Sum() => SumRec(_head);
        private int SumRec(NodeList root)
        {
            if (root == null)
                return 0;

            return SumRec(root.NextNode) + root.Data;
        }

        public void Print() => PrintRec(_head);
        public void PrindRev() => PrintRevRec(_head);
        
        private void PrintRec(NodeList root)
        {
            if (root == null)
            {
                Console.WriteLine();
                return;
            }

            Console.Write($"{root.Data} ");
            
            PrintRec(root.NextNode);
        }
        
        private void PrintRevRec(NodeList root)
        {
            if (root == null)
            {
                Console.WriteLine();
                return;
            }

            PrintRevRec(root.NextNode);
            
            Console.Write($"{root.Data} ");
        }
        
   }
}


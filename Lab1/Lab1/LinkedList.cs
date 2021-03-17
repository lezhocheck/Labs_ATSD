using System;

class Node<T> 
{
    public T Data { get; }
    public Node<T> NextNode { get; set; }

    public Node(T data)
    {
        this.Data = data;
        NextNode = null;
    }
}
class LinkedList<T> where T : IComparable
{
    public Node<T> Head { get; private set; }
    public int Size { get; private set; }

    public LinkedList()
    {
        Head = null;
        Size = 0;
    }
    public LinkedList(params T[] input) 
    {
        Array.Sort(input);
        Size = input.Length;
        Node<T> temp = new Node<T>(input[0]);
        Head = temp;
        for (int i = 1; i < Size; i++)
        {
            Node<T> tt = temp;
            temp = new Node<T>(input[i]);
            tt.NextNode = temp;
        }
    }
    
    public void AddItem(T item)
    {
        Node<T> temp = Head;
        Node<T> node = new Node<T>(item);
        if(Head == null || Head.Data.CompareTo(item) > 0)
        {
            Head = node;
            Head.NextNode = temp;
        }
        else
        {
            while(temp.NextNode != null && temp.Data.CompareTo(item) < 0)
            {
                temp = temp.NextNode;
            }
            node.NextNode = temp.NextNode;
            temp.NextNode = node;
        }
        Size++;
    }
    public bool IsEmpty()
    {
        return Size == 0;
    }
    public void MakeEmpty()
    {
        Head = null;
        Size = 0;
    }
    public bool SearchItem(T item)
    {
        bool result = false;
        Node<T> temp = Head;
        while(temp != null)
        {
            if(temp.Data.CompareTo(item) == 0)
            {
                result = true;
                break;
            }
            temp = temp.NextNode;
        }
        return result;
    }
    public bool SearchItem(Node<T> node, int item)
    {
        if (node == null)
            return false;
        if (node.Data.CompareTo(item) == 0)
            return true;
        return SearchItem(node.NextNode, item);
    }
    public T GetItemByIndex(int index)
    {
        Node<T> temp = Head;
        int indexer = 0;
        if (index < 0 || index >= Size)
        {
            Console.WriteLine("Invalid index.");
            return default(T);
        }
        while(temp != null)
        {
            if(indexer == index)
            {
                return temp.Data;
            }
            indexer++;
            temp = temp.NextNode;
        }
        Console.WriteLine("Invalid index.");
        return default(T);
    }
    public T DeleteItem(T item)
    {
        if (SearchItem(item))
        {
            Node<T> temp = Head;
            Node<T> next = Head.NextNode;
            if(temp.Data.CompareTo(item) == 0 && next != null)
            {
                Head = next;
                Size--;
                return item;
            }
            else if(temp.Data.CompareTo(item) == 0 && next == null)
            {
                Head = null;
                Size = 0;
                return item;
            }
            do
            {
                if (next.Data.CompareTo(item) == 0)
                {
                    temp.NextNode = next.NextNode;
                    break;
                }
                temp = temp.NextNode;
                next = temp.NextNode;
            } while (next != null && temp.Data.CompareTo(item) != 0);
            Size--;
            return item;
        }
        Console.WriteLine("List does not contain element '" + item + "'.");
        return default;
    }
    public void Print()
    {
        Node<T> temp = Head;
        while(temp != null)
        {
            Console.Write(temp.Data + " ");
            temp = temp.NextNode;
        }
        Console.Write("\n");
    }
}

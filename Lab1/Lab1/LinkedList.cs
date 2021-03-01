using System;

class Node<T> 
{
    public T data;
    public Node<T> nextNode;

    public Node(T data)
    {
        this.data = data;
        nextNode = null;
    }
}
class LinkedList<T> where T : IComparable
{
    private Node<T> headList;
    private int count;

    public LinkedList()
    {
        headList = null;
        count = 0;
    }
    public void AddItem(T item)
    {
        Node<T> temp = headList;
        Node<T> node = new Node<T>(item);
        if(headList == null || headList.data.CompareTo(item) >= 0)
        {
            headList = node;
            headList.nextNode = temp;
        }
        else
        {
            while(temp.nextNode != null && headList.data.CompareTo(item) < 0)
            {
                temp = temp.nextNode;
            }
            node.nextNode = temp.nextNode;
            temp.nextNode = node;
        }
        count++;
    }
    public bool IsEmpty()
    {
        return count == 0 ? true : false;
    }
    public int Size()
    {
        return count;
    }
    public void MakeEmpty()
    {
        headList = null;
        count = 0;
    }
    public bool SearchItem(T item)
    {
        bool result = false;
        Node<T> temp = headList;
        while(temp != null)
        {
            if(temp.data.CompareTo(item) == 0)
            {
                result = true;
                break;
            }
            temp = temp.nextNode;
        }
        return result;
    }
    public Node<T> GetListHead()
    {
        return headList;
    }
    public bool SearchItem(Node<T> node, int item)
    {
        if (node == null)
            return false;
        if (node.data.CompareTo(item) == 0)
            return true;
        return SearchItem(node.nextNode, item);
    }
    public T GetItemByIndex(int index)
    {
        Node<T> temp = headList;
        int indexer = 0;
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Invalid index.");
            return default(T);
        }
        while(temp != null)
        {
            if(indexer == index)
            {
                return temp.data;
            }
            indexer++;
            temp = temp.nextNode;
        }
        Console.WriteLine("Invalid index.");
        return default(T);
    }
    public T DeleteItem(T item)
    {
        if (SearchItem(item))
        {
            Node<T> temp = headList;
            Node<T> next = headList.nextNode;
            if(temp.data.CompareTo(item) == 0 && next != null)
            {
                headList = next;
                count--;
                return item;
            }
            else if(temp.data.CompareTo(item) == 0 && next == null)
            {
                headList = null;
                count = 0;
                return item;
            }
            do
            {
                if (next.data.CompareTo(item) == 0)
                {
                    temp.nextNode = next.nextNode;
                    break;
                }
                temp = temp.nextNode;
                next = temp.nextNode;
            } while (next != null && temp.data.CompareTo(item) != 0);
            count--;
            return item;
        }
        Console.WriteLine("List does not contain element '" + item + "'.");
        return default(T);
    }
    public void Print()
    {
        Node<T> temp = headList;
        while(temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.nextNode;
        }
        Console.Write("\n");
    }
}

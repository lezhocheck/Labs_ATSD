using System;

class Node 
{
    public int data;
    public Node nextNode;

    public Node(int data)
    {
        this.data = data;
        nextNode = null;
    }
}
class LinkedList
{
    private Node headList;
    private int count;

    public LinkedList()
    {
        headList = null;
        count = 0;
    }
    public void AddItem(int item)
    {
        Node temp = headList;
        Node node = new Node(item);
        if(headList == null || headList.data >= item)
        {
            headList = node;
            headList.nextNode = temp;
        }
        else
        {
            while(temp.nextNode != null && temp.nextNode.data < item)
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
    public bool SearchItem(int item)
    {
        bool result = false;
        Node temp = headList;
        while(temp != null)
        {
            if(temp.data == item)
            {
                result = true;
                break;
            }
            temp = temp.nextNode;
        }
        return result;
    }
    public int GetItemByIndex(int index)
    {
        Node temp = headList;
        int indexer = 0;
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Invalid index.");
            return Int32.MinValue;
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
        return Int32.MinValue;
    }
    public int DeleteItem(int item)
    {
        if (SearchItem(item))
        {
            Node temp = headList;
            Node next = headList.nextNode;
            if(temp.data == item && next != null)
            {
                headList = next;
                return item;
            }
            else if(temp.data == item && next == null)
            {
                headList = null;
                count = 0;
                return item;
            }
            do
            {
                if (next.data == item)
                {
                    temp.nextNode = next.nextNode;
                    break;
                }
                temp = temp.nextNode;
                next = temp.nextNode;
            } while (next != null && temp.data != item);
            count--;
            return item;
        }
        Console.WriteLine("List does not contain element '" + item + "'.");
        return Int32.MinValue;
    }
    public void Print()
    {
        Node temp = headList;
        while(temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.nextNode;
        }
        Console.Write("\n");
    }
}

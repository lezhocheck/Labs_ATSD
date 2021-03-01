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
    public void Print()
    {
        Node temp = headList;
        while(temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.nextNode;
        }
    }
}

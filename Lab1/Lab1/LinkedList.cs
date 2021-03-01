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
        Node node = new Node(item);
        node.nextNode = headList;
        headList = node;
        count++;
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

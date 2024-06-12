using System;
public class BinaryTree<T>
{
    private Node root;
    private SinglyLinkedList<Node> allNodes = new SinglyLinkedList<Node>();
    class Node
    {
        public T Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Node(T value)
        {

        }

    }
    public void InsertNewNode(T value, T fatherValue)
    {

    }
    public void InDepthSearch()
    {

    }
}

namespace Queue;

public class Node<T>
{
    public Node(T item, Node<T> next = null)
    {
        Item = item;
        Next = next;
    }

    public T Item { get; set; }

    public Node<T> Next { get; set; }

    public Node<T> Previous { get; set; }
}
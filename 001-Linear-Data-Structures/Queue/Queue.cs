using System.Collections;

namespace Queue;

public class Queue<T> : IAbstractQueue<T>
{
    private Node<T> _head;

    public Queue()
    {
        _head = null;
        Count = 0;
    }

    public Queue(Node<T> head)
    {
        _head = head;
        Count = 1;
    }

    public int Count { get; private set; }

    public void Enqueue(T item)
    {
        var nodeToInsert = new Node<T>(item);

        if (_head == null)
        {
            _head = nodeToInsert;
        }
        else
        {
            var current = _head;

            while (current.Next != null) current = current.Next;

            current.Next = nodeToInsert;
        }

        Count++;
    }

    public T Dequeue()
    {
        EnsureNotEmpty();

        var removedNode = _head;
        _head = _head.Next;

        Count--;

        return removedNode.Item;
    }

    public T Peek()
    {
        EnsureNotEmpty();

        return _head.Item;
    }

    public bool Contains(T item)
    {
        EnsureNotEmpty();

        var current = _head;

        while (current != null)
        {
            if (current.Item.Equals(item)) return true;

            current = current.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = _head;

        while (current != null)
        {
            yield return current.Item;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void EnsureNotEmpty()
    {
        if (Count == 0) throw new InvalidOperationException("Queue is empty!");
    }
}
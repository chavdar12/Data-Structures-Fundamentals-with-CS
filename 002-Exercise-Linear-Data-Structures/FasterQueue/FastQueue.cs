using System.Collections;

namespace FasterQueue;

public class FastQueue<T> : IAbstractQueue<T>
{
    private Node<T> _head;
    private Node<T> _tail;

    public FastQueue()
    {
        _head = null;
        _tail = null;
        Count = 0;
    }

    public FastQueue(Node<T> head)
    {
        _head = _tail = head;
        Count = 1;
    }

    public int Count { get; private set; }

    public void Enqueue(T item)
    {
        var nodeToInsert = new Node<T>
        {
            Item = item
        };

        if (Count == 0)
        {
            _head = _tail = nodeToInsert;
        }
        else
        {
            _tail.Next = nodeToInsert;
            _tail = nodeToInsert;
        }

        Count++;
    }

    public T Dequeue()
    {
        EnsureNotEmpty();

        var removedNode = _head;

        if (Count == 1)
            _head = _tail = null;
        else
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
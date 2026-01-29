using System.Collections;

namespace FasterQueue;

public class SlowQueue<T> : IAbstractQueue<T>
{
    private Node<T> _head;

    public int Count { get; private set; }

    public bool Contains(T item)
    {
        var current = _head;

        while (current != null)
        {
            if (current.Item.Equals(item)) return true;

            current = current.Next;
        }

        return false;
    }

    public T Dequeue()
    {
        EnsureNotEmpty();

        var headItem = _head.Item;
        var newHead = _head.Next;
        _head.Next = null;
        _head = newHead;

        Count--;

        return headItem;
    }

    public void Enqueue(T item)
    {
        var newNode = new Node<T>
        {
            Item = item,
            Next = null
        };

        if (_head is null)
        {
            _head = newNode;
        }
        else
        {
            var current = _head;

            while (current.Next != null)
                current = current.Next;

            current.Next = newNode;
        }

        Count++;
    }

    public T Peek()
    {
        EnsureNotEmpty();

        return _head.Item;
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
        if (Count == 0)
            throw new InvalidOperationException();
    }
}
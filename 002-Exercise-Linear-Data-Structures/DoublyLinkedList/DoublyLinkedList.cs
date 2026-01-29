using System.Collections;

namespace DoublyLinkedList;

public class DoublyLinkedList<T> : IAbstractLinkedList<T>
{
    private Node<T> _head;
    private Node<T> _tail;

    public DoublyLinkedList()
    {
        _head = _tail = null;
        Count = 0;
    }

    public DoublyLinkedList(Node<T> head)
    {
        _head = _tail = head;
        Count = 1;
    }

    public int Count { get; private set; }

    public void AddFirst(T item)
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
            _head.Previous = nodeToInsert;
            nodeToInsert.Next = _head;
            _head = nodeToInsert;
        }

        Count++;
    }

    public void AddLast(T item)
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
            nodeToInsert.Previous = _tail;
            _tail = nodeToInsert;
        }

        Count++;
    }

    public T GetFirst()
    {
        EnsureNotEmpty();

        return _head.Item;
    }

    public T GetLast()
    {
        EnsureNotEmpty();

        return _tail.Item;
    }

    public T RemoveFirst()
    {
        EnsureNotEmpty();

        var nodeToRemove = _head;

        if (Count == 1)
        {
            _head = _tail = null;
        }
        else
        {
            _head = _head.Next;
            _head.Previous = null;
        }

        Count--;
        return nodeToRemove.Item;
    }

    public T RemoveLast()
    {
        EnsureNotEmpty();

        var nodeToRemove = _tail;

        if (Count == 1)
        {
            _head = _tail = null;
        }
        else
        {
            _tail = _tail.Previous;
            _tail.Next = null;
        }

        Count--;
        return nodeToRemove.Item;
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
        if (Count == 0) throw new InvalidOperationException("Linked List is empty!");
    }
}
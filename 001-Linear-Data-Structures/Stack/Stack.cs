using System.Collections;

namespace Stack;

public class Stack<T> : IAbstractStack<T>
{
    private Node<T> _top;

    public Stack()
    {
        _top = null;
        Count = 0;
    }

    public Stack(Node<T> top)
    {
        _top = top;
        Count = 1;
    }

    public int Count { get; private set; }

    public void Push(T item)
    {
        var newNode = new Node<T>(item)
        {
            Item = item,
            Next = _top
        };

        _top = newNode;
        Count++;
    }

    public T Pop()
    {
        EnsureNotEmpty();

        var topNodeItem = _top.Item;

        var newTop = _top.Next;

        _top.Next = null;

        _top = newTop;
        Count--;

        return topNodeItem;
    }

    public T Peek()
    {
        EnsureNotEmpty();

        return _top.Item;
    }

    public bool Contains(T item)
    {
        EnsureNotEmpty();

        var current = _top;

        while (current != null)
        {
            if (current.Item.Equals(item)) return true;

            current = current.Next;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = _top;

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
        if (Count == 0) throw new InvalidOperationException("Stack is empty!");
    }
}
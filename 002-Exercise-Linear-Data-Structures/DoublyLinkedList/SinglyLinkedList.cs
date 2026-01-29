using System.Collections;

namespace DoublyLinkedList;

public class SinglyLinkedList<T> : IAbstractLinkedList<T>
{
    private Node<T> head;

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        var newNode = new Node<T>
        {
            Item = item,
            Next = head
        };

        head = newNode;
        Count++;
    }

    public void AddLast(T item)
    {
        var newNode = new Node<T>
        {
            Item = item
        };

        if (head is null)
        {
            head = newNode;
        }
        else
        {
            var current = head;

            while (current.Next != null)
                current = current.Next;

            current.Next = newNode;
        }

        Count++;
    }

    public T GetFirst()
    {
        EnsureNotEmpty();

        return head.Item;
    }

    public T GetLast()
    {
        EnsureNotEmpty();

        var current = head;
        while (current.Next != null)
            current = current.Next;

        return current.Item;
    }

    public T RemoveFirst()
    {
        EnsureNotEmpty();

        var headItem = head.Item;
        var newHead = head.Next;
        head.Next = null;
        head = newHead;
        Count--;

        return headItem;
    }

    public T RemoveLast()
    {
        EnsureNotEmpty();

        if (head.Next is null)
            return RemoveFirst();

        var current = head;

        while (current.Next.Next != null) current = current.Next;

        var lastItem = current.Next.Item;
        current.Next = null;
        Count--;

        return lastItem;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;

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
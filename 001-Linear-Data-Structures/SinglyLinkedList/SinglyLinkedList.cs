using System.Collections;

namespace SinglyLinkedList;

public class SinglyLinkedList<T> : IAbstractLinkedList<T>
{
    private Node<T> _head;

    public SinglyLinkedList()
    {
        _head = null;
        Count = 0;
    }

    public SinglyLinkedList(Node<T> head)
    {
        _head = head;
        Count = 1;
    }

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        var newNode = new Node<T>(item)
        {
            Item = item,
            Next = _head
        };

        _head = newNode;
        Count++;
    }

    public void AddLast(T item)
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

    public T GetFirst()
    {
        EnsureNotEmpty();

        return _head.Item;
    }

    public T GetLast()
    {
        EnsureNotEmpty();

        var current = _head;

        while (current.Next != null) current = current.Next;

        return current.Item;
    }

    public T RemoveFirst()
    {
        EnsureNotEmpty();

        var removedNode = _head;
        _head = _head.Next;

        Count--;
        return removedNode.Item;
    }

    public T RemoveLast()
    {
        EnsureNotEmpty();

        var current = _head;
        Node<T> last = null;

        // Works when there is only 1 element in the list
        if (current.Next == null)
        {
            last = _head;
            _head = null;
        }
        else
        {
            while (current != null)
            {
                // Works when there are more than 1 elements in the list
                if (current.Next.Next == null)
                {
                    last = current.Next;
                    current.Next = null;
                    break;
                }

                current = current.Next;
            }
        }

        Count--;

        return last.Item;
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
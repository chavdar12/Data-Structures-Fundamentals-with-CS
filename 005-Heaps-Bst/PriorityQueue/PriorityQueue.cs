namespace PriorityQueue;

public class PriorityQueue<T> : IAbstractHeap<T>
    where T : IComparable<T>
{
    private readonly List<T> _elements;

    public PriorityQueue()
    {
        _elements = new List<T>();
    }

    public int Size => _elements.Count;

    public T Dequeue()
    {
        var firstElement = Peek();

        Swap(0, Size - 1);

        _elements.RemoveAt(Size - 1);

        HeapifyDown();

        return firstElement;
    }

    public void Add(T element)
    {
        _elements.Add(element);

        HeapifyUp();
    }

    public T Peek()
    {
        EnsureNotEmpty();

        return _elements[0];
    }

    private void EnsureNotEmpty()
    {
        if (Size == 0) throw new InvalidOperationException("Priority queue is empty!");
    }

    private void HeapifyUp()
    {
        var currentIndex = Size - 1;
        var parentIndex = GetParentIndex(currentIndex);

        while (IndexIsValid(currentIndex)
               && IsGreater(currentIndex, parentIndex))
        {
            Swap(currentIndex, parentIndex);

            currentIndex = parentIndex;
            parentIndex = GetParentIndex(currentIndex);
        }
    }

    private void HeapifyDown()
    {
        var index = 0;

        while (IndexIsValid(GetLeftChildIndex(index)))
        {
            var toSwapWith = GetLeftChildIndex(index);
            var rightChildIndex = GetRightChildIndex(index);

            if (IndexIsValid(rightChildIndex)
                && IsLess(toSwapWith, rightChildIndex))
                toSwapWith = rightChildIndex;

            if (!IsLess(index, toSwapWith)) break;

            Swap(toSwapWith, index);
            index = toSwapWith;
        }
    }

    private bool IsGreater(int firstIndex, int secondIndex)
    {
        return _elements[firstIndex].CompareTo(_elements[secondIndex]) > 0;
    }

    private bool IsLess(int firstIndex, int secondIndex)
    {
        return _elements[firstIndex].CompareTo(_elements[secondIndex]) < 0;
    }

    private int GetParentIndex(int childIndex)
    {
        return (childIndex - 1) / 2;
    }

    private int GetLeftChildIndex(int parentIndex)
    {
        return 2 * parentIndex + 1;
    }

    private int GetRightChildIndex(int parentIndex)
    {
        return 2 * parentIndex + 2;
    }

    private bool IndexIsValid(int index)
    {
        return index < Size;
    }

    private void Swap(int firstIndex, int secondIndex)
    {
        var temp = _elements[firstIndex];
        _elements[firstIndex] = _elements[secondIndex];
        _elements[secondIndex] = temp;
    }
}
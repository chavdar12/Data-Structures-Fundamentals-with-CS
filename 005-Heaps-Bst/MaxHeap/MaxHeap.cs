namespace MaxHeap;

public class MaxHeap<T> : IAbstractHeap<T>
    where T : IComparable<T>
{
    private readonly List<T> _elements;

    public MaxHeap()
    {
        _elements = new List<T>();
    }

    public int Size => _elements.Count;

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
        if (Size == 0) throw new InvalidOperationException("Max heap is empty!");
    }

    private void HeapifyUp()
    {
        var currentIndex = Size - 1;
        var parentIndex = GetParentIndex(currentIndex);

        while (
            IndexIsValid(currentIndex)
            && IsGreater(currentIndex, parentIndex))
        {
            Swap(currentIndex, parentIndex);

            currentIndex = parentIndex;
            parentIndex = GetParentIndex(currentIndex);
        }
    }

    private bool IsGreater(int firstIndex, int secondIndex)
    {
        return _elements[firstIndex].CompareTo(_elements[secondIndex]) > 0;
    }

    private int GetParentIndex(int childIndex)
    {
        return (childIndex - 1) / 2;
    }

    private bool IndexIsValid(int index)
    {
        return index > 0;
    }

    private void Swap(int firstIndex, int secondIndex)
    {
        var temp = _elements[firstIndex];
        _elements[firstIndex] = _elements[secondIndex];
        _elements[secondIndex] = temp;
    }
}
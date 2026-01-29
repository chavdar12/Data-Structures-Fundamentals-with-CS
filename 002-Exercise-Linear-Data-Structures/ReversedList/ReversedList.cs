using System.Collections;

namespace ReversedList;

public class ReversedList<T> : IAbstractList<T>
{
    private const int DefaultCapacity = 4;

    private T[] _items;

    public ReversedList()
        : this(DefaultCapacity)
    {
    }

    public ReversedList(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException(nameof(capacity));

        _items = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            ValidateIndex(index);
            return _items[Count - 1 - index];
        }
        set
        {
            ValidateIndex(index);
            _items[index] = value;
        }
    }

    public int Count { get; private set; }

    public void Add(T item)
    {
        GrowIfNecessary();
        _items[Count++] = item;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) != -1;
    }


    public int IndexOf(T item)
    {
        for (var i = 0; i < Count; i++)
            if (_items[Count - 1 - i].Equals(item))
                return i;

        return -1;
    }

    public void Insert(int index, T item)
    {
        ValidateIndex(index);
        GrowIfNecessary();

        var indexToInsertAt = Count - index;

        for (var i = Count; i > indexToInsertAt; i--) _items[i] = _items[i - 1];

        _items[indexToInsertAt] = item;
        Count++;
    }

    public bool Remove(T item)
    {
        var indexToRemoveAt = IndexOf(item);

        if (indexToRemoveAt == -1) return false;

        RemoveAt(indexToRemoveAt);
        return true;
    }

    public void RemoveAt(int index)
    {
        ValidateIndex(index);

        var indexToRemoveAt = Count - 1 - index;

        for (var i = indexToRemoveAt; i < Count - 1; i++) _items[i] = _items[i + 1];

        _items[Count - 1] = default;
        Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = Count - 1; i >= 0; i--) yield return _items[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void ValidateIndex(int index)
    {
        if (index < 0 || index >= Count) throw new IndexOutOfRangeException(nameof(index));
    }

    private void GrowIfNecessary()
    {
        if (Count == _items.Length) _items = Grow();
    }

    private T[] Grow()
    {
        var newArray = new T[Count * 2];
        Array.Copy(_items, newArray, _items.Length);
        return newArray;
    }
}
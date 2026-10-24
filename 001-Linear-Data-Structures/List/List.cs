using System.Collections;

namespace List;

public class List<T> : IAbstractList<T>
{
    private const int DEFAULT_CAPACITY = 4;
    private T[] _items;

    public List() : this(DEFAULT_CAPACITY)
    {
    }

    public List(int capacity)
    {
        if (capacity < 0) throw new ArgumentOutOfRangeException(nameof(capacity));

        _items = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            ValidateIndex(index);
            return _items[index];
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
            if (EqualityComparer<T>.Default.Equals(_items[i], item))
                return i;

        return -1;
    }

    public void Insert(int index, T item)
    {
        ValidateIndex(index);
        GrowIfNecessary();

        for (var i = Count; i > index; i--) _items[i] = _items[i - 1];

        this[index] = item;
        Count++;
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);

        if (index == -1) return false;

        RemoveAt(index);
        return true;
    }

    public void RemoveAt(int index)
    {
        ValidateIndex(index);

        for (var i = index; i < Count - 1; i++) _items[i] = _items[i + 1];

        _items[Count - 1] = default;
        Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = 0; i < Count; i++) yield return _items[i];
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
        var newArray = new T[Math.Max(DEFAULT_CAPACITY, Count * 2)];
        Array.Copy(_items, newArray, _items.Length);
        return newArray;
    }
}
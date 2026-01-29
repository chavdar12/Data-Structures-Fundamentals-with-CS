namespace Queue;

public interface IAbstractQueue<T> : IEnumerable<T>
{
    int Count { get; }

    void Enqueue(T item);

    T Dequeue();

    T Peek();

    bool Contains(T item);
}
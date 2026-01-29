namespace BinarySearchTree;

public interface IAbstractBinarySearchTree<T>
    where T : IComparable<T>
{
    Node<T> Root { get; }

    Node<T> LeftChild { get; }

    Node<T> RightChild { get; }

    T Value { get; }
    void Insert(T element);

    bool Contains(T element);

    IAbstractBinarySearchTree<T> Search(T element);
}
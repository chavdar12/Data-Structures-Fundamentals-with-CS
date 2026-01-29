namespace LowestCommonAncestor;

public class BinaryTree<T> : IAbstractBinaryTree<T>
    where T : IComparable<T>
{
    public BinaryTree(
        T value,
        BinaryTree<T> leftChild,
        BinaryTree<T> rightChild)
    {
        Value = value;
        LeftChild = leftChild;
        RightChild = rightChild;
        if (leftChild != null) LeftChild.Parent = this;

        if (rightChild != null) RightChild.Parent = this;
    }

    public T Value { get; set; }

    public BinaryTree<T> LeftChild { get; set; }

    public BinaryTree<T> RightChild { get; set; }

    public BinaryTree<T> Parent { get; set; }

    public T FindLowestCommonAncestor(T first, T second)
    {
        var firstNode = FindBfs(first, this);
        var secondNode = FindBfs(second, this);

        if (firstNode == null || secondNode == null) throw new InvalidOperationException();

        var firstAncestor = FindAncestors(firstNode);
        var secondAncestor = FindAncestors(secondNode);

        return firstAncestor.Intersect(secondAncestor).First();
    }

    private Queue<T> FindAncestors(BinaryTree<T> node)
    {
        var queue = new Queue<T>();

        var current = node;

        while (current != null)
        {
            queue.Enqueue(current.Value);
            current = current.Parent;
        }

        return queue;
    }

    private BinaryTree<T> FindBfs(T element, BinaryTree<T> node)
    {
        var queue = new Queue<BinaryTree<T>>();

        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            if (element.Equals(currentNode.Value)) return currentNode;

            if (currentNode.LeftChild != null) queue.Enqueue(currentNode.LeftChild);

            if (currentNode.RightChild != null) queue.Enqueue(currentNode.RightChild);
        }

        return null;
    }
}
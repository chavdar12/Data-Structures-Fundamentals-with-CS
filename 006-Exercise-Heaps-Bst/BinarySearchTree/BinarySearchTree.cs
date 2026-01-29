namespace BinarySearchTree;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
{
    private Node root;

    private BinarySearchTree(Node node)
    {
        PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
    }

    public void Insert(T element)
    {
        root = Insert(element, root);
    }

    public bool Contains(T element)
    {
        var current = FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        EachInOrder(root, action);
    }

    public IBinarySearchTree<T> Search(T element)
    {
        var current = FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMax()
    {
        if (root == null) throw new InvalidOperationException();

        root = DeleteMax(root);
    }

    public void DeleteMin()
    {
        if (root == null) throw new InvalidOperationException();

        root = DeleteMin(root);
    }

    public int Count()
    {
        return Count(root);
    }

    public int Rank(T element)
    {
        return Rank(root, element);
    }

    public T Select(int rank)
    {
        var node = Select(root, rank);

        if (node == null) throw new InvalidOperationException();

        return node.Value;
    }

    public T Ceiling(T element)
    {
        return Select(Rank(element) + 1);
    }

    public T Floor(T element)
    {
        return Select(Rank(element) - 1);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        var collection = new Queue<T>();
        Range(root, startRange, endRange, collection);

        return collection;
    }

    public void Delete(T element)
    {
        if (root == null) throw new InvalidOperationException();

        root = Delete(root, element);
    }

    private Node DeleteMax(Node node)
    {
        if (node.Right == null) return node.Left;

        node.Right = DeleteMax(node.Right);

        return node;
    }

    private Node DeleteMin(Node node)
    {
        if (node.Left == null) return node.Right;

        node.Left = DeleteMin(node.Left);

        return node;
    }

    private int Count(Node node)
    {
        if (node == null) return 0;

        return 1 + Count(node.Left) + Count(node.Right);
    }

    private int Rank(Node node, T element)
    {
        if (node == null) return 0;

        if (element.CompareTo(node.Value) < 0)
            return Rank(node.Left, element);
        if (element.CompareTo(node.Value) > 0) return 1 + Count(node.Left) + Rank(node.Right, element);

        return Count(node.Left);
    }

    private Node Select(Node node, int rank)
    {
        if (node == null) return null;

        var leftCount = Count(node.Left);

        if (leftCount == rank) return node;

        if (leftCount > rank)
            return Select(node.Left, rank);
        return Select(node.Right, rank - (leftCount + 1));
    }

    private void Range(Node node, T startRange, T endRange, Queue<T> queue)
    {
        if (node == null) return;

        var nodeInLowerRange = startRange.CompareTo(node.Value) < 0;
        var nodeInUpperRange = endRange.CompareTo(node.Value) > 0;

        if (nodeInLowerRange) Range(node.Left, startRange, endRange, queue);

        if (startRange.CompareTo(node.Value) <= 0 && endRange.CompareTo(node.Value) >= 0) queue.Enqueue(node.Value);

        if (nodeInUpperRange) Range(node.Right, startRange, endRange, queue);
    }

    private Node FindElement(T element)
    {
        var current = root;

        while (current != null)
            if (current.Value.CompareTo(element) > 0)
                current = current.Left;
            else if (current.Value.CompareTo(element) < 0)
                current = current.Right;
            else
                break;

        return current;
    }

    private void PreOrderCopy(Node node)
    {
        if (node == null) return;

        Insert(node.Value);
        PreOrderCopy(node.Left);
        PreOrderCopy(node.Right);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
            node = new Node(element);
        else if (element.CompareTo(node.Value) < 0)
            node.Left = Insert(element, node.Left);
        else if (element.CompareTo(node.Value) > 0) node.Right = Insert(element, node.Right);

        return node;
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null) return;

        EachInOrder(node.Left, action);
        action(node.Value);
        EachInOrder(node.Right, action);
    }

    private Node Delete(Node node, T element)
    {
        if (node == null) return null;

        var compare = element.CompareTo(node.Value);

        if (compare < 0)
        {
            node.Left = Delete(node.Left, element);
        }
        else if (compare > 0)
        {
            node.Right = Delete(node.Right, element);
        }
        else
        {
            if (node.Left == null) return node.Right;

            if (node.Right == null) return node.Left;

            var successor = FindMin(node.Right);
            node.Value = successor.Value;
            node.Right = Delete(node.Right, successor.Value);
        }

        return node;
    }

    private Node FindMin(Node node)
    {
        while (node.Left != null) node = node.Left;

        return node;
    }

    private class Node
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
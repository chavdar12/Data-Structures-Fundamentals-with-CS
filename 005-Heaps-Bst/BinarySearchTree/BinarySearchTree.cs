namespace BinarySearchTree;

public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
    where T : IComparable<T>
{
    public BinarySearchTree()
    {
    }

    public BinarySearchTree(Node<T> root)
    {
        // Create copy from root

        Copy(root);
    }

    public Node<T> Root { get; private set; }

    public Node<T> LeftChild { get; private set; }

    public Node<T> RightChild { get; private set; }

    public T Value => Root.Value;

    public bool Contains(T element)
    {
        var current = Root;

        while (current != null)
            if (IsLess(element, current.Value))
                current = current.LeftChild;
            else if (IsGreater(element, current.Value))
                current = current.RightChild;
            else
                return true;

        return false;
    }

    public void Insert(T element)
    {
        // Check if first added element is the root
        // Find where to add element (while)
        // If element exists return            

        var toInsert = new Node<T>(element, null, null);

        if (Root == null)
        {
            Root = toInsert;
        }
        else
        {
            var current = Root;
            Node<T> previous = null;

            while (current != null)
            {
                previous = current;
                if (IsLess(element, current.Value))
                    current = current.LeftChild;
                else if (IsGreater(element, current.Value))
                    current = current.RightChild;
                else
                    return;
            }

            if (IsLess(element, previous.Value))
            {
                previous.LeftChild = toInsert;

                if (LeftChild == null) LeftChild = toInsert;
            }
            else
            {
                previous.RightChild = toInsert;

                if (RightChild == null) RightChild = toInsert;
            }
        }
    }

    public IAbstractBinarySearchTree<T> Search(T element)
    {
        var current = Root;

        while (current != null && !AreEqual(element, current.Value))
            if (IsLess(element, current.Value))
                current = current.LeftChild;
            else if (IsGreater(element, current.Value)) current = current.RightChild;

        return new BinarySearchTree<T>(current);
    }

    private bool IsLess(T firstValue, T secondValue)
    {
        return firstValue.CompareTo(secondValue) < 0;
    }

    private bool IsGreater(T firstValue, T secondValue)
    {
        return firstValue.CompareTo(secondValue) > 0;
    }

    private bool AreEqual(T firstValue, T secondValue)
    {
        return firstValue.CompareTo(secondValue) == 0;
    }

    private void Copy(Node<T> root)
    {
        // Copies Element in Pre Order

        if (root != null)
        {
            Insert(root.Value);
            Copy(root.LeftChild);
            Copy(root.RightChild);
        }
    }
}
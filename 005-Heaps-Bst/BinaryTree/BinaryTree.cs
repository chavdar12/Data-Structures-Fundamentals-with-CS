using System.Text;

namespace BinaryTree;

public class BinaryTree<T> : IAbstractBinaryTree<T>
{
    public BinaryTree(T value, IAbstractBinaryTree<T> leftChild, IAbstractBinaryTree<T> rightChild)
    {
        Value = value;
        LeftChild = leftChild;
        RightChild = rightChild;
    }

    public T Value { get; }

    public IAbstractBinaryTree<T> LeftChild { get; }

    public IAbstractBinaryTree<T> RightChild { get; }

    public string AsIndentedPreOrder(int indent)
    {
        var result = new StringBuilder();

        AsIndentedPreOrderDfs(this, indent, result);

        return result.ToString();
    }

    public List<IAbstractBinaryTree<T>> InOrder()
    {
        var inOrderElements = new List<IAbstractBinaryTree<T>>();

        if (LeftChild != null) inOrderElements.AddRange(LeftChild.InOrder());

        inOrderElements.Add(this);

        if (RightChild != null) inOrderElements.AddRange(RightChild.InOrder());

        return inOrderElements;
    }

    public List<IAbstractBinaryTree<T>> PostOrder()
    {
        var postOrderElements = new List<IAbstractBinaryTree<T>>();

        if (LeftChild != null) postOrderElements.AddRange(LeftChild.PostOrder());

        if (RightChild != null) postOrderElements.AddRange(RightChild.PostOrder());

        postOrderElements.Add(this);

        return postOrderElements;
    }

    public List<IAbstractBinaryTree<T>> PreOrder()
    {
        var preOrderElements = new List<IAbstractBinaryTree<T>>();

        preOrderElements.Add(this);

        if (LeftChild != null) preOrderElements.AddRange(LeftChild.PreOrder());

        if (RightChild != null) preOrderElements.AddRange(RightChild.PreOrder());

        return preOrderElements;
    }

    public void ForEachInOrder(Action<T> action)
    {
        if (LeftChild != null) LeftChild.ForEachInOrder(action);

        action.Invoke(Value);

        if (RightChild != null) RightChild.ForEachInOrder(action);
    }

    private void AsIndentedPreOrderDfs(IAbstractBinaryTree<T> current, int indent, StringBuilder result)
    {
        result.AppendLine($"{new string(' ', indent)}{current.Value}");

        if (current.LeftChild != null) AsIndentedPreOrderDfs(current.LeftChild, indent + 2, result);

        if (current.RightChild != null) AsIndentedPreOrderDfs(current.RightChild, indent + 2, result);
    }
}
namespace Tree;

public class Tree<T> : IAbstractTree<T>
{
    private readonly List<Tree<T>> _children;

    public Tree(T value)
    {
        Value = value;
        Parent = null;
        _children = new List<Tree<T>>();
    }

    public Tree(T value, params Tree<T>[] children)
        : this(value)
    {
        foreach (var child in children)
        {
            child.Parent = this;
            _children.Add(child);
        }
    }

    public bool IsRootDeleted { get; private set; }

    public T Value { get; private set; }

    public Tree<T> Parent { get; private set; }

    public IReadOnlyCollection<Tree<T>> Children
        => _children.AsReadOnly();

    public ICollection<T> OrderBfs()
    {
        var result = new List<T>();
        var queue = new Queue<Tree<T>>();

        if (IsRootDeleted) return result;

        queue.Enqueue(this);

        while (queue.Count != 0)
        {
            var subtree = queue.Dequeue();

            result.Add(subtree.Value);

            foreach (var child in subtree.Children) queue.Enqueue(child);
        }

        return result;
    }

    public ICollection<T> OrderDfs()
    {
        var result = new List<T>();

        if (IsRootDeleted) return result;

        Dfs(this, result);

        return result;
    }

    public void AddChild(T parentKey, Tree<T> child)
    {
        var searchedNode = FindBfs(parentKey);

        CheckEmptyNode(searchedNode);

        searchedNode._children.Add(child);
    }

    public void RemoveNode(T nodeKey)
    {
        var searchedNode = FindBfs(nodeKey);

        CheckEmptyNode(searchedNode);

        foreach (var child in searchedNode.Children) child.Parent = null;

        searchedNode._children.Clear();

        var searchedParent = searchedNode.Parent;

        // If it is the root there is no parent
        if (searchedParent == null)
            IsRootDeleted = true;
        else
            searchedParent._children.Remove(searchedNode);

        searchedNode.Value = default;
    }

    public void Swap(T firstKey, T secondKey)
    {
        var firstNode = FindBfs(firstKey);
        var secondNode = FindBfs(secondKey);

        CheckEmptyNode(firstNode);
        CheckEmptyNode(secondNode);

        var firstParent = firstNode.Parent;
        var secondParent = secondNode.Parent;

        // If one of the nodes is the root node
        if (firstParent == null)
        {
            // change the root node's value
            Value = secondNode.Value;

            // replace the old children with the new ones
            _children.Clear();
            foreach (var child in secondNode.Children) _children.Add(child);
        }
        else if (secondParent == null)
        {
            Value = firstNode.Value;
            _children.Clear();
            foreach (var child in firstNode.Children) _children.Add(child);
        }
        else
        {
            firstNode.Parent = secondParent;
            secondNode.Parent = firstParent;

            var indexOfFirst = firstParent._children.IndexOf(firstNode);
            var indexOfSecond = secondParent._children.IndexOf(secondNode);

            firstParent._children[indexOfFirst] = secondNode;
            secondParent._children[indexOfSecond] = firstNode;
        }
    }

    private void Dfs(Tree<T> tree, List<T> result)
    {
        foreach (var child in tree.Children) Dfs(child, result);

        result.Add(tree.Value);
    }

    private Tree<T> FindBfs(T parentKey)
    {
        var queue = new Queue<Tree<T>>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var subtree = queue.Dequeue();

            if (subtree.Value.Equals(parentKey)) return subtree;

            foreach (var child in subtree.Children) queue.Enqueue(child);
        }

        return null;
    }

    private void CheckEmptyNode(Tree<T> searchedNode)
    {
        if (searchedNode == null) throw new ArgumentNullException("Searched node not found!");
    }
}
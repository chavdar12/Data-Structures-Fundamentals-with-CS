namespace Tree;

public class TreeFactory
{
    private readonly Dictionary<int, Tree<int>> nodesBykeys;

    public TreeFactory()
    {
        nodesBykeys = new Dictionary<int, Tree<int>>();
    }

    public Tree<int> CreateTreeFromStrings(string[] input)
    {
        foreach (var line in input)
        {
            var keys = line.Split(' ')
                .Select(int.Parse)
                .ToArray();

            var parentKey = keys[0];
            var childKey = keys[1];

            AddEdge(parentKey, childKey);
        }

        return GetRoot();
    }

    public Tree<int> CreateNodeByKey(int key)
    {
        if (!nodesBykeys.ContainsKey(key)) nodesBykeys.Add(key, new Tree<int>(key));

        return nodesBykeys[key];
    }

    public void AddEdge(int parent, int child)
    {
        var parentNode = CreateNodeByKey(parent);
        var childNode = CreateNodeByKey(child);

        parentNode.AddChild(childNode);
        childNode.AddParent(parentNode);
    }

    private Tree<int> GetRoot()
    {
        foreach (var keyByNode in nodesBykeys)
            if (keyByNode.Value.Parent == null)
                return keyByNode.Value;

        return null;
    }
}
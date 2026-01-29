using Tree;

namespace TreeTests;

public class TreeTests
{
    private Tree<int> _tree;
    private TreeFactory _treeFactory;


    [SetUp]
    public void InitializeFactoryAndTree()
    {
        string[] input =
        {
            "7 19",
            "7 21",
            "7 14",
            "19 1",
            "19 12",
            "19 31",
            "14 23",
            "14 6"
        };

        _treeFactory = new TreeFactory();
        _tree = _treeFactory.CreateTreeFromStrings(input);
    }

    [Test]
    public void TreeCreationShouldWorkSuccessfuly()
    {
        Assert.AreEqual(7, _tree.Key);
        Assert.NotNull(_tree.Children);
        Assert.AreEqual(3, _tree.Children.Count);
    }

    [Test]
    public void TreeAsStringShouldWorkCorrectly()
    {
        var expectedOutput = "7\r\n" +
                             "  19\r\n" +
                             "    1\r\n" +
                             "    12\r\n" +
                             "    31\r\n" +
                             "  21\r\n" +
                             "  14\r\n" +
                             "    23\r\n" +
                             "    6";

        Assert.AreEqual(expectedOutput, _tree.GetAsString());
    }

    [Test]
    public void TreeGetLeafKeysShouldWorkCorrectly()
    {
        int[] expected = { 1, 6, 12, 21, 23, 31 };
        var leafKeys = _tree.GetLeafKeys()
            .OrderBy(leaf => leaf)
            .ToList();


        for (var i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], leafKeys[i]);
    }

    [Test]
    public void TreeMiddleNodesShouldWorkCorrectly()
    {
        int[] expected = { 14, 19 };
        var middleKeys = _tree.GetMiddleKeys()
            .OrderBy(leaf => leaf)
            .ToList();


        for (var i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], middleKeys[i]);
    }

    [Test]
    public void TreeDeepestLeftmostNodeShouldWorkCorrectly()
    {
        var deepestNode = _tree.GetDeepestLeftomostNode();

        Assert.AreEqual(1, deepestNode.Key);
    }


    [Test]
    public void TreeLeftmostLongestPathShouldWorkCorrectly()
    {
        int[] expectedPath = { 7, 19, 1 };
        var longestLeftmostPath = _tree.GetLongestPath();

        for (var i = 0; i < expectedPath.Length; i++) Assert.AreEqual(expectedPath[i], longestLeftmostPath[i]);
    }

    [Test]
    public void TreePathsWithGivenSumShouldWorkCorrectly()
    {
        int[,] expected =
        {
            { 7, 19, 1 },
            { 7, 14, 6 }
        };

        var paths = _tree.PathsWithGivenSum(27);

        for (var i = 0; i < expected.GetLength(0); i++)
        for (var j = 0; j < expected.GetLength(1); j++)
            Assert.AreEqual(expected[i, j], paths[i][j]);
    }

    [Test]
    public void TreeAllSubtreesWithGivenSumShouldWorkCorrectly()
    {
        var subtrees = _tree.SubTreesWithGivenSum(43);
        Assert.AreEqual(1, subtrees.Count);
        var treeAsString = subtrees[0].GetAsString();
        Assert.IsTrue(treeAsString.Contains("14"));
        Assert.IsTrue(treeAsString.Contains("23"));
        Assert.IsTrue(treeAsString.Contains("6"));
    }
}
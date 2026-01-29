using System.Text;
using BinaryTree;

namespace BinaryTreeTests;

public class BinaryTreeTests
{
    private IAbstractBinaryTree<int> _tree;

    [SetUp]
    public void InitializeBinaryTree()
    {
        _tree = new BinaryTree<int>(17,
            new BinaryTree<int>(9, new BinaryTree<int>(3, null, null),
                new BinaryTree<int>(11, null, null)),
            new BinaryTree<int>(25, new BinaryTree<int>(20, null, null),
                new BinaryTree<int>(31, null, null))
        );
    }

    [Test]
    public void TestAsIndentedPreOrder()
    {
        var indentedPreOrder = _tree.AsIndentedPreOrder(0);
        Assert.AreEqual("17\r\n" +
                        "  9\r\n" +
                        "    3\r\n" +
                        "    11\r\n" +
                        "  25\r\n" +
                        "    20\r\n" +
                        "    31", indentedPreOrder.TrimEnd());
    }

    [Test]
    public void TestPreOrder()
    {
        var trees = _tree.PreOrder();
        int[] expected = { 17, 9, 3, 11, 25, 20, 31 };
        Assert.AreEqual(expected.Length, trees.Count);
        for (var i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], trees[i].Value);
    }


    [Test]
    public void TestInOrder()
    {
        var trees = _tree.InOrder();
        int[] expected = { 3, 9, 11, 17, 20, 25, 31 };
        Assert.AreEqual(expected.Length, trees.Count);
        for (var i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], trees[i].Value);
    }


    [Test]
    public void TestPostOrder()
    {
        var trees = _tree.PostOrder();
        int[] expected = { 3, 11, 9, 20, 31, 25, 17 };
        Assert.AreEqual(expected.Length, trees.Count);
        for (var i = 0; i < expected.Length; i++) Assert.AreEqual(expected[i], trees[i].Value);
    }

    [Test]
    public void TestForEachInOrder()
    {
        var expected = "3, 9, 11, 17, 20, 25, 31";
        var builder = new StringBuilder();
        _tree.ForEachInOrder(key => builder.Append(key).Append(", "));
        var actual = builder.ToString();
        Assert.IsTrue(builder.Length > 0);
        Assert.IsTrue(actual.Contains(", "));
        Assert.AreEqual(expected, actual.Substring(0, actual.LastIndexOf(", ")));
    }
}
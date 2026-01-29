namespace StackTests;

[TestFixture]
public class StackTests
{
    [SetUp]
    public void InitializeStack()
    {
        _stack = new Stack.Stack<int>();
    }

    private readonly Random _random = new();
    private Stack.Stack<int> _stack;

    [Test]
    public void PushShouldAddElementAtTheTop()
    {
        var count = _random.Next(10, 30);
        var array = new int[count];

        for (var i = 1; i <= count; i++)
        {
            var randomValue = _random.Next(100);
            array[count - i] = randomValue;
            _stack.Push(randomValue);
            Assert.That(_stack, Has.Count.EqualTo(i));
        }

        var index = 0;
        foreach (var stackElement in _stack)
            Assert.That(stackElement, Is.EqualTo(array[index++]));
    }

    [Test]
    public void PopShouldRemoveTheTopElement()
    {
        var count = _random.Next(10, 30);
        var array = new int[count];

        for (var i = count - 1; i >= 0; i--)
        {
            var randomValue = _random.Next(100);
            array[i] = randomValue;
            _stack.Push(randomValue);
        }

        for (var i = 0; i < count; i++)
        {
            Assert.That(_stack.Pop(), Is.EqualTo(array[i]));
            Assert.That(_stack, Has.Count.EqualTo(array.Length - (i + 1)));
        }
    }

    [Test]
    public void PopShouldThrowExceptionIfTheStackContainsNoElements()
    {
        Assert.Throws<InvalidOperationException>(() => _stack.Pop());
    }

    [Test]
    public void PeekShouldReturnTheTopElementWithoutRemovingIt()
    {
        var count = _random.Next(10, 30);
        var array = new int[count];

        for (var i = count - 1; i >= 0; i--)
        {
            var randomValue = _random.Next(100);
            array[i] = randomValue;
            _stack.Push(randomValue);
        }

        for (var i = 0; i < count; i++)
        {
            Assert.That(_stack.Peek(), Is.EqualTo(array[i]));
            Assert.That(_stack, Has.Count.EqualTo(array.Length - i));
            _stack.Pop();
        }
    }

    [Test]
    public void PeekShouldThrowExceptionIfTheStackContainsNoElements()
    {
        Assert.Throws<InvalidOperationException>(() => _stack.Peek());
    }

    [Test]
    public void ContainsShouldWorkAsExpected()
    {
        var count = _random.Next(10, 30);

        for (var i = 0; i < count; i++)
            _stack.Push(i);

        for (var i = 0; i < count; i++)
            Assert.That(_stack.Contains(i), Is.True);

        Assert.That(_stack.Contains(count), Is.False);
    }
}
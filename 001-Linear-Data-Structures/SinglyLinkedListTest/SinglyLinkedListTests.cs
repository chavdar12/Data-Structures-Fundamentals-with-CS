using SinglyLinkedList;

namespace SinglyLinkedListTest;

[TestFixture]
public class SinglyLinkedListTests
{
    [SetUp]
    public void InitializeLinkedList()
    {
        _list = new SinglyLinkedList<int>();
    }

    private readonly Random _random = new();
    private IAbstractLinkedList<int> _list;

    [Test]
    public void AddFirstShouldWorkAsExpected()
    {
        var count = _random.Next(10, 30);
        var array = new int[count];

        for (var i = 1; i <= count; i++)
        {
            var randomValue = _random.Next(100);
            array[count - i] = randomValue;
            _list.AddFirst(randomValue);
            Assert.That(_list.Count, Is.EqualTo(i));
        }

        var index = 0;
        foreach (var listElement in _list)
            Assert.That(listElement, Is.EqualTo(array[index++]));
    }

    [Test]
    public void AddLastShouldWorkAsExpected()
    {
        var count = _random.Next(10, 30);
        var array = new int[count];

        for (var i = 0; i < count; i++)
        {
            var randomValue = _random.Next(100);
            array[i] = randomValue;
            _list.AddLast(randomValue);
            Assert.That(_list, Has.Count.EqualTo(i + 1));
        }

        var index = 0;
        foreach (var listElement in _list)
            Assert.That(listElement, Is.EqualTo(array[index++]));
    }

    [Test]
    public void RemoveFirstShouldWorkAsExpected()
    {
        var count = _random.Next(10, 30);
        var array = new int[count];

        for (var i = 0; i < count; i++)
        {
            var randomValue = _random.Next(100);
            array[i] = randomValue;
            _list.AddLast(randomValue);
        }

        for (var i = 0; i < count; i++)
        {
            var removedElement = _list.RemoveFirst();
            Assert.That(removedElement, Is.EqualTo(array[i]));
            Assert.That(_list, Has.Count.EqualTo(array.Length - (i + 1)));
        }
    }

    [Test]
    public void RemoveFirstShouldThrowAnExceptionIfInvalidIndexIsPassed()
    {
        Assert.Throws<InvalidOperationException>(() => _list.RemoveFirst());
    }

    [Test]
    public void RemoveLastShouldWorkAsExpected()
    {
        var count = _random.Next(10, 30);
        var array = new int[count];

        for (var i = 0; i < count; i++)
        {
            var randomValue = _random.Next(100);
            array[i] = randomValue;
            _list.AddFirst(randomValue);
        }

        for (var i = 0; i < count; i++)
        {
            var removedElement = _list.RemoveLast();
            Assert.That(removedElement, Is.EqualTo(array[i]));
            Assert.That(_list, Has.Count.EqualTo(array.Length - (i + 1)));
        }
    }

    [Test]
    public void RemoveLastShouldThrowAnExceptionIfInvalidIndexIsPassed()
    {
        Assert.Throws<InvalidOperationException>(() => _list.RemoveLast());
    }

    [Test]
    public void GetFirstShouldWorkAsExpected()
    {
        var count = _random.Next(10, 30);
        var array = new int[count];

        for (var i = 0; i < count; i++)
        {
            var randomValue = _random.Next(100);
            array[i] = randomValue;
            _list.AddLast(randomValue);
        }

        for (var i = 0; i < count; i++)
        {
            var firstElement = _list.GetFirst();
            Assert.That(firstElement, Is.EqualTo(array[i]));

            _list.RemoveFirst();
        }
    }

    [Test]
    public void GetFirstShouldThrowAnExceptionIfInvalidIndexIsPassed()
    {
        Assert.Throws<InvalidOperationException>(() => _list.GetFirst());
    }

    [Test]
    public void GetLastShouldWorkAsExpected()
    {
        var count = _random.Next(10, 30);
        var array = new int[count];

        for (var i = 0; i < count; i++)
        {
            var randomValue = _random.Next(100);
            array[i] = randomValue;
            _list.AddFirst(randomValue);
        }

        for (var i = 0; i < count; i++)
        {
            var lastElement = _list.GetLast();
            Assert.That(lastElement, Is.EqualTo(array[i]));

            _list.RemoveLast();
        }
    }

    [Test]
    public void GetLastShouldThrowAnExceptionIfInvalidIndexIsPassed()
    {
        Assert.Throws<InvalidOperationException>(() => _list.GetLast());
    }
}
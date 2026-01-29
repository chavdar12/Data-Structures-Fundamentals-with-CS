namespace QueueTests;

[TestFixture]
public class QueueTests
{
    [SetUp]
    public void InitializeQueue()
    {
        _queue = new Queue<int>();
    }

    private readonly Random random = new();
    private Queue<int> _queue;

    [Test]
    public void EnqueueShouldAddElementAtTheTop()
    {
        var count = random.Next(10, 30);
        var array = new int[count];

        for (var i = 0; i < count; i++)
        {
            var randomValue = random.Next(100);
            array[i] = randomValue;
            _queue.Enqueue(randomValue);
            Assert.AreEqual(i + 1, _queue.Count);
        }

        var index = 0;
        foreach (var queueElement in _queue) Assert.AreEqual(array[index++], queueElement);
    }

    [Test]
    public void DequeueShouldRemoveTheLastElement()
    {
        var count = random.Next(10, 30);
        var array = new int[count];

        for (var i = 0; i < count; i++)
        {
            var randomValue = random.Next(100);
            array[i] = randomValue;
            _queue.Enqueue(randomValue);
        }

        for (var i = 0; i < count; i++)
        {
            Assert.That(_queue.Dequeue(), Is.EqualTo(array[i]));
            Assert.That(_queue, Has.Count.EqualTo(array.Length - (i + 1)));
        }
    }

    [Test]
    public void DequeueShouldThrowExceptionIfTheStackContainsNoElements()
    {
        Assert.Throws<InvalidOperationException>(() => _queue.Dequeue());
    }

    [Test]
    public void PeekShouldReturnTheLastElementWithoutRemovingIt()
    {
        var count = random.Next(10, 30);
        var array = new int[count];

        for (var i = 0; i < count; i++)
        {
            var randomValue = random.Next(100);
            array[i] = randomValue;
            _queue.Enqueue(randomValue);
        }

        for (var i = 0; i < count; i++)
        {
            Assert.That(_queue.Peek(), Is.EqualTo(array[i]));
            Assert.That(_queue, Has.Count.EqualTo(array.Length - i));
            _queue.Dequeue();
        }
    }

    [Test]
    public void PeekShouldThrowExceptionIfTheStackContainsNoElements()
    {
        Assert.Throws<InvalidOperationException>(() => _queue.Peek());
    }

    [Test]
    public void ContainsShouldWorkAsExpected()
    {
        var count = random.Next(10, 30);

        for (var i = 0; i < count; i++)
            _queue.Enqueue(i);

        for (var i = 0; i < count; i++) Assert.That(_queue.Contains(i), Is.True);

        Assert.That(_queue.Contains(count), Is.False);
    }
}
using PriorityQueue;

namespace PriorityQueueTests;

public class PriorityQueueTests
{
    [Test]
    public void TestDequeueSingleElement()
    {
        var priorityQueue = new PriorityQueue<int>();
        priorityQueue.Add(13);
        Assert.That(priorityQueue.Dequeue(), Is.EqualTo(13));
    }

    [Test]
    public void TestDequeueMultipleElements()
    {
        var queue = new PriorityQueue<int>();
        var elements = new List<int> { 15, 25, 6, 9, 5, 8, 17, 16 };
        foreach (var element in elements) queue.Add(element);
        int[] expected = { 25, 17, 16, 15, 9, 8, 6, 5 };
        var index = 0;
        Assert.That(queue.Size, Is.EqualTo(expected.Length));
        while (queue.Size != 0) Assert.That(queue.Dequeue(), Is.EqualTo(expected[index++]));
    }

    [Test]
    public void TestDequeueReturnsElementsInDescendingOrder()
    {
        for (var seed = 0; seed < 50; seed++)
        {
            var random = new Random(seed);
            var queue = new PriorityQueue<int>();
            var elements = Enumerable.Range(0, 30).Select(_ => random.Next(100)).ToList();
            foreach (var element in elements) queue.Add(element);

            var actual = new List<int>();
            while (queue.Size != 0) actual.Add(queue.Dequeue());

            Assert.That(actual, Is.EqualTo(elements.OrderByDescending(e => e)), $"seed {seed}");
        }
    }

    [Test]
    public void TestDequeueEmptyThrows()
    {
        Assert.Throws<InvalidOperationException>(() => new PriorityQueue<int>().Dequeue());
    }
}

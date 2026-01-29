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
}
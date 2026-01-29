namespace Queue;

internal class Program
{
    private static void Main(string[] args)
    {
        var queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        queue.Dequeue();
        queue.Dequeue();

        Console.WriteLine(queue.Peek());
    }
}
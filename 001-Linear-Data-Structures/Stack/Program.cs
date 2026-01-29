namespace Stack;

internal class Program
{
    private static void Main(string[] args)
    {
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        stack.Pop();
        stack.Pop();
    }
}
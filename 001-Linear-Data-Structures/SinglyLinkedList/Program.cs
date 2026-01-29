namespace SinglyLinkedList;

internal class Program
{
    private static void Main(string[] args)
    {
        var list = new SinglyLinkedList<int>();
        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);

        Console.WriteLine(list.GetFirst());

        list.AddLast(4);

        Console.WriteLine(list.GetFirst());
    }
}
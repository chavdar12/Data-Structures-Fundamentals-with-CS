namespace List;

internal class Program
{
    private static void Main(string[] args)
    {
        var list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.Insert(1, 5);
        list.RemoveAt(2);

        Console.WriteLine(list.Contains(5));
    }
}
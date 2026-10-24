namespace CookiesProblem;

public class CookiesProblem
{
    public int Solve(int minSweetness, int[] cookies)
    {
        if (cookies == null || cookies.Length == 0) return -1;

        var priorityQueue = new PriorityQueue<int, int>();

        foreach (var cookie in cookies) priorityQueue.Enqueue(cookie, cookie);

        var counter = 0;

        while (priorityQueue.Peek() < minSweetness && priorityQueue.Count > 1)
        {
            var leastSweetCookie = priorityQueue.Dequeue();

            var secondCookie = priorityQueue.Dequeue();

            var newCookie = leastSweetCookie + 2 * secondCookie;

            priorityQueue.Enqueue(newCookie, newCookie);

            counter++;
        }

        return priorityQueue.Peek() < minSweetness ? -1 : counter;
    }
}

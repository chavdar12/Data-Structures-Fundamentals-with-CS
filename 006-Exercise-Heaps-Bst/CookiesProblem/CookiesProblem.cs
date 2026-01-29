using Wintellect.PowerCollections;

namespace CookiesProblem;

public class CookiesProblem
{
    public int Solve(int minSweetness, int[] cookies)
    {
        var priorityQueue = new OrderedBag<int>();

        priorityQueue.AddMany(cookies);

        var currentMinSweetness = priorityQueue.GetFirst();

        var counter = 0;

        while (currentMinSweetness < minSweetness && priorityQueue.Count > 1)
        {
            var leastSweetCookie = priorityQueue.RemoveFirst();

            var secondCookie = priorityQueue.RemoveFirst();

            var newCookie = leastSweetCookie + 2 * secondCookie;

            priorityQueue.Add(newCookie);
            currentMinSweetness = priorityQueue.GetFirst();

            counter++;
        }

        return currentMinSweetness < minSweetness ? -1 : counter;
    }
}
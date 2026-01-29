namespace CookiesProblemTests;

public class CookiesProblemTests
{
    [Test]
    public void Solve_HasSolution()
    {
        var result = new CookiesProblem.CookiesProblem().Solve(7, new[] { 1, 2, 3, 9, 10, 12 });
        Assert.AreEqual(2, result);
    }

    [Test]
    public void Solve_HasNoSolution()
    {
        var result = new CookiesProblem.CookiesProblem().Solve(10, new[] { 1, 1, 1, 1 });
        Assert.AreEqual(-1, result);
    }
}
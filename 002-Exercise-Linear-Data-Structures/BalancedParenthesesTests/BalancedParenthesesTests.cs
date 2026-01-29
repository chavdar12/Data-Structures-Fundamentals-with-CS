using BalancedParentheses;

namespace BalancedParenthesesTests;

[TestFixture]
public class BalancedParenthesesTests
{
    [SetUp]
    public void SetUp()
    {
        _instance = GetInstance();
    }

    private ISolvable _instance;

    [Theory]
    [TestCase("{[()]}", true)]
    [TestCase("{[(]]}", false)]
    [TestCase("{{{[()]}}}", true)]
    [TestCase("{{[[(())]]}}", true)]
    [TestCase("()()()()()()()()()()", true)]
    [TestCase("()[]{}{}}", false)]
    [TestCase("{()[]{}{}}", true)]
    [TestCase("{(())[]{}{}}", true)]
    [TestCase("{(())[[]]{}{}}", true)]
    [TestCase("{(())[[]]{{}}{{([])}}}", true)]
    [TestCase("()[{[{{[{}{}}{}}{}}{}}{{}())()))()))(]}}]}]", false)]
    [TestCase("((((((())))))))))))))))", false)]
    [TestCase(
        "()(((({{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{{[[[[[[[[[[[[[[[[[[[[[[[[]]]]]]]]]]]]]]]]]]]]]]]]}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}}))))",
        true)]
    public void ImplementationShouldWorkCorrectly(string input, bool expectedOutcome)
    {
        var solve = _instance.AreBalanced(input);
        Assert.That(solve, Is.EqualTo(expectedOutcome));
    }

    private static ISolvable GetInstance()
    {
        return new BalancedParenthesesSolve();
    }
}
namespace Puzzles.Day10SyntaxScoring;

public class Day10SyntaxScoring : IPuzzle
{
    public object CalculatePart1()
    {
        var input = Helpers.ReadInputData(nameof(Day10SyntaxScoring));
        return CalculatePart1(input);
    }

    public object CalculatePart2()
    {
        var input = Helpers.ReadInputData(nameof(Day10SyntaxScoring));
        return CalculatePart2(input);
    }

    public static long CalculatePart1(string[] input)
    {
        return new NavigationSubsystem(input)
            .SyntaxErrors()
            .Sum(x => x.Score);
    }

    public static long CalculatePart2(string[] input)
    {
        var incompleteLines = new NavigationSubsystem(input)
            .IncompleteLines();
        var contest = new AutoCompleteContest(incompleteLines.Select(x => x.Score));
        return contest.MiddleScore;
    }
}


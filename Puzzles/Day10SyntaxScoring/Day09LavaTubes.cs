namespace Puzzles.Day10SyntaxScoring;

public class Day10SyntaxScoring : IPuzzle
{
    public (object answer1, object answer2) Calculate()
    {
        var input = Helpers.ReadInputData(nameof(Day10SyntaxScoring));

        return (
            CalculatePart1(input),
            CalculatePart2(input)
        );
    }

    public static long CalculatePart1(string[] input)
    {
        return Parse(input)
            .Sum(x => x is SyntaxError s ? s.Score : 0);
    }

    public static long CalculatePart2(string[] input)
    {
        return 0;
    }

    public static IEnumerable<ParseResult> Parse(IEnumerable<string> input)
    {
        return input.Select(LineParser.Parse);
    }
}

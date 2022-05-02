namespace Puzzles.Day10SyntaxScoring;

public class NavigationSubsystem
{
    private readonly IEnumerable<ParseResult> parseResults
        ;

    public NavigationSubsystem(IEnumerable<string> input)
    {
        parseResults = input.Select(LineParser.Parse);
    }

    public IEnumerable<SyntaxError> SyntaxErrors()
    {
        return parseResults
            .Where(x => x is SyntaxError)
            .Cast<SyntaxError>();
    }
}

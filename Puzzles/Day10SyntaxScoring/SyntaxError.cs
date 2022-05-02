namespace Puzzles.Day10SyntaxScoring;

public class SyntaxError : ParseResult
{
    public SyntaxError(char expected, char found)
    {
        Expected = expected;
        Found = found;
    }

    public char Expected { get; }
    public char Found { get; }
    
    public int Score =>
        Found switch
        {
            ')' => 3,
            ']' => 57,
            '}' => 1197,
            '>' => 25137,
            _ => throw new InvalidDataException($"Unexpected input char {Found}")
        };
}
